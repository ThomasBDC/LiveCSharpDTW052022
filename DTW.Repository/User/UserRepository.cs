using DTW.Repository.config;
using DTW.Repository.User;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTW.Repository.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {

        public UserRepository(IConfiguration configuration) : base(configuration)
        {
            
        }

        public List<UserModel> GetAllUsers()
        {
            //je me connecte à la bdd
            var cnn = OpenConnexion();
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
                UserModel auteur = new UserModel()
                {
                    IdUser = Convert.ToInt32(reader["idUser"]),
                    UserForeName = reader["forename"].ToString(),
                    UserSurName = reader["surname"].ToString(),
                    UserEmail = reader["mail"].ToString()
                };

                maListe.Add(auteur);
            }

            cnn.Close();
            return maListe;
        }

    }
}
