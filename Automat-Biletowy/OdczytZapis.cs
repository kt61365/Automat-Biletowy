using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AutomatBiletowy
{
    public static class OdczytZapis
    {
        public static void ZapiszTransakcjeDoPliku(Transakcja transakcja, string sciezkaPliku)
        {
            List<Transakcja> transakcje;
            string folder = Path.GetDirectoryName(sciezkaPliku);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (File.Exists(sciezkaPliku))
            {
                string json = File.ReadAllText(sciezkaPliku);
                transakcje = JsonSerializer.Deserialize<List<Transakcja>>(json) ?? new List<Transakcja>();
            }
            else
            {
                transakcje = new List<Transakcja>();
            }

            transakcje.Add(transakcja);
            string updatedJson = JsonSerializer.Serialize(transakcje, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(sciezkaPliku, updatedJson);
        }

        public static List<Transakcja> WczytajTransakcjeZPliku(string sciezkaPliku)
        {
            if (!File.Exists(sciezkaPliku))
            {
                return new List<Transakcja>();
            }

            string json = File.ReadAllText(sciezkaPliku);
            return JsonSerializer.Deserialize<List<Transakcja>>(json) ?? new List<Transakcja>();
        }
    }
}