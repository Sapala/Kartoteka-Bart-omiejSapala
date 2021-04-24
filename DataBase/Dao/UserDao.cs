using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Dao
{
    public class UserDao 
    {
        public bool CheckUserPesel(Context context, string pesel, int? userId)
        {
            if (userId.HasValue)
            {
                var result = context.Users.AsNoTracking().Where(u => u.Id != userId && u.Pesel.Equals(pesel)).FirstOrDefault();
                if (result != null)
                    return true;
                else
                    return false;
            }
            else
            {
                var result = context.Users.AsNoTracking().Where(u => u.Pesel.Equals(pesel)).FirstOrDefault();
                if (result != null)
                    return true;
                else
                    return false;
            }
        }

        public bool CheckUserLogin(Context context, string login, int? userId)
        {
            if (userId.HasValue)
            {
                var result = context.Users.AsNoTracking().Where(u => u.Id != userId && u.Login.Equals(login)).FirstOrDefault();
                if (result != null)
                    return true;
                else
                    return false;
            }
            else
            {
                var result = context.Users.AsNoTracking().Where(u => u.Login.Equals(login)).FirstOrDefault();
                if (result != null)
                    return true;
                else
                    return false;
            }

        }
    }
}
