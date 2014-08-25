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
using System.ComponentModel;

namespace AnimeManagement
{
    /// <summary>
    /// Interaktionslogik für Filter.xaml
    /// </summary>
    public partial class Filter : Window
    {
        private AnimeList animeList = AnimeList.getInstance();
        private static Filter instance = new Filter();

        private Filter()
        {
            InitializeComponent();
        }

        public static Filter getInstance()
        {
            return instance;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AnimeList filteredList = new AnimeList();
            filteredList.addAnimeToList(animeList.getAnimeList());
            MainWindow mWindow = Owner as MainWindow;
            
            if (checkBox1.IsChecked.Value)
            {
                filteredList.removeAnimeWhichIsNotInTheList(animeList.getGerSubAnime());
                
            }

            if (checkBox2.IsChecked.Value)
            {
                filteredList.removeAnimeWhichIsNotInTheList(animeList.getEngSubAnime());
            }

            if (checkBox3.IsChecked.Value)
            {
                filteredList.removeAnimeWhichIsNotInTheList(animeList.getJapDubAnime());
            }

            if (checkBox4.IsChecked.Value)
            {
                filteredList.removeAnimeWhichIsNotInTheList(animeList.getEngDubAnime());
            }

            if (checkBox5.IsChecked.Value)
            {               
                filteredList.removeAnimeWhichIsNotInTheList(animeList.getGerDubAnime());
            }

            if (!checkBox1.IsChecked.Value && !checkBox2.IsChecked.Value && !checkBox3.IsChecked.Value && !checkBox4.IsChecked.Value && !checkBox5.IsChecked.Value)
            {
                mWindow.listBox1.ItemsSource = animeList.getSortedAllTitle();
            }
            else
            {
                    mWindow.listBox1.ItemsSource = filteredList.getSortedAllTitle();
 
                
            }
            this.Hide();
        }

        public void setVisible()
        {
            this.Visibility = Visibility.Visible;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
           
        }
    }
}
