using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UglyToad.PdfPig;
using VersOne.Epub;

namespace RSVPReader
{
    public partial class Form1 : Form
    {
        private string _text;
        private int _index;
        private CancellationTokenSource _cancellationTokenSource;
        private bool _isPaused;
        private string[] _words;
        private Dictionary<int, int> _chapterIndices;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|EPUB files (*.epub)|*.epub";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileExtension = Path.GetExtension(openFileDialog.FileName).ToLower();
                    if (fileExtension == ".pdf")
                    {
                        _text = ExtractTextFromPdf(openFileDialog.FileName);
                    }
                    else if (fileExtension == ".epub")
                    {
                        _text = ExtractTextFromEpub(openFileDialog.FileName);
                    }
                    lblStatus.Text = "File loaded. Ready to start.";
                    _words = _text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    IdentifyChapterIndices();
                    PopulateChapterComboBox();
                }
            }
        }

        private string ExtractTextFromPdf(string filepath)
        {
            using (var document = PdfDocument.Open(filepath))
            {
                return string.Join(" ", document.GetPages().SelectMany(page => page.GetWords()));
            }
        }

        private string ExtractTextFromEpub(string filepath)
        {
            EpubBook epubBook = EpubReader.ReadBook(filepath);
            return string.Join(" ", epubBook.ReadingOrder.Select(contentFile => contentFile.GetContentAsPlainText()));
        }

        private void IdentifyChapterIndices()
        {
            _chapterIndices = new Dictionary<int, int>();
            for (int i = 0; i < _words.Length; i++)
            {
                if (_words[i].StartsWith("Chapter", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(_words[i + 1], out int chapterNumber))
                    {
                        _chapterIndices[chapterNumber] = i;
                    }
                }
            }
        }

        private void PopulateChapterComboBox()
        {
            cmbChapters.Items.Clear();
            foreach (var chapter in _chapterIndices.Keys)
            {
                cmbChapters.Items.Add($"Chapter {chapter}");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_text))
            {
                _isPaused = false;
                _cancellationTokenSource = new CancellationTokenSource();
                int wpm = (int)numWpm.Value;
                Task.Run(() => RsvpReaderFunc(_words, wpm, _cancellationTokenSource.Token));
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            _isPaused = true;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            _isPaused = false;
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtJumpTo.Text, out int position))
            {
                _index = position;
                if (_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
                {
                    _cancellationTokenSource.Cancel();
                    _cancellationTokenSource = new CancellationTokenSource();
                    Task.Run(() => RsvpReaderFunc(_words, (int)numWpm.Value, _cancellationTokenSource.Token));
                }
            }
        }

        private void cmbChapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChapters.SelectedIndex != -1)
            {
                var selectedChapter = cmbChapters.SelectedIndex + 1; // Chapter numbers start from 1
                if (_chapterIndices.ContainsKey(selectedChapter))
                {
                    _index = _chapterIndices[selectedChapter];
                    if (_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
                    {
                        _cancellationTokenSource.Cancel();
                        _cancellationTokenSource = new CancellationTokenSource();
                        Task.Run(() => RsvpReaderFunc(_words, (int)numWpm.Value, _cancellationTokenSource.Token));
                    }
                }
            }
        }

        private async Task RsvpReaderFunc(string[] words, int wpm, CancellationToken token)
        {
            var delay = 60000 / wpm;

            while (_index < words.Length)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                if (_isPaused)
                {
                    await Task.Delay(100); // Check every 100ms if it's still paused
                    continue;
                }

                Invoke(new Action(() => lblRsvp.Text = words[_index]));
                _index++;
                await Task.Delay(delay);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }
        public void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public static class EpubContentFileExtensions
    {
        public static string GetContentAsPlainText(this EpubLocalTextContentFile contentFile)
        {
            return contentFile.Content;
        }
    }
    
}
