using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace AutomatBiletowy
{
    public partial class DataWindow : Window
    {
        private readonly string sciezkaPliku;
        private readonly TextBox wynikTextBox;

        public DataWindow(string sciezkaPliku, TextBox wynikTextBox)
        {
            InitializeComponent();
            this.sciezkaPliku = sciezkaPliku;
            this.wynikTextBox = wynikTextBox;
        }

        private void ZatwierdzButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(DataBox.Text, out DateTime data))
            {
                MessageBox.Show("Podaj poprawną datę w formacie RRRR-MM-DD!");
                return;
            }

            var transakcje = OdczytZapis.WczytajTransakcjeZPliku(sciezkaPliku);
            StringBuilder wynik = new StringBuilder();
            Zapytania.WyświetlTransakcjeZDnia(transakcje, data, wynik);
            wynikTextBox.Text = wynik.ToString();
            Close();
        }
    }
}