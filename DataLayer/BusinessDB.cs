using Microsoft.Extensions.Configuration;
using PersianYellowPages.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersianYellowPages.DataLayer
{
    public class BusinessDB
    {
        string ConStr = "";

        //The Constructor that gets the connection string
        public BusinessDB()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            ConStr = builder.GetSection("ConnectionStrings:DBConnection").Value;
        }


        public static string StaticMethod()
        {
            var mc = new BusinessDB();
            string ConnectionStr = mc.ConStr;
            return ConnectionStr;
        }


        //The BusinessList() method is created
        public static List<Business> BusinessList()
        {
            string ConnectionString = StaticMethod();
            List<Business> businesses = new List<Business>();
            string selectStatement = "SELECT * " +
                                     "FROM Business";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    connection.Open();
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        businesses.Add(new Business
                        {
                            BusinessID = (int)reader["BusinessID"],
                            TitleEnglish = reader["TitleEnglish"].ToString(),
                            TitlePersian = reader["TitlePersian"].ToString(),
                            DescriptionEnglish = reader["DescriptionEnglish"].ToString(),
                            DescriptionPersian = reader["DescriptionPersian"].ToString(),
                            Phone1 = reader["Phone1"].ToString(),
                            Phone2 = reader["Phone2"].ToString(),
                            Website = reader["Website"].ToString(),
                            Email = reader["Email"].ToString(),
                            CategoryID = (int)reader["CategoryID"],
                            AddressID = (int)reader["AddressID"]

                        });
                    }
                    connection.Close();
                }
            }

            return businesses;
        }
    }
}
