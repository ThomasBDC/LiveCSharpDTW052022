using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTW.Repository.User
{
    public class UserModel
    {
        [Display(Name ="Identifiant")]
        public int IdUser { get; set; }

        [Display(Name ="Nom")]
        public string UserForeName { get; set; }

        [Display(Name ="Prénom")]
        public string UserSurName { get; set; }

        [Display(Name = "Email")]
        public string UserEmail { get; set; }

    }
}
