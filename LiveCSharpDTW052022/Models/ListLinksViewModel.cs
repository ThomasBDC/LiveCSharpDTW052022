using DTW.Repository.Links;
using System;
using System.Collections.Generic;

namespace LiveCSharpDTW052022.Models
{
    public class ListLinksViewModel
    {
        public int PerPage { get; set;  }
        public int NbPage { get; set; }
        public int NbLinksTotalBdd { get; set; }
        public int NbPageTotal
        {
            get
            {
                return Convert.ToInt16(Math.Ceiling(((decimal)NbLinksTotalBdd / PerPage)));
            }
        }
        public List<LinkModel> LstLinks { get; set; }

        public string Recherche { get; set; }
    }
}
