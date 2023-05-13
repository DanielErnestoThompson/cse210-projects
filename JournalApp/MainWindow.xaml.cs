using System;
using System.IO;
using System.Collections.Generic;
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
        private PromptGenerator promptGenerator;

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

            // Initialize prompt generator
            promptGenerator = new PromptGenerator();

            // Display date, time, entry number, and a writing prompt
            UpdateInfoTextBlockAndJournalEntryTextBox();
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

        private void UpdateInfoTextBlockAndJournalEntryTextBox()
        {
            int entryNumber = Directory.GetFiles(journalDirectory).Length + 1;
            string dateTimeNow = DateTime.Now.ToString();
            string prompt = promptGenerator.GetRandomPrompt();
            infoTextBlock.Text = $"Date & Time: {dateTimeNow}\nJournal Entry Number: {entryNumber}";
            journalEntryTextBox.Text = $"Prompt: {prompt}\n";
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

            // Update date, time, entry number, and a writing prompt
            UpdateInfoTextBlockAndJournalEntryTextBox();
        }
    }

    public class PromptGenerator
    {
        private readonly List<string> prompts;
        private readonly Random rng;

        public PromptGenerator()
        {
            rng = new Random();

            prompts = new List<string>
            {
                "What was the best part of your day?",
                "Describe a challenge you faced today.",
                "Write about something you learned today.",
                "How did you make someone else happy today?",
                "What's something you're looking forward to?",
                // Add as many prompts as you like...
            };
        }

        public string GetRandomPrompt()
        {
            int index = rng.Next(prompts.Count);
            return prompts[index];
        }
    }
}
