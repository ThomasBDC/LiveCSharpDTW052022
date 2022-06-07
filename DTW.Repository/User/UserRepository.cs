using DTW.Repository.User;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTW.Repository.User
{
    public class UserRepository : IUserRepository
    {
        public string ConnectionString { get; set; }

        public UserRepository(IConfiguration configuration)
        {
            var builder = new MySqlConnectionStringBuilder(
                configuration.GetConnectionString("DefaultConnection"));
            builder.Password = configuration["DbPassword"];
            ConnectionString = builder.ConnectionString+";";
        }

        public List<UserModel> GetAllUsers()
        {
            //je me connecte à la bdd
            MySqlConnection cnn = new MySqlConnection(ConnectionString);
            cnn.Open();
            //Je crée une requête sql
            
            string sql = @"
                SELECT 
                    u.idUser,
                    u.forename, 
                    u.surname,
                    u.mail
                FROM 
                    users u
                ";

            //Executer la requête sql, donc créer une commande
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            var reader = cmd.ExecuteReader();
            var maListe = new List<UserModel>();

            //Récupérer le retour, et le transformer en objet
            while (reader.Read())
            {
                UserModel auteur = new UserModel(
                    Convert.ToInt32(reader["idUser"]),
                    reader["forename"].ToString(),
                    reader["surname"].ToString(),
                    reader["mail"].ToString());

                maListe.Add(auteur);
            }

            cnn.Close();
            return maListe;
        }

    }
}
