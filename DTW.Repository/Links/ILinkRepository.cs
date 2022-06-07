using System;
using System.Collections.Generic;
using System.Text;

namespace DTW.Repository.Links
{
    public interface ILinkRepository
    {
        public List<LinkModel> GetAllLinks();
        public LinkModel GetLink(int id);
        public bool EditLink(LinkModel link);
    }
}
