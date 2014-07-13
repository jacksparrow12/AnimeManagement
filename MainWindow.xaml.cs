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


namespace AnimeManagement
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AnimeList animeList = AnimeList.getInstance();
        Parser parser = Parser.getInstance();
        SaveToFile saveFile = SaveToFile.getInstance();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            image1.Source = null;
            image2.Source = null;
            string tmp = ((sender as System.Windows.Controls.ListBox).SelectedItem.ToString());
            AnimeList animeList = AnimeList.getInstance();
            Anime anime = animeList.getAnimeByTitle(tmp);
            try
            {
                if (anime.getPathImg().Contains("png") || anime.getPathImg().Contains("jpg"))
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
                else
                {
                    image1.Source = new BitmapImage(new Uri(("pack://application:,,,/Images/NoImageFound.jpg")));
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
   
        }

        private void OpenMenu_Click(object sender, RoutedEventArgs e)
        {          
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            string path = dlg.SelectedPath;
            if (!path.Equals(""))
            {
                parser.processDirectory(path, 0);
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

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
           //To do
        }

        private void updateList()
        {
            listBox1.ItemsSource = animeList.getAllTitle();
        }
    }
}
