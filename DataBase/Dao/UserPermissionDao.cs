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
            var contextOptions = new DbContextOptionsBuilder<Context>()
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Kartoteka_BartlomiejSapala;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;

            using (var context = new Context(contextOptions))
            {
                return context.UserPermission.Where(u => u.UserId == UserId).Include(p => p.Permission).FirstOrDefault();
            }
        }
    }
}
