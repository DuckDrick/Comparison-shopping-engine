using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparison_shopping_engine
{
    public class Database
    {
        //private NpgsqlConnection connection;
        private string conString;
        public Database()
        {
            this.conString = "";

        }

        private void connect(string conString)
        {
            //connection = new NpgsqlConnection(conString);
            //connection.Open();
        }

        public async void addOrUpdate(string source, string name, string group, string link, string plink, string price)
        {
            using (var connection = new NpgsqlConnection(conString))
            {
                connection.Open();
                var check = await checkIfExists(source, name, connection);
                if (!check)
                {
                    await add(name, group, link, plink, price, source, connection);
                }
                else
                {

                }
                connection.Close();
            }
        }

        private async Task add(string name, string group, string link, string plink, string price, string source, NpgsqlConnection connection)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO " + source + " values (" +
                     "\'" + name + "\'," +
                     "\'" + group + "\'," +
                     "\'" + link + "\'," +
                     "\'" + plink + "\'," +
                     "" + price.Replace(",", ".").Replace(" ", "") + ")", connection);
            await cmd.ExecuteNonQueryAsync();
        }
        private void update(string name, string price)
        {

        }

        public async Task<bool> checkIfExists(string source, string name, NpgsqlConnection connection)
        {
            Console.WriteLine(name);
            var cmd = new NpgsqlCommand("SELECT * FROM " + source + " where name='" + name + "'", connection);
            var reader = cmd.ExecuteReader();
            var res = await reader.ReadAsync();
            reader.Close();
            return res;
        }

        public static bool Search(string s, string table)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(""))
                {
                    conn.Open();

                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM " + table + " where name='" + s + "'", conn);
                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        dr.Close();
                        return true;
                    }
                    dr.Close();
                    return false; ;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(s);
                Console.WriteLine(e.Message);
                return true;
                
            }
        }

        public static async Task<List<Product>> Get(string s, string table)
        {
            List<Product> pl = new List<Product>();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(""))
                {
                    conn.Open();

                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM " + table + " where upper(name) like upper('%" + s + "%')", conn);
                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        pl.Add(new Product(dr[0].ToString(), dr[4].ToString() + "€", dr[2].ToString(), dr[3].ToString(), dr[1].ToString()));
                    }
                    dr.Close();
                    return pl;
                }
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
                return pl;

            }
        }

    }
}
