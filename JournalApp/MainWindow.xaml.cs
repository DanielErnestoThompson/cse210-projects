using System;
using System.IO;
using IOPath = System.IO.Path;
using System.Windows;
using System.Reflection;
using System.Windows.Controls;
using Microsoft.Win32;

namespace JournalApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string journalDirectory;

        public MainWindow()
        {
            InitializeComponent();
            AddToStartup();

            // Create journal directory if it doesn't exist
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            journalDirectory = IOPath.Combine(documentsPath, "JournalApp");
            if (!Directory.Exists(journalDirectory))
            {
                Directory.CreateDirectory(journalDirectory);
            }

            // Display date, time, and entry number
            UpdateInfoTextBlock();
        }

        private void AddToStartup()
        {
            string runKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
            string appName = "ThoughtLog";
            string appPath = Assembly.GetExecutingAssembly().Location;

            using (RegistryKey runKey = Registry.CurrentUser.OpenSubKey(runKeyPath, writable: true))
            {
                if (runKey == null)
                {
                    MessageBox.Show("Unable to open registry key.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (runKey.GetValue(appName) as string != appPath)
                {
                    runKey.SetValue(appName, appPath);
                }
            }
        }

        private void UpdateInfoTextBlock()
        {
            int entryNumber = Directory.GetFiles(journalDirectory).Length + 1;
            string dateTimeNow = DateTime.Now.ToString();
            infoTextBlock.Text = $"Date & Time: {dateTimeNow}\nJournal Entry Number: {entryNumber}";
        }

        private string GetJournalFilePath()
        {
            int entryNumber = Directory.GetFiles(journalDirectory).Length + 1;
            string journalFileName = $"JournalEntry_{entryNumber}.txt";
            string journalFilePath = IOPath.Combine(journalDirectory, journalFileName);

            return journalFilePath;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string journalFilePath = GetJournalFilePath();
            string journalContent = journalEntryTextBox.Text;

            File.WriteAllText(journalFilePath, journalContent);
            MessageBox.Show("Journal entry saved successfully.", "Journal Saved", MessageBoxButton.OK, MessageBoxImage.Information);

            journalEntryTextBox.Clear();

            // Update date, time, and entry number
            UpdateInfoTextBlock();
        }
    }
};
