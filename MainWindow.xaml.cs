using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace Stormworks_Save_Transfer {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>

    public class Test { }

    public partial class MainWindow : Window {
        private const string INVALIDE_ATTRIBUTE_IDENTIFIER = "SanitizedAttribute_";
        private const string DEFAULT_PATH = @"C:\Users\maxen\AppData\Roaming\Stormworks\saves";

        private SaveData sourceData;
        private SaveData destinationData;
        private string destinationPath;


        public MainWindow() {
            InitializeComponent();
            UpdateDataDisplay();
            UpdateUIState();
        }

        #region OnClick_Methods
        private void OpenSourceSave_OnClick(object sender, RoutedEventArgs e) {
            (XDocument sourceSave, _) = OpenFile();

            if (sourceSave != null) {
                sourceData = new SaveData(sourceSave);
            }
            UpdateDataDisplay();
            UpdateUIState();
        }

        private void OpenDestinationSave_OnClick(object sender, RoutedEventArgs e) {
            (XDocument destinationSave, string filePath)= OpenFile();

            destinationPath = filePath;

            if (destinationSave != null) {
                destinationData = new SaveData(destinationSave);
            }
            UpdateDataDisplay();
            UpdateUIState();
        }

        private void CopyDataButton_OnClick(object sender, RoutedEventArgs e) {
            destinationData.CopyDataFrom(sourceData, CopyGameData.IsChecked.Value, CopyDifficultySetting.IsChecked.Value, CopyGameModeSetting.IsChecked.Value);
            UpdateDataDisplay();
        }

        private void ExportButton_OnClick(object sender, RoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to export your progress data from the source save to the destination save ?\n\nAlways make a backup of your destination save before overwriting it with this tool, anything done within this save will be lost.", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Stop);
            
            if (result == MessageBoxResult.Yes) {
                WriteDestinationFile();
            }
        }

        private void EnableEdit_OnClick(object sender, RoutedEventArgs e) {
            MessageBoxResult result = MessageBox.Show("You are going to enable save edit, you will be allowed to modify any visible value of your final save file, but you can break it if done wrong.\n\nDo you want to proceed ?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.OK) {

            }
        }

        private void Checkbox_OnClick(object sender, RoutedEventArgs e) {
            UpdateUIState();
        }
        #endregion

        private void UpdateDataDisplay() {
            if (sourceData != null) {
                sourceGameData.ItemsSource = sourceData.GameData;
                sourceDifficultySetting.ItemsSource = sourceData.DifficultySettings;
                sourceGameModeSetting.ItemsSource = sourceData.GameModeSettings;
            } else {
                sourceGameData.ItemsSource = null;
                sourceGameData.ItemsSource = null;
                sourceGameData.ItemsSource = null;
            }

            if (destinationData != null) {
                destinationGameData.ItemsSource = destinationData.GameData;
                destinationDifficultySetting.ItemsSource = destinationData.DifficultySettings;
                destinationGameModeSetting.ItemsSource = destinationData.GameModeSettings;
            } else {
                destinationGameData.ItemsSource = null;
                destinationDifficultySetting.ItemsSource = null;
                destinationGameModeSetting.ItemsSource = null;
            }

            if (sourceData != null && destinationData != null && sourceData.Seed != destinationData.Seed) {
                MessageBox.Show("The seed of the destination save file does not match the seed from the source save file. Proceed at your own risk !", "Warning : Seed not matched", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdateUIState() {
            sourceFile_label.Foreground = sourceData == null ? Brushes.Red : Brushes.Green;
            sourceFile_label.Content = sourceData == null ? "No file loaded" : "File loaded !";

            destinationFile_label.Foreground = destinationData == null ? Brushes.Red : Brushes.Green;
            destinationFile_label.Content = destinationData == null ? "No file loaded" : "File loaded !";

            copyButton.IsEnabled = sourceData != null && destinationData != null;
            exportButton.IsEnabled = destinationData != null;

            dataArrow.Visibility = CopyGameData.IsChecked.Value ? Visibility.Visible : Visibility.Hidden;
            difficultyArrow.Visibility = CopyDifficultySetting.IsChecked.Value ? Visibility.Visible : Visibility.Hidden;
            modeArrow.Visibility = CopyGameModeSetting.IsChecked.Value ? Visibility.Visible : Visibility.Hidden;
        }

        private (XDocument, string) OpenFile() {
            OpenFileDialog openFileDial = new OpenFileDialog();
            openFileDial.Filter = "*.xml|*.xml";

            string defaultPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Stormworks", "saves");
            openFileDial.Title = "Open scene.xml";
            openFileDial.InitialDirectory = defaultPath;
            //openFileDial.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + separator + "Stormworks";

            if (openFileDial.ShowDialog() == true) {
                string filePath = openFileDial.FileName;
                string content = File.ReadAllText(filePath);

                // Needed to fix tags params starting with a number
                content = SanitizeTagsAttributes(content);

                System.Diagnostics.Debug.WriteLine("Open : " + filePath);

                return (XDocument.Parse(content), filePath);
            }
            return (null, null);
        }

        private void WriteDestinationFile() {
            string content = UnSanitizeTagsAttributes(destinationData.ToString());
            content = content.Replace("True", "true");
            content = content.Replace("False", "false");
            File.WriteAllText(destinationPath, $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n{content}");

            MessageBox.Show("Success ! Enjoy your up-to-date save !", "Success", MessageBoxButton.OK);
        }

        private string SanitizeTagsAttributes(string xml) {
            return Regex.Replace(xml, "[0-9]+=", delegate (Match m) {
                return INVALIDE_ATTRIBUTE_IDENTIFIER + m.Value;
            });
        }

        private string UnSanitizeTagsAttributes(string xml) {
            return Regex.Replace(xml, INVALIDE_ATTRIBUTE_IDENTIFIER, "");
        }
    }
}
