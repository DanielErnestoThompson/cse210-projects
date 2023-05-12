﻿using System;
using System.IO;
using IOPath = System.IO.Path;
using System.Windows;
using System.Reflection;
using Microsoft.Win32.TaskScheduler;
using System.Windows.Controls;

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
            AddToStartup();
        }

        private void AddToStartup()
        {
            try
            {
                string taskName = "ThoughtLog";
                string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

                using (Microsoft.Win32.TaskScheduler.TaskService ts = new Microsoft.Win32.TaskScheduler.TaskService())
                {
                    Microsoft.Win32.TaskScheduler.Task task = ts.FindTask(taskName);
                    if (task == null)
        {
                    Microsoft.Win32.TaskScheduler.TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Starts my app when the user logs in";

                    td.Triggers.Add(new Microsoft.Win32.TaskScheduler.LogonTrigger());

                    td.Actions.Add(new Microsoft.Win32.TaskScheduler.ExecAction(appPath, null, null));

                    ts.RootFolder.RegisterTaskDefinition(taskName, td);
        }
                }
            }
                catch (Exception ex)
            {
                // Log the exception or show a message box
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        private string GetJournalFilePath()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string journalDirectory = IOPath.Combine(documentsPath, "JournalApp");

            if (!Directory.Exists(journalDirectory))
            {
                Directory.CreateDirectory(journalDirectory);
            }

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
        }
    }
};