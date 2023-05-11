using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IOPath = System.IO.Path;
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
            AddToStartup();
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

        private void AddToStartup()
        {
            string taskName = "MyAppStartup";
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
    }
};