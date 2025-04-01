using System;

namespace AutomatBiletowy
{
    public class Bilet
    {
        public int Numer { get; set; }
        public string Typ { get; set; }
        public decimal Cena { get; set; }
        public DateTime DataWydania { get; set; }

        public Bilet(int numer, string typ, DateTime dataWydania)
        {
            Numer = numer;
            Typ = typ;
            Cena = typ == "Normalny" ? 3 : 2;
            DataWydania = dataWydania;
        }

        public decimal PobierzCene() => Cena;

        public override string ToString() => $"Bilet nr {Numer}, Typ: {Typ}, Cena: {Cena} zł, Data wydania: {DataWydania}";
    }
}