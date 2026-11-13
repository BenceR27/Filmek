using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Filmek
{
    class Film
    {
        public string Cim { get; set; }
        public string Mufaj { get; set; }
        public int Hossz { get; set; }
        public double Ertekeles { get; set; }

        public Film(string cim, string mufaj, int hossz, double ertekeles)
        {
            this.Cim = cim;
            this.Mufaj = mufaj;
            this.Hossz = hossz;
            this.Ertekeles = ertekeles;
        }
    }

    public partial class MainWindow : Window
    {
        List<Film> filmek = new List<Film>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void filmekBetoltese(object sender, RoutedEventArgs e)
        {
            filmek.Clear();

            filmek.Add(new Film("Csillagok háborúja", "sci-fi", 121, 8.6));
            filmek.Add(new Film("Titanic", "dráma", 195, 7.8));
            filmek.Add(new Film("A Gyűrűk Ura", "fantasy", 201, 8.8));
            filmek.Add(new Film("Mátrix", "sci-fi", 136, 8.7));
            filmek.Add(new Film("Shrek", "animáció", 90, 7.9));

            colMufaj.Visibility = Visibility.Visible;
            colHossz.Visibility = Visibility.Visible;
            colErtekeles.Visibility = Visibility.Visible;

            dgFilmek.ItemsSource = filmek;
            dgFilmek.Items.Refresh();

            pbFolyamat.Value = 30;
        }

        private void hanyFilm(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Filmek száma: {filmek.Count} db");
        }

        private void leghosszabbFilm(object sender, RoutedEventArgs e)
        {
            if (filmek.Count == 0) return;

            Film max = null;
            foreach (var f in filmek)
            {
                if (max == null || f.Hossz > max.Hossz)
                {
                    max = f;
                }
            }
            MessageBox.Show($"Leghosszabb film: {max.Cim} ({max.Hossz} perc)");
        }

        private void atlagErtekeles(object sender, RoutedEventArgs e)
        {
            if (filmek.Count == 0) return;

            double osszeg = 0;
            foreach (var f in filmek)
            {
                osszeg += f.Ertekeles;
            }
            double atlag = osszeg / filmek.Count;
            MessageBox.Show($"Átlag értékelés: {atlag:0.00}");
        }

        private void csakSciFi(object sender, RoutedEventArgs e)
        {
            List<Film> scifik = new List<Film>();
            foreach (var f in filmek)
            {
                if (f.Mufaj == "sci-fi")
                {
                    scifik.Add(f);
                }
            }
            dgFilmek.ItemsSource = scifik;
            dgFilmek.Items.Refresh();
        }

        private void csakCimek(object sender, RoutedEventArgs e)
        {
            colMufaj.Visibility = Visibility.Collapsed;
            colHossz.Visibility = Visibility.Collapsed;
            colErtekeles.Visibility = Visibility.Collapsed;
        }

        private void rendezesCimSzerint(object sender, RoutedEventArgs e)
        {
            filmek.Sort((a, b) => a.Cim.CompareTo(b.Cim));
            dgFilmek.ItemsSource = filmek;
            dgFilmek.Items.Refresh();
        }

        private void dgFilmek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgFilmek.SelectedItem is Film kivalasztott)
            {
                MessageBox.Show($"Kiválasztott film: {kivalasztott.Cim}\nÉrtékelés: {kivalasztott.Ertekeles}");
            }
        }
    }
}
