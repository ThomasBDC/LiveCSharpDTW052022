using System;
using System.Collections.Generic;
using System.Text;

namespace DTW.Repository.Links
{
    public interface ILinkRepository
    {
        public List<LinkModel> GetAllLinks();
    }
}
