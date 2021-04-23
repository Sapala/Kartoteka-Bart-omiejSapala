using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Nazwa użytkownika")]
        public string Login { get; set; }
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        public string Pesel { get; set; }
        [Display(Name = "Data urodzenia")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Miejsce urodzenia")]
        public string PlaceOfBirth { get; set; }
        [Display(Name = "Stanowisko pracy")]
        public string Workplace { get; set; }
        [ForeignKey("Permission")]
        public int PermissionId { get; set; }
        [Display(Name = "Uprawnienia")]
        public Permission Permission { get; set; }

    }
}
