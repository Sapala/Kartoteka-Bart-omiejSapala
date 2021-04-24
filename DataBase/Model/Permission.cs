using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        [Display(Name = "Uprawnienia")]
        public string Name { get; set; }

    }
}
