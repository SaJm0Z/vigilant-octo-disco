using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace Salon
{
    class Dane
    {
        private string conString = "Data Source=10.2.11.101;Initial Catalog=Salon;Integrated Security=True"; //Łączenie z bazą danych za pomocą konta domenowego :/ 
      
        
        public void DodajAuto(Auto Auto) 
        {
            string zapytanie = "INSERT INTO Auta (Marka, Model, RokProdukcji, Paliwo, Silnik, Moc, Przebieg, KrajPochodzenia, Cena)" +
                $"VALUES('{Auto.Marka}','{Auto.Model}','{Auto.RokProd}','{Auto.Paliwo}','{Auto.Silnik}','{Auto.Moc}','{Auto.Przebieg}','{Auto.KrajPochodzenia}','{Auto.Cena}')";
            ModyfikacjaDanych(zapytanie);
        }
     
        public void UsunAuto(int nr)
        {
            string zapytanie = "DELETE FROM Auta WHERE NrKatalog = '"+nr+"'";
            ModyfikacjaDanych(zapytanie);
        }
        public void UsunSprzedany(int nr)
        {
            string zapytanie = "DELETE FROM Sprzedane WHERE NrUmowy = '"+nr+"'";
            ModyfikacjaDanych(zapytanie);
        }


        public void DodajSprzedaz(string kupujacy, string marka, string model, string rok, string paliwo, string silnik, string moc, string przebieg, string kraj)
        {
            string zapytanie = "INSERT INTO Sprzedane (Kupujacy, Marka, Model, RokProdukcji, Paliwo, Silnik, Moc, Przebieg, KrajPochodzenia)" +
                $"VALUES('{kupujacy}','{marka}','{model}','{rok}','{paliwo}','{silnik}','{moc}','{przebieg}','{kraj}')";
            ModyfikacjaDanych(zapytanie);
        }

        public void ZabierzAuto(int nr)
        {
            string zapytanie = "SELECT Marka, Model, RokProdukcji, Paliwo, Silnik, Moc, Przebieg, KrajPochodzenia, NrKatalog FROM Auta WHERE NrKatalog='"+nr+"'";
            DataRowCollection wiersze = PobierzDane(zapytanie);
            foreach (DataRow wiersz in wiersze)
            {
                string marka = wiersz["Marka"].ToString();
                string model = wiersz["Model"].ToString();
                string rok = wiersz["RokProdukcji"].ToString();
                string paliwo = wiersz["Paliwo"].ToString();
                string silnik = wiersz["Silnik"].ToString();
                string moc = wiersz["Moc"].ToString();
                string przebieg = wiersz["Przebieg"].ToString();
                string kraj = wiersz["KrajPochodzenia"].ToString();
                int NrK = (int)wiersz["NrKatalog"];
                Console.WriteLine("Imie i Nazwisko kupującego: ");
                string kupujacy = Console.ReadLine();

                DodajSprzedaz(kupujacy, marka, model, rok, paliwo, silnik, moc, przebieg, kraj);
                UsunAuto(NrK);
            }
        }

        public IEnumerable<Sprzedane> ListaSprzedanych()
        {
            string zapytanie = "SELECT NrUmowy, Kupujacy, Marka, Model, RokProdukcji, Paliwo, Silnik, Moc, Przebieg, KrajPochodzenia FROM Sprzedane";
            DataRowCollection wiersze = PobierzDane(zapytanie);
            foreach (DataRow wiersz in wiersze)
            {
                string nru = wiersz["NrUmowy"].ToString();
                string kupujacy = wiersz["Kupujacy"].ToString();
                string marka = wiersz["Marka"].ToString();
                string model = wiersz["Model"].ToString();
                string rok = wiersz["RokProdukcji"].ToString();
                string paliwo = wiersz["Paliwo"].ToString();
                string silnik = wiersz["Silnik"].ToString();
                string moc = wiersz["Moc"].ToString();
                string przebieg = wiersz["Przebieg"].ToString();
                string kraj = wiersz["KrajPochodzenia"].ToString();
                Sprzedane sprzedane = new Sprzedane(marka, model, rok, paliwo, silnik, moc, przebieg, kraj, kupujacy, nru);

                yield return sprzedane;
            }
        }




        public IEnumerable<Auto> ListaAut()
        {
            string zapytanie = "SELECT NrKatalog, Marka, Model, RokProdukcji, Paliwo, Silnik, Moc, Przebieg, KrajPochodzenia, Cena FROM Auta";
            DataRowCollection wiersze = PobierzDane(zapytanie);
            foreach(DataRow wiersz in wiersze)
            {
                string marka = wiersz["Marka"].ToString();
                string model = wiersz["Model"].ToString();
                string rok = wiersz["RokProdukcji"].ToString();
                string paliwo = wiersz["Paliwo"].ToString();
                string silnik = wiersz["Silnik"].ToString();
                string moc = wiersz["Moc"].ToString();
                string przebieg = wiersz["Przebieg"].ToString();
                string kraj = wiersz["KrajPochodzenia"].ToString();
                string cena = wiersz["Cena"].ToString();
                Auto auto = new Auto(marka, model, rok, paliwo, silnik, moc, przebieg, kraj, cena)
                {
                    NrKatalog = (int)wiersz["NrKatalog"]
                };
                yield return auto;
            } 
        }

        private DataRowCollection PobierzDane(string zapytanie)
        {
            using (SqlConnection sCon = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(zapytanie, sCon);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return ds.Tables[0].Rows;
            }
            
        }

        private void ModyfikacjaDanych(string zapytanie)
        {

            SqlConnection sCon = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(zapytanie, sCon);
            sCon.Open();
            cmd.ExecuteNonQuery();
            sCon.Close();

        }
    }
}
