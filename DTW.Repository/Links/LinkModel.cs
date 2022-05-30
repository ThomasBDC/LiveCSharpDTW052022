using System;
using System.Collections.Generic;
using System.Text;

namespace DTW.Repository.Links
{
    public class LinkModel
    {
        public int IdLink { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        
        //TODO : auteur -> Ajouter en objet... a voir plus tard
    }
}
