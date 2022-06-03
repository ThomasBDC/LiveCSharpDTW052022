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
                    l.Link
                FROM 
                    links l
                ";

            //Executer la requête sql, donc créer une commande
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            var reader = cmd.ExecuteReader();
            var maListe = new List<LinkModel>();

            //Récupérer le retour, et le transformer en objet
            while (reader.Read())
            {
                var leLien = new LinkModel()
                {
                    IdLink = Convert.ToInt32(reader["idLinks"]),
                    Title = reader["Title"].ToString(),
                    Description = reader["Description"].ToString(),
                    URL = reader["Link"].ToString()
                };

                maListe.Add(leLien);
            }

            cnn.Close();
            return maListe;
        }
    }
}
