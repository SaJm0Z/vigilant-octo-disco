using System;
using System.Collections.Generic;
using System.Linq;

namespace Salon
{
    class Program
    {
        private static Auto Auto;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Pokaz liste");
                Console.WriteLine("2. Dodaj");
                Console.WriteLine("3. Usun");
                Console.WriteLine("4. Zglos sprzedaz");
                Console.WriteLine("5. Archiwum sprzedanych");
                Console.WriteLine("6. Usun z archiwum");
                Console.WriteLine("0. Wyjscie");

                string wyb = Console.ReadLine();
                if (wyb == "0")
                {
                    Environment.Exit(0);
                }
                else
                {
                    switch (wyb)
                    {
                        case "1":
                            Console.Clear();
                            WczytajAuta();
                            break;


                        case "2":
                            Console.Clear();
                            Console.WriteLine("Marka: ");
                            string marka = Console.ReadLine();
                            Console.WriteLine("Model: ");
                            string model = Console.ReadLine();
                            Console.WriteLine("Rok produkcji: ");
                            string rok = Console.ReadLine();
                            Console.WriteLine("Paliwo: ");
                            string paliwo = Console.ReadLine();
                            Console.WriteLine("Pojemmnosc silnika: ");
                            string silnik = Console.ReadLine();
                            Console.WriteLine("Moc w KM: ");
                            string moc = Console.ReadLine();
                            Console.WriteLine("Przebieg: ");
                            string przebieg = Console.ReadLine();
                            Console.WriteLine("Kraj pochodzenia: ");
                            string kraj = Console.ReadLine();
                            Console.WriteLine("Cena: ");
                            string cena = Console.ReadLine();

                            Auto = new Auto(marka, model, rok, paliwo, silnik, moc, przebieg, kraj, cena);

                            Console.Clear();

                            Console.WriteLine("DODANO: ");
                            Console.WriteLine($"Marka:{Auto.Marka}  Model:{Auto.Model}  Rok Produkcji: {Auto.RokProd} ");
                            Console.WriteLine($"Paliwo: {Auto.Paliwo}  Silnik: {Auto.Silnik}  Moc: {Auto.Moc} ");
                            Console.WriteLine($"Przebieg: {Auto.Przebieg}  Pochodzenie: {Auto.KrajPochodzenia} ");
                            Console.WriteLine($"Cena: {Auto.Cena}");
                            Dane Dane = new Dane();
                            Dane.DodajAuto(Auto);


                            break;

                        case "3":
                            Console.Clear();
                            WczytajAuta();
                            Console.WriteLine("Podaj nr katalogowy: ");
                            string nr = Console.ReadLine();
                            Dane dane = new Dane();
                            dane.UsunAuto(int.Parse(nr));
                            Console.Clear();
                            WczytajAuta();
                            break;

                        case "4":
                            Console.Clear();
                            WczytajAuta();
                            Console.WriteLine("Podaj nr katalogowy: ");
                            string nk = Console.ReadLine();
                            Dane dane1 = new Dane();
                            dane1.ZabierzAuto(int.Parse(nk));

                            break;

                        case "5":
                            Console.Clear();
                            WczytajSprzedane();
                            break;

                        case "6":
                            Console.Clear();
                            WczytajSprzedane();
                            Console.WriteLine("Podaj nr umowy: ");
                            string nu = Console.ReadLine();
                            Dane dane2 = new Dane();
                            dane2.UsunSprzedany(int.Parse(nu));
                            Console.Clear();
                            WczytajSprzedane();
                            break;
                    }

                    Console.ReadKey();
                }
            }
        }

       

        static void WczytajAuta()
        {
            Dane dane = new Dane();
            List<Auto> auta = dane.ListaAut().ToList();
            foreach(Auto auto in auta)
            {
                Console.WriteLine($"NK:{auto.NrKatalog}: {auto.Marka} {auto.Model} Poj:{auto.Silnik} {auto.Moc} {auto.Paliwo} {auto.RokProd} {auto.Przebieg}");
            }
        }
        static void WczytajSprzedane()
        {
            Dane dane = new Dane();
            List<Sprzedane> sprzedane = dane.ListaSprzedanych().ToList();
            foreach (Sprzedane sprzedane1 in sprzedane)
            {
                Console.WriteLine($"Nr Umowy:{sprzedane1.NrUmowy} => {sprzedane1.Kupiec} {sprzedane1.Marka} {sprzedane1.Model} Poj:{sprzedane1.Silnik} {sprzedane1.Moc} {sprzedane1.Paliwo} {sprzedane1.RokProd} {sprzedane1.Przebieg}");
            }
        }
    }
}
