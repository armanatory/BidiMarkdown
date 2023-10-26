using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Markdig;


namespace BidiMarkdown.App
{
    public partial class MainWindow : Window
    {
        private string _currentFileName { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            // Set the initial font family and size of the RichTextBox
            RichTextBox.FontFamily = (FontFamily)FontFamilyComboBox.SelectedItem;
            RichTextBox.FontSize = double.Parse(((ComboBoxItem)FontSizeComboBox.SelectedItem).Content.ToString());
            // Set the initial time of the StatusBar
            TimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
            // Start a timer to update the time every second
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Open_Click(sender, e);
        }


        private void SaveAsCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Open_Click(sender, e);
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the time of the StatusBar
            TimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Get the current text of the RichTextBox
            var textRange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
            var text = textRange.Text;
            // Convert the text to HTML format
            var html = Markdown.ToHtml(text);
            html = html.Replace("\r\n", "<br/>");
            html = $"<html><head><style>body {{font-family: {RichTextBox.FontFamily}; font-size: {RichTextBox.FontSize}px;}}</style></head><body>{html}</body></html>";
            // Navigate the WebBrowser to the HTML content
            WebBrowser.NavigateToString(html);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            // Create an OpenFileDialog
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            // Set the filter for md files
            openFileDialog.Filter = "md files (*.md)|*.md|All files (*.*)|*.*";
            // Display OpenFileDialog by calling ShowDialog method
            var result = openFileDialog.ShowDialog();
            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                _currentFileName = openFileDialog.FileName;
                var textRange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
                textRange.Text = System.IO.File.ReadAllText(_currentFileName);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Check if the current file name is not null or empty
            if (!string.IsNullOrEmpty(_currentFileName))
            {
                // Get the text from the RichTextBox
                var textRange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
                var text = textRange.Text;
                // Write the text to the file
                System.IO.File.WriteAllText(_currentFileName, text);
            }
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            // Create a SaveFileDialog
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            // Set the filter for md files
            saveFileDialog.Filter = "md files (*.md)|*.md|All files (*.*)|*.*";
            // Display SaveFileDialog by calling ShowDialog method
            var result = saveFileDialog.ShowDialog();
            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Save document
                var filename = saveFileDialog.FileName;
                var textRange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
                var text = textRange.Text;
                System.IO.File.WriteAllText(filename, text);
                // Update current file name
                _currentFileName = filename;
            }
        }



    }
}
