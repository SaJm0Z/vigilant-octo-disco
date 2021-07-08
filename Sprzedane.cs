using System;
using System.Collections.Generic;
using System.Text;

namespace Salon
{
    class Sprzedane
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string RokProd { get; set; }
        public string Paliwo { get; set; }
        public string Silnik { get; set; }
        public string Moc { get; set; }
        public string Przebieg { get; set; }
        public string KrajPochodzenia { get; set; }
        public string Kupiec { get; set; }
        public string NrUmowy { get; set; }


        public Sprzedane(string marka, string model, string rok, string paliwo, string silnik, string moc, string przebieg, string kraj, string kupiec, string nu)
        {
            Marka = marka;
            Model = model;
            RokProd = rok;
            Paliwo = paliwo;
            Silnik = silnik;
            Moc = moc;
            Przebieg = przebieg;
            KrajPochodzenia = kraj;
            Kupiec = kupiec;
            NrUmowy = nu;
        }

    }

}
