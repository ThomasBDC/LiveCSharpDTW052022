using DTW.Repository.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTW.Repository.Links
{
    public class LinkModel
    {
        public LinkModel()
        {

        }

        public LinkModel(int idLink, string title, string description, string uRL, UserModel auteur)
        {
            IdLink = idLink;
            Title = title;
            Description = description;
            URL = uRL;
            Auteur = auteur;
        }

        public int IdLink { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string URL { get; set; }
        public UserModel Auteur { get; set; }
    }
}
