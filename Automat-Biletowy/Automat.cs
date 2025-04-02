//klasa do potencjalnej rozbudowy
namespace AutomatBiletowy
{
    public class Automat
    {
        public string Lokalizacja { get; set; }
        public bool Status { get; set; }
        public int LiczbaSprzedanychBiletow { get; set; }

        public Automat(string lokalizacja)
        {
            Lokalizacja = lokalizacja;
            Status = true;
            LiczbaSprzedanychBiletow = 0;
        }
    }
}