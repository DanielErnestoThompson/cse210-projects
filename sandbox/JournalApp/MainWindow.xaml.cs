﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JournalApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string GetJournalFilePath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string journalDirectory = Path.Combine(documentsPath, "JournalApp");

            if (!Directory.Exists(journalDirectory))
            {
                Directory.CreateDirectory(journalDirectory);
            }

            int entryNumber = Directory.GetFiles(journalDirectory).Length + 1;
            string journalFileName = $"JournalEntry_{entryNumber}.txt";
            string journalFilePath = Path.Combine(journalDirectory, journalFileName);

            return journalFilePath;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string journalFilePath = GetJournalFilePath();
            string journalContent = JournalEntryTextBox.Text;

            File.WriteAllText(journalFilePath, journalContent);
            MessageBox.Show("Journal entry saved successfully.", "Journal Saved", MessageBoxButton.OK, MessageBoxImage.Information);

            JournalEntryTextBox.Clear();
        }

    }
}