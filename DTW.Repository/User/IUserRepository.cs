using System;
using System.Collections.Generic;
using System.Text;

namespace DTW.Repository.User
{
    public interface IUserRepository
    {
        public List<UserModel> GetAllUsers();
    }
}
