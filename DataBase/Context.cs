using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataBase
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermission { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=DESKTOP-CTCS7CU;Database=Kartoteka10;Trusted_Connection=True;Integrated Security=True; MultipleActiveResultSets=False;");
    }
}
