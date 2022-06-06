using DTW.Repository.User;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTW.Repository.Links
{
    public class LinkRepository : ILinkRepository
    {
        public string ConnectionString { get; set; }

        public LinkRepository(IConfiguration configuration)
        {
            var builder = new MySqlConnectionStringBuilder(
                configuration.GetConnectionString("DefaultConnection"));
            builder.Password = configuration["DbPassword"];
            ConnectionString = builder.ConnectionString+";";
        }

        public List<LinkModel> GetAllLinks()
        {
            //je me connecte à la bdd
            MySqlConnection cnn = new MySqlConnection(ConnectionString);
            cnn.Open();
            //Je crée une requête sql
            
            string sql = @"
                SELECT 
                    l.idLinks, 
                    l.Title,
                    l.Description, 
                    l.Link,
                    u.idUser,
                    u.forename, 
                    u.surname,
                    u.mail
                FROM 
                    links l
                INNER JOIN users u ON l.idAuteur = u.idUser
                ";

            //Executer la requête sql, donc créer une commande
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            var reader = cmd.ExecuteReader();
            var maListe = new List<LinkModel>();

            //Récupérer le retour, et le transformer en objet
            while (reader.Read())
            {
                UserModel auteur = new UserModel(
                    Convert.ToInt32(reader["idUser"]),
                    reader["forename"].ToString(),
                    reader["surname"].ToString(),
                    reader["mail"].ToString());

                var leLien = new LinkModel(
                    Convert.ToInt32(reader["idLinks"]),
                    reader["Title"].ToString(),
                    reader["Description"].ToString(),
                    reader["Link"].ToString(),
                    auteur
                );

                maListe.Add(leLien);
            }

            cnn.Close();
            return maListe;
        }

        public LinkModel GetLink(int id)
        {
            //je me connecte à la bdd
            MySqlConnection cnn = new MySqlConnection(ConnectionString);
            cnn.Open();
            //Je crée une requête sql

            string sql = @"
                SELECT 
                    l.idLinks, 
                    l.Title,
                    l.Description, 
                    l.Link,
                    u.idUser,
                    u.forename, 
                    u.surname,
                    u.mail
                FROM 
                    links l
                INNER JOIN users u ON l.idAuteur = u.idUser
                WHERE l.idLinks = @idLink
                ";

            //Executer la requête sql, donc créer une commande
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@idLink", id);

            var reader = cmd.ExecuteReader();
            LinkModel monLien = null;
            //Récupérer le retour, et le transformer en objet
            if (reader.Read())
            {
                UserModel auteur = new UserModel(
                    Convert.ToInt32(reader["idUser"]),
                    reader["forename"].ToString(),
                    reader["surname"].ToString(),
                    reader["mail"].ToString());

                monLien = new LinkModel(
                    Convert.ToInt32(reader["idLinks"]),
                    reader["Title"].ToString(),
                    reader["Description"].ToString(),
                    reader["Link"].ToString(),
                    auteur
                );
            }

            cnn.Close();
            return monLien;
        }
    }
}
