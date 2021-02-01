using FilmListHelperController.Controllers;
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

namespace FilmListHelperView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FilmCRUDController _filmCRUDController = new FilmCRUDController(); 
        public MainWindow()
        {
            InitializeComponent();
            PopulateFilms();
            PopulateFilmFields();
        }

        public void PopulateFilms()
        {
            ListViewFilms.ItemsSource = _filmCRUDController.GetFilms();
        }

        public void ListBoxFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewFilms.SelectedItem != null)
            {
                _filmCRUDController.SetSelectedFilm(ListViewFilms.SelectedItem);
                PopulateFilmFields();
            }
        }

        public void PopulateFilmFields()
        {
            if (_filmCRUDController.SelectedFilm != null)
            {
                FilmTitle.Text = _filmCRUDController.SelectedFilm.FilmTitle;
                Date.Text = _filmCRUDController.SelectedFilm.Date.ToString();
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string title = TextBoxFilmTitle.Text;
        
            if(_filmCRUDController.AddNewFilm(title) == true)
            {
                MessageBox.Show("Film saved successfully");
                PopulateFilms();
            }
            else
            {
                MessageBox.Show("Film already exists in your list!");
            }
            Reset();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            _filmCRUDController.DeleteFilm(_filmCRUDController.SelectedFilm.FilmId);
            MessageBox.Show("Film deleted successfully");
            PopulateFilms();
            Reset();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            string title = FilmTitle.Text;
            _filmCRUDController.UpdateFilm(_filmCRUDController.SelectedFilm.FilmId, title);
            MessageBox.Show("Film updted successfully");
            PopulateFilms();
            Reset();

        }

        public void Reset()
        {
            TextBoxFilmTitle.Text = "";
            FilmTitle.Text = "";
            Date.Text = "";
        }
    }
}
