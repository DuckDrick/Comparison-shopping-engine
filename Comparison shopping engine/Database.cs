using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comparison_shopping_engine
{
    public class Database
    {
        
        private readonly string _conString;
        public Database()
        {
            this._conString = VerySecretFile.connectionString;
        }


        public async void AddOrUpdate(string source, string name, string group, string link, string pLink, string price)
        {

            using (var connection = new NpgsqlConnection(_conString))
            {
                connection.Open();
                var check = await CheckIfExists(source, name, connection);
                if (!check)
                {
                    try
                    {
                        await Add(name, group, link, pLink, price, source, connection);
                    }
                    catch
                    {
                        await Update(name, price, source, connection);
                    }
                }
                else
                {
                    await Update(name, price, source, connection);
                }
                await connection.CloseAsync();
            }
        }

        private static async Task Add(string name, string group, string link, string pLink, string price, string source, NpgsqlConnection connection)
        {
            
            var cmd = new NpgsqlCommand("INSERT INTO " + source + " values (" +
                                        "\'" + name + "\'," +
                                        "\'" + group + "\'," +
                                        "\'" + link + "\'," +
                                        "\'" + pLink + "\'," +
                                        "" + price.Replace(",", ".").Replace(" ", "") + ")", connection);
            await cmd.ExecuteNonQueryAsync();
        }
        private static async Task Update(string name, string price, string source, NpgsqlConnection connection)
        {
            var cmd = new NpgsqlCommand("UPDATE " + source + " " +
                                        "SET price=" + price.Replace(",", ".") +
                                        " WHERE name='" + name +"'", connection);
           await cmd.ExecuteNonQueryAsync();
        }

        public async Task<bool> CheckIfExists(string source, string name, NpgsqlConnection connection)
        {
            Console.WriteLine(name);
            var cmd = new NpgsqlCommand("SELECT * FROM " + source + " where name='" + name + "'", connection);
            var reader = await cmd.ExecuteReaderAsync();
            var res = await reader.ReadAsync();
            await reader.CloseAsync();
            return res;
        }

        public static bool Search(string s, string table)
        {
            try
            {
                using (var conn = new NpgsqlConnection(VerySecretFile.connectionString))
                {
                    conn.Open();

                    var cmd = new NpgsqlCommand("SELECT * FROM " + table + " where name='" + s + "'", conn);
                    var dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        dr.Close();
                        return true;
                    }
                    dr.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(s);
                Console.WriteLine(e.Message);
                return true;

            }
        }

        public static async Task<List<Product>> Get(string table, string searchQuery = "")
        {
            var pl = new List<Product>();
            try
            {
                using (var conn = new NpgsqlConnection(VerySecretFile.connectionString))
                {
                    conn.Open();

                    var cmd = new NpgsqlCommand("SELECT * FROM " + table + " where upper(name) like upper('%" + searchQuery + "%')", conn);
                    var dr = await cmd.ExecuteReaderAsync();

                    while (dr.Read())
                    {
                        pl.Add(new Product(dr[0].ToString(), dr[4] + "€", dr[2].ToString(), dr[3].ToString(), dr[1].ToString(), table));
                    }
                    await dr.CloseAsync();
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
