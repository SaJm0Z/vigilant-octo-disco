using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Json
{
    class Data
    {
        private string conString = "Data Source=10.2.11.101;Initial Catalog=PraktykiTest;Integrated Security=True";

        public void DodajJson(string i, string ii, string iii, string iv, string v, string vi, string vii, string viii, string ix, string x, string xi, string xii, string xiii, string xiv, string xv, string xvi)
        {
            string zapytanie = "INSERT INTO HomelessJson (Region, Total_Adults, Male_Adults, Female_Adults, Adults_Aged_18, Adults_Aged_25, Adults_Aged_45, Adults_Aged_65, Number_of_people_who_accessed_Private_Emergency_Accommodation, Number_of_people_who_accessed_Supported_Temporary_Accommodation, Number_of_people_who_accessed_Temporary_Emergency_Accommodation, Number_of_people_who_accessed_Other_Accommodation, Number_of_Families, Number_of_Adults_in_Families, Number_of_SingleParent_families, Number_of_Dependants_in_Families)" +
                $"VALUES('{i}','{ii}','{iii}','{iv}','{v}','{vi}','{vii}','{viii}','{ix}','{x}','{xi}','{xii}','{xiii}','{xiv}','{xv}','{xvi}')";
            
            ModyfikacjaDanych(zapytanie);
        }


        public void DodajXml(string[] tab1, string[] tab2, string[] tab3, string[] tab4, string[] tab5, string[] tab6, string[] tab7, string[] tab8, string[] tab9, string[] tab10, string[] tab11, string[] tab12, string[] tab13, string[] tab14, string[] tab15, string[] tab16)
        {
            for (int y = 0; y < 9; y++)
            {
                string zapytanie = "INSERT INTO HomelessXml (Region, Total_Adults, Male_Adults, Female_Adults, Adults_Aged_18, Adults_Aged_25, Adults_Aged_45, Adults_Aged_65, Number_of_people_who_accessed_Private_Emergency_Accommodation, Number_of_people_who_accessed_Supported_Temporary_Accommodation, Number_of_people_who_accessed_Temporary_Emergency_Accommodation, Number_of_people_who_accessed_Other_Accommodation, Number_of_Families, Number_of_Adults_in_Families, Number_of_SingleParent_families, Number_of_Dependants_in_Families)" +
                    $"VALUES('{tab1[y]}','{tab2[y]}','{tab3[y]}','{tab4[y]}','{tab5[y]}','{tab6[y]}','{tab7[y]}','{tab8[y]}','{tab9[y]}','{tab10[y]}','{tab11[y]}','{tab12[y]}','{tab13[y]}','{tab14[y]}','{tab15[y]}','{tab16[y]}')";

                ModyfikacjaDanych(zapytanie);
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
