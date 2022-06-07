using DTW.Repository.Links;
using DTW.Repository.User;
using System.Collections.Generic;

namespace LiveCSharpDTW052022.Models
{
    public class EditLinkViewModel
    {
        public LinkModel monLien { get; set; }
        public List<UserModel> lstUsers { get; set; }
    }
}
