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
        public static List<BusinessDetailsViewModel> BusinessList()
        {
            string ConnectionString = StaticMethod();
            List<BusinessDetailsViewModel> businesses = new List<BusinessDetailsViewModel>();
            string selectStatement = " SELECT * " +
                                     " FROM Business " +
                                     " INNER JOIN Category " +
                                     " ON Business.CategoryId = Category.CategoryId ";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    connection.Open();
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        businesses.Add(new BusinessDetailsViewModel
                        {
                            
                            TitleEnglish = reader["TitleEnglish"].ToString(),
                            TitlePersian = reader["TitlePersian"].ToString(),
                            DescriptionEnglish = reader["DescriptionEnglish"].ToString(),
                            DescriptionPersian = reader["DescriptionPersian"].ToString(),
                            Phone1 = reader["Phone1"].ToString(),
                            Phone2 = reader["Phone2"].ToString(),
                            Website = reader["Website"].ToString(),
                            Email = reader["Email"].ToString(),
                            CategoryName = reader["CategoryName"].ToString()


                        });
                    }
                    connection.Close();
                }
            }

            return businesses;
        }
    }
}
