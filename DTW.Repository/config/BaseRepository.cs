using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTW.Repository.config
{
    public class BaseRepository : IBaseRepository
    {
        public string ConectionString { get; set; }

        public BaseRepository(IConfiguration configuration)
        {
            ConectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public MySqlConnection OpenConnexion()
        {
            try
            {
                MySqlConnection cnn = new MySqlConnection(ConectionString);
                cnn.Open();
                return cnn;
            }
            catch(Exception ex)
            {
                throw new Exception("Impossible de se connecter à la base de données");
            }
        }
    }
}
