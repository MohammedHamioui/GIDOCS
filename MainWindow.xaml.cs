using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GIDOCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Games> DatabaseGames { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Create() {
            using (Datacontext context= new Datacontext()) {
                var Title = TitleTextBox.Text;
                var Genre = GenreTextBox.Text;
                var Developer = DeveloperTextBox.Text;
                var Publisher = PublisherTextBox.Text;

                if ((Title != null) && (Genre != null) && (Developer != null) && (Publisher != null)) {
                    context.VideoGames.Add(new Games() { Title = Title, Genre = Genre, Developer = Developer, Publisher = Publisher });
                    MessageBox.Show("Game added!");
                    context.SaveChanges();
                }
            }
        }

        public void Read()
        {
            using (Datacontext context = new Datacontext())
            {
                DatabaseGames = context.VideoGames.ToList();
                ItemList.ItemsSource = DatabaseGames;
            }
        }

        public void Update()
        {
            using (Datacontext context = new Datacontext())
            {
                Games selectedGame = ItemList.SelectedItem as Games;
                
                var Title = TitleTextBox.Text;
                var Genre = GenreTextBox.Text;
                var Developer = DeveloperTextBox.Text;
                var Publisher = PublisherTextBox.Text;

                if ((Title != null) && (Genre != null) && (Developer != null) && (Publisher != null))
                {
                    Games game = context.VideoGames.Find(selectedGame.Id);
                    game.Title = Title;
                    game.Genre = Genre;
                    game.Developer = Developer;
                    game.Publisher = Publisher;
                    MessageBox.Show("Game succesfully updated!");
                    context.SaveChanges();
                }
            }
        }

        public void Delete()
        {
            using (Datacontext context = new Datacontext()) {
                 Games selectedGame = ItemList.SelectedItem as Games;

                if (selectedGame != null)
                {
                    Games game = context.VideoGames.Single(x=> x.Id == selectedGame.Id);
                    context.Remove(game);
                    MessageBox.Show("Game succesfully deleted!");
                    context.SaveChanges();
                }
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ItemList.Items.Clear();
        }
    }
}
