using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    public class UserPermission
    {
        public UserPermission()
        {
        }

        public UserPermission(int userId, Permission permission)
        {
            UserId = userId;
            Permission = permission;
        }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("Permission")]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
