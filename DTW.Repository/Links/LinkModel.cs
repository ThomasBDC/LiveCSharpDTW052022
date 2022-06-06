using DTW.Repository.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTW.Repository.Links
{
    public class LinkModel
    {
        public LinkModel(int idLink, string title, string description, string uRL, UserModel auteur)
        {
            IdLink = idLink;
            Title = title;
            Description = description;
            URL = uRL;
            Auteur = auteur;
        }

        public int IdLink { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public UserModel Auteur { get; set; }
    }
}
