using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataBase
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermission { get; set; }
        
    }
}
