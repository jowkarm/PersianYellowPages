using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Documents;
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
                                     " ON Business.CategoryId = Category.CategoryId " +
                                     " INNER JOIN Address " +
                                     " ON Business.AddressId = Address.AddressId " +
                                     " WHERE Business.Verified = 'True' ";
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
                            BusinessId = (int)reader["BusinessId"],
                            TitleEnglish = reader["TitleEnglish"].ToString(),
                            TitlePersian = reader["TitlePersian"].ToString(),
                            DescriptionEnglish = reader["DescriptionEnglish"].ToString(),
                            DescriptionPersian = reader["DescriptionPersian"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            City = reader["City"].ToString(),
                            State = reader["State"].ToString(),
                            Verified = (bool)reader["Verified"]


                        });
                    }
                    connection.Close();
                }
            }

            return businesses;
        }


        //The BusinessList() method is created
        public static BusinessDetailsViewModel GetBusiness(int businessId)
        {
            string ConnectionString = StaticMethod();
            BusinessDetailsViewModel business = null;
            string selectStatement = " SELECT * " +
                                     " FROM Business " +
                                     " INNER JOIN Category " +
                                     " ON Business.CategoryId = Category.CategoryId " +
                                     " INNER JOIN Address " +
                                     " ON Business.AddressId = Address.AddressId " +
                                     " WHERE Business.BusinessId = @BusinessId ";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    command.Parameters.AddWithValue("@BusinessId", businessId);
                    connection.Open();
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        business = new BusinessDetailsViewModel()
                        {
                            BusinessId = (int)reader["BusinessId"],
                            TitleEnglish = reader["TitleEnglish"].ToString(),
                            TitlePersian = reader["TitlePersian"].ToString(),
                            DescriptionEnglish = reader["DescriptionEnglish"].ToString(),
                            DescriptionPersian = reader["DescriptionPersian"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            City = reader["City"].ToString(),
                            State = reader["State"].ToString(),
                            Verified = (bool)reader["Verified"],
                            Phone1 = reader["Phone1"].ToString(),
                            Phone2 = reader["Phone2"].ToString(),
                            Website = reader["Website"].ToString(),
                            Email = reader["Email"].ToString(),
                            ZipCode = reader["ZipCode"].ToString(),
                            AddressLine1 = reader["AddressLine1"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            GoogleMapLink = reader["GoogleMapLink"].ToString()
                        


                        };
                    }
                    connection.Close();
                }
            }

            return business;
        }


        //The AdminBusinessList() method is created
        public static List<BusinessDetailsViewModel> AdminBusinessList()
        {
            string ConnectionString = StaticMethod();
            List<BusinessDetailsViewModel> businesses = new List<BusinessDetailsViewModel>();
            string selectStatement = " SELECT * " +
                                     " FROM Business " +
                                     " INNER JOIN Category " +
                                     " ON Business.CategoryId = Category.CategoryId " +
                                     " INNER JOIN Address " +
                                     " ON Business.AddressId = Address.AddressId " +
                                     " ORDER BY Business.Verified DESC ";
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
                            BusinessId = (int)reader["BusinessId"],
                            TitleEnglish = reader["TitleEnglish"].ToString(),
                            TitlePersian = reader["TitlePersian"].ToString(),
                            DescriptionEnglish = reader["DescriptionEnglish"].ToString(),
                            DescriptionPersian = reader["DescriptionPersian"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            City = reader["City"].ToString(),
                            State = reader["State"].ToString(),
                            Verified = (bool) reader["Verified"]


                        });
                    }
                    connection.Close();
                }
            }

            return businesses;
        }

        //The OwnerBusinessList() method is created
        public static List<BusinessDetailsViewModel> OwnerBusinessList(string userEmail)
        {
            string ConnectionString = StaticMethod();
            List<BusinessDetailsViewModel> businesses = new List<BusinessDetailsViewModel>();
            string selectStatement = " SELECT * " +
                                     " FROM Business " +
                                     " INNER JOIN Category " +
                                     " ON Business.CategoryId = Category.CategoryId " +
                                     " INNER JOIN Address " +
                                     " ON Business.AddressId = Address.AddressId " +
                                     " INNER JOIN UserProfile " +
                                     " ON Business.UserId = UserProfile.UserId " +
                                     " WHERE UserProfile.UserEmail = @UserEmail " +
                                     " ORDER BY Business.Verified DESC ";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    command.Parameters.AddWithValue("@UserEmail", userEmail);
                    connection.Open();
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        businesses.Add(new BusinessDetailsViewModel
                        {
                            BusinessId = (int)reader["BusinessId"],
                            TitleEnglish = reader["TitleEnglish"].ToString(),
                            TitlePersian = reader["TitlePersian"].ToString(),
                            DescriptionEnglish = reader["DescriptionEnglish"].ToString(),
                            DescriptionPersian = reader["DescriptionPersian"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            City = reader["City"].ToString(),
                            State = reader["State"].ToString(),
                            Verified = (bool)reader["Verified"]


                        });
                    }
                    connection.Close();
                }
            }

            return businesses;
        }
    }
}
