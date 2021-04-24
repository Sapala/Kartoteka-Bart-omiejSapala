using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Dao
{
    public class UserPermissionDao
    {

        public UserPermission GetByUserId(int UserId)
        {
            using (var context = new Context())
            {
                return context.UserPermission.Where(u => u.UserId == UserId).Include(p => p.Permission).FirstOrDefault();
            }
        }
    }
}
