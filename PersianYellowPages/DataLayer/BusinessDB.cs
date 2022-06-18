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
        public static Business FindBusiness(int businessId)
        {
            string ConnectionString = StaticMethod();
            Business business = null;
            string selectStatement = " SELECT * " +
                                     " FROM Business " +
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
                        business = new Business()
                        {
                            BusinessId = (int)reader["BusinessId"],
                            TitleEnglish = reader["TitleEnglish"].ToString(),
                            TitlePersian = reader["TitlePersian"].ToString(),
                            DescriptionEnglish = reader["DescriptionEnglish"].ToString(),
                            DescriptionPersian = reader["DescriptionPersian"].ToString(),
                            Verified = (bool)reader["Verified"],
                            Phone1 = reader["Phone1"].ToString(),
                            Website = reader["Website"].ToString(),
                            Email = reader["Email"].ToString()

                        };
                    }
                    connection.Close();
                }
            }

            return business;
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
                                     " ORDER BY Business.Verified ";
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


        //AddBusiness method
        public static void AddBusiness(Business business)
        {
            string ConnectionString = StaticMethod();

            
            string insertStatement = " DECLARE 	@CategoryId [int]; " +
                                     " DECLARE 	@UserId [int]; " +
                                     " DECLARE 	@AddressId [int]; " +
                                     " IF (SELECT [CategoryId] FROM [dbo].[Category] WHERE [CategoryName] = @CategoryName) IS NULL " +
                                            " BEGIN " +
                                                " INSERT INTO Category (CategoryName) " +
                                                " VALUES (@CategoryName ); " +
                                                " SELECT @CategoryId = SCOPE_IDENTITY(); " +
                                            " END " +
                                     " ELSE " +
                                            " SET @CategoryId = (SELECT[CategoryId] FROM[dbo].[Category] WHERE[CategoryName] = @CategoryName); " +
                                      " IF (SELECT [UserId] FROM [dbo].[UserProfile] WHERE [UserEmail] = @UserEmail) IS NULL " +
                                            " BEGIN " +
                                                " INSERT INTO UserProfile (UserEmail, UserDisplayName) " +
                                                " VALUES (@UserEmail, @UserDisplayName ); " +
                                                " SELECT @UserId = SCOPE_IDENTITY(); " +
                                            " END " +
                                      " ELSE " +
                                            " SET @UserId = (SELECT[UserId] FROM [dbo].[UserProfile] WHERE[UserEmail] = @UserEmail); " +
                                      " IF (SELECT [AddressId] FROM [dbo].[Address] WHERE [AddressLine1] = @AddressLine1 AND [ZipCode] = @ZipCode ) IS NULL " +
                                            " BEGIN " +
                                                " INSERT INTO Address (AddressLine1, AddressLine2, City, State, ZipCode, GoogleMapLink) " +
                                                " VALUES (@AddressLine1, @AddressLine2, @City, @State, @ZipCode, @GoogleMapLink ); " +
                                                " SELECT @AddressId = SCOPE_IDENTITY(); " +
                                            " END " +
                                      " ELSE " +
                                            " SET @AddressId = (SELECT[AddressId] FROM [dbo].[Address] WHERE[AddressLine1] = @AddressLine1 AND [ZipCode] = @ZipCode); " +
                                      " INSERT INTO Business (TitleEnglish, TitlePersian, DescriptionEnglish, " +
                                      " DescriptionPersian, Phone1, Phone2, Website, Email, CategoryId, AddressId, UserId, Verified ) " +
                                      " VALUES ( @TitleEnglish, @TitlePersian, @DescriptionEnglish, " +
                                      " @DescriptionPersian, @Phone1, null, @Website, @Email, @CategoryId, @AddressId, @UserId, 0 ) ";

            using SqlConnection connection = new SqlConnection(ConnectionString);
            using SqlCommand command = new SqlCommand(insertStatement, connection);
            command.Parameters.AddWithValue("@TitleEnglish", business.TitleEnglish);
            command.Parameters.AddWithValue("@TitlePersian", business.TitlePersian);
            command.Parameters.AddWithValue("@DescriptionEnglish", business.DescriptionEnglish);
            command.Parameters.AddWithValue("@DescriptionPersian", business.DescriptionPersian);
            command.Parameters.AddWithValue("@Phone1", business.Phone1);
            command.Parameters.AddWithValue("@Website", business.Website);
            command.Parameters.AddWithValue("@Email", business.Email);
            command.Parameters.AddWithValue("@CategoryName", business.Categories.CategoryName);
            command.Parameters.AddWithValue("@UserEmail", business.UserProfiles.UserEmail);
            command.Parameters.AddWithValue("@UserDisplayName", business.UserProfiles.UserDisplayName);
            command.Parameters.AddWithValue("@AddressLine1", business.Addresses.AddressLine1);
            command.Parameters.AddWithValue("@AddressLine2", business.Addresses.AddressLine2);
            command.Parameters.AddWithValue("@City", business.Addresses.City);
            command.Parameters.AddWithValue("@State", business.Addresses.State);
            command.Parameters.AddWithValue("@ZipCode", business.Addresses.ZipCode);
            command.Parameters.AddWithValue("@GoogleMapLink", business.Addresses.GoogleMapLink);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }


        //UpdateBusiness method
        public static void UpdateBusiness(BusinessDetailsViewModel business)
        {
            string ConnectionString = StaticMethod();


            string insertStatement = " DECLARE 	@CategoryId [int]; " +
                                     " SET @CategoryId = (SELECT [CategoryId] FROM [dbo].[Business] WHERE BusinessId = @BusinessId );" +
                                     " DECLARE 	@AddressId [int]; " +
                                     " SET @AddressId = (SELECT [AddressId] FROM [dbo].[Business] WHERE BusinessId = @BusinessId );" +
                                     " UPDATE Category SET " +
                                     " CategoryName =  @CategoryName" +
                                     " WHERE CategoryId = @CategoryId ; " +
                                     " UPDATE Address SET " +
                                     " AddressLine1 =  @AddressLine1, " +
                                     " AddressLine2 =  @AddressLine2, " +
                                     " City =  @City, " +
                                     " State =  @State, " +
                                     " ZipCode =  @ZipCode, " +
                                     " GoogleMapLink =  @GoogleMapLink " +
                                     " WHERE AddressId = @AddressId ; " +
                                     " UPDATE Business SET " +
                                     " TitleEnglish =  @TitleEnglish, " +
                                     " TitlePersian =  @TitlePersian, " +
                                     " DescriptionEnglish =  @DescriptionEnglish, " +
                                     " DescriptionPersian =  @DescriptionPersian, " +
                                     " Phone1 =  @Phone1, " +
                                     " Website =  @Website, " +
                                     " Email =  @Email " +
                                     " WHERE BusinessId = @BusinessId  " ;
            using SqlConnection connection = new SqlConnection(ConnectionString);
            using SqlCommand command = new SqlCommand(insertStatement, connection);
            command.Parameters.AddWithValue("@TitleEnglish", business.TitleEnglish);
            command.Parameters.AddWithValue("@TitlePersian", business.TitlePersian);
            command.Parameters.AddWithValue("@DescriptionEnglish", business.DescriptionEnglish);
            command.Parameters.AddWithValue("@DescriptionPersian", business.DescriptionPersian);
            command.Parameters.AddWithValue("@Phone1", business.Phone1);
            command.Parameters.AddWithValue("@Phone2", business.Phone2 ?? "");
            command.Parameters.AddWithValue("@Website", business.Website);
            command.Parameters.AddWithValue("@Email", business.Email);
            command.Parameters.AddWithValue("@CategoryName", business.CategoryName);
            command.Parameters.AddWithValue("@AddressLine1", business.AddressLine1);
            command.Parameters.AddWithValue("@AddressLine2", business.AddressLine2 ?? "") ;
            command.Parameters.AddWithValue("@City", business.City);
            command.Parameters.AddWithValue("@State", business.State);
            command.Parameters.AddWithValue("@ZipCode", business.ZipCode);
            command.Parameters.AddWithValue("@GoogleMapLink", business.GoogleMapLink);
            command.Parameters.AddWithValue("@BusinessId", business.BusinessId);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }


        //UpdateBusiness method
        public static void DeleteBusiness(int Id)
        {
            string ConnectionString = StaticMethod();

            string Statement = " DELETE FROM Business " +
                               " WHERE BusinessId = @BusinessId ";
            using SqlConnection connection = new SqlConnection(ConnectionString);
            using SqlCommand command = new SqlCommand(Statement, connection);
            command.Parameters.AddWithValue("@BusinessId", Id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        //UpdateBusiness method
        public static void VerifyBusiness(BusinessDetailsViewModel business)
        {
            string ConnectionString = StaticMethod();


            string verifyStatement = " UPDATE Business SET " +
                                     " Verified =  @Verified " +
                                     " WHERE BusinessId = @BusinessId  ";
            using SqlConnection connection = new SqlConnection(ConnectionString);
            using SqlCommand command = new SqlCommand(verifyStatement, connection);
            command.Parameters.AddWithValue("@Verified", business.Verified);
            command.Parameters.AddWithValue("@BusinessId", business.BusinessId);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }


        //The StateList() method is created
        public static List<string> StateList()
        {
            string ConnectionString = StaticMethod();
            List<string> states = new List<string>();
            string selectStatement = " SELECT DISTINCT State " +
                                     " FROM Address ;" ;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    connection.Open();
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        states.Add(reader["State"].ToString());
                    }
                    connection.Close();
                }
            }

            return states;
        }



        //The BusinessList() method is created
        public static List<BusinessDetailsViewModel> SearchBusiness(string Phrase)
        {
            string ConnectionString = StaticMethod();
            List<BusinessDetailsViewModel> businesses = new List<BusinessDetailsViewModel>();
            string searchStatement = " SELECT * " +
                                     " FROM Business " +
                                     " INNER JOIN Category " +
                                     " ON Business.CategoryId = Category.CategoryId " +
                                     " INNER JOIN Address " +
                                     " ON Business.AddressId = Address.AddressId " +
                                     " WHERE Business.TitleEnglish LIKE @Phrase " +
                                     " OR Business.TitlePersian LIKE @Phrase " +
                                     " OR Business.DescriptionEnglish LIKE @Phrase " +
                                     " OR Business.DescriptionPersian LIKE @Phrase " +
                                     " OR Category.CategoryName LIKE @Phrase " +
                                     " AND Business.Verified = 'True' " ;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(searchStatement, connection))
                {
                    command.Parameters.AddWithValue("@Phrase", Phrase);
                    
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
        public static List<Review> ReviewList(int BusinessId)
        {
            string ConnectionString = StaticMethod();
            List<Review> reviews = new List<Review>();
            string selectStatement = " SELECT * " +
                                     " FROM Review " +
                                     " WHERE Review.BusinessId = @BusinessId ";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    command.Parameters.AddWithValue("@BusinessId", BusinessId);
                    connection.Open();
                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        reviews.Add(new Review
                        {
                            ReviewId = (int)reader["ReviewId"],
                            Rate = (int)reader["Rate"],
                            BusinessId = (int)reader["BusinessId"],
                            UserId = (int)reader["UserId"],
                            Comment = reader["Comment"].ToString(),
                            DateTime = (DateTime)reader["DateTime"]


                        });
                    }
                    connection.Close();
                }
            }

            return reviews;
        }



        //AddBusiness method
        public static void AddReview(Review review)
        {
            string ConnectionString = StaticMethod();


            string insertStatement = 
                                     " DECLARE 	@UserId [int]; " +
                                      " IF (SELECT [UserId] FROM [dbo].[UserProfile] WHERE [UserEmail] = @UserEmail) IS NULL " +
                                            " BEGIN " +
                                                " INSERT INTO UserProfile (UserEmail, UserDisplayName) " +
                                                " VALUES (@UserEmail, @UserDisplayName ); " +
                                                " SELECT @UserId = SCOPE_IDENTITY(); " +
                                            " END " +
                                      " ELSE " +
                                            " SET @UserId = (SELECT[UserId] FROM [dbo].[UserProfile] WHERE[UserEmail] = @UserEmail); " +
                                      " INSERT INTO Review (ReviewId, Rate, Comment, " +
                                      " DateTime, BusinessId, UserId ) " +
                                      " VALUES ( @ReviewId, @Rate, @Comment, " +
                                      " GETDATE(), @BusinessId, @UserId) ";
            using SqlConnection connection = new SqlConnection(ConnectionString);
            using SqlCommand command = new SqlCommand(insertStatement, connection);
            command.Parameters.AddWithValue("@ReviewId", review.ReviewId);
            command.Parameters.AddWithValue("@BusinessId", review.BusinessId);
            command.Parameters.AddWithValue("@UserId", review.UserId);
            command.Parameters.AddWithValue("@Rate", review.Rate);
            command.Parameters.AddWithValue("@Comment", review.Comment);
            command.Parameters.AddWithValue("@DateTime", review.DateTime);
            command.Parameters.AddWithValue("@UserEmail", review.UserProfiles.UserEmail);
            command.Parameters.AddWithValue("@UserDisplayName", review.UserProfiles.UserDisplayName);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

    }

    }
}
