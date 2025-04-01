using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AutomatBiletowy
{
    public partial class MainWindow : Window
    {
        private static readonly Automat automat = new Automat("Bielsko-Biała, Piłsudskiego");
        private static readonly string sciezkaPliku = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "dane", "transakcje.json");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void KupBiletButton_Click(object sender, RoutedEventArgs e)
        {
            var kupBiletWindow = new KupBiletWindow(sciezkaPliku, WynikTextBox)
            {
                Owner = this
            };
            kupBiletWindow.ShowDialog();
        }

        private void WszystkieTransakcjeButton_Click(object sender, RoutedEventArgs e)
        {
            var transakcje = OdczytZapis.WczytajTransakcjeZPliku(sciezkaPliku);
            StringBuilder wynik = new StringBuilder();
            Zapytania.WyświetlWszystkieTransakcje(transakcje, wynik);
            WynikTextBox.Text = wynik.ToString();
        }

        private void TransakcjeZDniaButton_Click(object sender, RoutedEventArgs e)
        {
            var dataWindow = new DataWindow(sciezkaPliku, WynikTextBox)
            {
                Owner = this
            };
            dataWindow.ShowDialog();
        }

        private void WynikiMiesiacButton_Click(object sender, RoutedEventArgs e)
        {
            var transakcje = OdczytZapis.WczytajTransakcjeZPliku(sciezkaPliku);
            StringBuilder wynik = new StringBuilder();
            Zapytania.WyświetlSprzedażZaOstatniMiesiąc(transakcje, wynik);
            WynikTextBox.Text = wynik.ToString();
        }
    }
}