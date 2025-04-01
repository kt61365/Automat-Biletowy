using System;
using System.Collections.Generic;

namespace AutomatBiletowy
{
    public class Transakcja
    {
        public decimal Kwota { get; set; }
        public List<Bilet> Bilety { get; set; }

        public Transakcja(decimal kwota, List<Bilet> bilety)
        {
            Kwota = kwota;
            Bilety = bilety;
        }

        public static Transakcja SprzedajBilet(string typBiletu, int liczbaBiletow)
        {
            var bilety = new List<Bilet>();
            decimal suma = 0;

            for (int i = 0; i < liczbaBiletow; i++)
            {
                var numer = i + 1;
                var dataWydania = DateTime.Now;
                var bilet = new Bilet(numer, typBiletu, dataWydania);
                bilety.Add(bilet);
                suma += bilet.PobierzCene();
            }

            return new Transakcja(suma, bilety);
        }

        public decimal PobierzKwote() => Kwota;

        public DateTime PobierzDateTransakcji() => Bilety.Count > 0 ? Bilety[0].DataWydania : DateTime.MinValue;

        public override string ToString() => $"Kwota: {Kwota}, Data: {PobierzDateTransakcji()}, Liczba biletów: {Bilety.Count}";
    }
}