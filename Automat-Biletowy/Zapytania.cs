using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomatBiletowy
{
    public static class Zapytania
    {
        private const string wyjscie = "  Bilet nr: {0} | Typ: {1} | Cena: {2} zł | Data wydania: {3}";

        public static void WyświetlWszystkieTransakcje(List<Transakcja> transakcje, StringBuilder wynik)
        {
            if (!transakcje.Any())
            {
                wynik.AppendLine("Brak zapisanych transakcji.");
                return;
            }

            wynik.AppendLine("Zapisane transakcje:");
            foreach (var transakcja in transakcje)
            {
                wynik.AppendLine($"Transakcja: {transakcja.PobierzDateTransakcji()} | Kwota: {transakcja.PobierzKwote()} zł");
                foreach (var bilet in transakcja.Bilety)
                {
                    wynik.AppendLine(string.Format(wyjscie, bilet.Numer, bilet.Typ, bilet.Cena, bilet.DataWydania));
                }
                wynik.AppendLine();
            }
        }

        public static void WyświetlTransakcjeZDnia(List<Transakcja> transakcje, DateTime data, StringBuilder wynik)
        {
            var transakcjeZDnia = transakcje.Where(t => t.PobierzDateTransakcji().Date == data);
            if (!transakcjeZDnia.Any())
            {
                wynik.AppendLine("Brak transakcji dla podanej daty.");
                return;
            }

            wynik.AppendLine($"Transakcje z dnia {data.ToShortDateString()}:");
            foreach (var transakcja in transakcjeZDnia)
            {
                wynik.AppendLine($"Transakcja: {transakcja.PobierzDateTransakcji()} | Kwota: {transakcja.PobierzKwote()} zł");
                foreach (var bilet in transakcja.Bilety)
                {
                    wynik.AppendLine(string.Format(wyjscie, bilet.Numer, bilet.Typ, bilet.Cena, bilet.DataWydania));
                }
                wynik.AppendLine();
            }
        }

        public static void WyświetlSprzedażZaOstatniMiesiąc(List<Transakcja> transakcje, StringBuilder wynik)
        {
            DateTime pierwszyDzienMiesiaca = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var transakcjeOMiesiac = transakcje.Where(t => t.PobierzDateTransakcji() >= pierwszyDzienMiesiaca);

            int liczbaBiletow = transakcjeOMiesiac.Sum(t => t.Bilety.Count);
            decimal lacznaKwota = transakcjeOMiesiac.Sum(t => t.PobierzKwote());

            wynik.AppendLine("Sprzedaż w ostatnim miesiącu:");
            wynik.AppendLine($"  Liczba biletów: {liczbaBiletow}");
            wynik.AppendLine($"  Łączna kwota: {lacznaKwota} zł");
        }
    }
}