using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Windows.Controls.Primitives;
using System.Diagnostics;
using System.IO;


namespace AnimeManagement
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AnimeList animeList = AnimeList.getInstance();
        private Parser parser = Parser.getInstance();
        private SaveToFile saveFile = SaveToFile.getInstance();
        private RemoveFullPathFromFolder pathRemover = RemoveFullPathFromFolder.getInstance();
        private List<string> pathToAnimeFolder = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            image1.Source = null;           //This image field is for pictures where the width is bigger than the height
            image2.Source = null;           //This image field is for pictures where the width is smaller than the height
            string tmp = ((sender as System.Windows.Controls.ListBox).SelectedItem.ToString());
            Anime anime = animeList.getAnimeByTitle(tmp);
            try
            {
                if (anime.getPathImg().Contains("png") || anime.getPathImg().Contains("jpg"))
                {
                    try
                    {
                        BitmapImage img = new BitmapImage(new Uri(anime.getPathImg()));
                        if (img.Width > img.Height)
                        {
                            image1.Source = img;
                        }
                        else
                        {
                            image2.Source = img;
                        }
                    }
                    catch(DirectoryNotFoundException)
                    {                       
                       image2.Source = new BitmapImage(new Uri(("pack://application:,,,/Resources/NewNoImageFound1.PNG")));
                    }
                   

                }
                else
                {
                         image2.Source = new BitmapImage(new Uri(("pack://application:,,,/Resources/NewNoImageFound1.PNG")));
                }

            }
            catch (UriFormatException)
            {

            }
            fansub.Text = anime.buildStringOfFansubs();
            episode.Text = anime.getEpisode().ToString();
            title.Text = anime.getTitle();
            subtitle.Text = anime.buildStringOfSub();
            voice.Text = anime.buildStringOfVoice();
            source.Text = anime.buildStringOfSource();
            description.Text = anime.getDescription();   
            if (anime.getPathOfEpisode().Length != 0)
            {
                listBoxOfEpisode.ItemsSource = pathRemover.removeFullPathFromFiles(anime.getPathOfEpisode());   //remove full path from media files
            }
            else
            {
                listBoxOfEpisode.ItemsSource = anime.getPathOfEpisode();
            }
            
        }

        private void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            OpenFromFile animeParser = OpenFromFile.getInstance();
            System.Windows.Forms.OpenFileDialog load = new System.Windows.Forms.OpenFileDialog();
            load.InitialDirectory = "C:\\";
            load.ShowDialog();
            string path = load.FileName;
            if (!path.Equals(""))
            {
                animeParser.readAnimesFromFile(path);
            }
            updateList();
        }

        private void SaveMenu_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "ani files (*.ani)|*.ani|All files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                saveFile.saveAnimeListToFile(saveFileDialog.FileName);
            }
        }

        private void LoadMenu_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            string path = dlg.SelectedPath;
            if (!path.Equals(""))
            {
                parser.processDirectory(path, 0, null);
            }
            pathToAnimeFolder.Add(path);
            updateList();
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AboutMenu_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("\tVersion 0.5\t\n\tCreated by iPek\t");
        }

        private void updateList()
        {
            listBox1.ItemsSource = animeList.getSortedAllTitle();
        }


        private void listBoxOfEpisode_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string mediaFile = ((sender as System.Windows.Controls.ListBox).SelectedItem.ToString());
                mediaFile = pathRemover.addFullPathToFile(mediaFile); //Add full path to media file
                if (!mediaFile.Equals("No media file found"))
                {

                    Process.Start(mediaFile);
                }                
            }
            catch
            {
               
            }

        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            animeList.clearList();
            if (pathToAnimeFolder != null)
            {
                for (int i = 0; i < pathToAnimeFolder.Count(); i++)
                {
                    parser.processDirectory(pathToAnimeFolder.ToArray()[i], 0, null);
                }
                
            }           
            updateList();
           
        }
    }
}
