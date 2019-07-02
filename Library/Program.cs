using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    class Program
    {
        private static string _connectionString = @"Server=DESKTOP-I98ASMM\SQLEXPRESS;Database=AdoNetDB;Trusted_Connection=True;";
        static void Main(string[] args)
        {
            //GetAllBooks();
            //AddBook();
            //AddAuthor();

            Console.WriteLine("Enter id");
            string stringId = Console.ReadLine();
            int id = int.Parse(stringId);
            //EditAuthor(id);
            EditBook(id);
            Console.ReadLine();
        }
        private static void GetAllBooks()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = $"Select * From Book ";

                    connection.Open();
                    var dataReader = cmd.ExecuteReader();

                    int Id = 0;
                    string title = "";
                    string genre = "";
                    int authorId = 0;

                    while (dataReader.Read())
                    {
                        Id = (int)dataReader["Id"];
                        title = (string)dataReader["Title"];
                        genre = (string)dataReader["Genre"];
                        authorId = (int)dataReader["AuthorId"];

                        Console.WriteLine($"\t Book Info:\nId: {Id}\nTitle: {title}\nGenre: {genre}");
                    }
                }
            }
        }
        private static void AddBook()
        {
            Console.WriteLine("Book Title");
            string title = Console.ReadLine();
            Console.WriteLine("Book Genre");
            string genre = Console.ReadLine();
            Console.WriteLine("Book AuthorId");
            string authorIdString = Console.ReadLine();
            int authorId = int.Parse(authorIdString);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddBook", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(@"Title", SqlDbType.NVarChar).Value = title;
                    cmd.Parameters.Add(@"Genre", SqlDbType.NVarChar).Value = genre;
                    cmd.Parameters.Add(@"AuthorId", SqlDbType.Int).Value = authorId;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }
        private static void AddAuthor()
        {
            Console.WriteLine("Author First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Author Last Name");
            string lastName = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand("AddAuthor", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(@"FirstName", SqlDbType.NVarChar).Value = firstName;
                    cmd.Parameters.Add(@"LastName", SqlDbType.NVarChar).Value = lastName;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private static void EditAuthor(int id)
        {
            Console.WriteLine("Author First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Author Last Name");
            string lastName = Console.ReadLine();
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand("EditAuthor", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(@"Id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add(@"FirstName", SqlDbType.NVarChar).Value = firstName;
                    cmd.Parameters.Add(@"LastName", SqlDbType.NVarChar).Value = lastName;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private static void EditBook(int id)
        {
            Console.WriteLine("Book Title");
            string title = Console.ReadLine();
            Console.WriteLine("Book Genre");
            string genre = Console.ReadLine();
            Console.WriteLine("Book AuthorId");
            string authorIdString = Console.ReadLine();
            int authorId = int.Parse(authorIdString);

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand("EditBook", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(@"Id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add(@"Title", SqlDbType.NVarChar).Value = title;
                    cmd.Parameters.Add(@"Genre", SqlDbType.NVarChar).Value = genre;
                    cmd.Parameters.Add(@"AuthorId", SqlDbType.Int).Value = authorId;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
