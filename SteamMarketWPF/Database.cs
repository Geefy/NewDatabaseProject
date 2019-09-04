using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamMarketWPF
{
    class Database
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source= ZBC-EMA-1617; Initial Catalog= CSGOskins; Integrated Security=True;");
        SqlCommand sqlCom = new SqlCommand();

        public void InsertIntoDatabase(string nonQuery)
        {
            sqlCom.Connection = sqlCon;
            sqlCom.CommandText = nonQuery;
            try
            {
                sqlCon.Open();
                sqlCom.ExecuteNonQuery();

            }
            catch (SqlException s)
            {
                throw s;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public List<Item> GetFromDatabase()
        {
            List<Item> items = new List<Item>();
            sqlCom.CommandText = "SELECT * FROM GoSkins;";
            sqlCom.Connection = sqlCon;
            try
            {
                sqlCon.Open();
                using (SqlDataReader reader = sqlCom.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Item item = new Item();
                        item.ItemName = reader["SkinName"].ToString();
                        item.Wear = reader["Wear"].ToString();
                        item.LowestPrice = reader["LowestPrice"].ToString();
                        item.LowestPrice = reader["MedianPrice"].ToString();
                        item.AmountLeft = reader["AmountLeft"].ToString();
                        item.Img = (byte[])reader["Img"];
                        items.Add(item);
                    }
                }
            }
            catch (SqlException s)
            {

                throw s;
            }
            finally
            {
                sqlCon.Close();
            }
            return items;
        }
    }
}
