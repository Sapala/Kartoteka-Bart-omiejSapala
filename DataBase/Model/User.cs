using DataBase.Dao;
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
        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Login { get; set; }
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessage = "Błędna weryfikacja hasła")]
        [Display(Name = "Powtórz hasło")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Imię")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Name { get; set; }
        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string LastName { get; set; }
        [MinLength(11, ErrorMessage = "PESEL powinien składać się z 11 cyfr."), MaxLength(11, ErrorMessage = "PESEL powinien składać się z 11 cyfr.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "PESEL powinien składać się z 11 cyfr.")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Pesel { get; set; }
        [Display(Name = "Data urodzenia")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Miejsce urodzenia")]
        public string PlaceOfBirth { get; set; }
        [Display(Name = "Stanowisko pracy")]
        public string Workplace { get; set; }
        [NotMapped]
        [Display(Name = "Uprawnienia")]
        public Permission Permission
        {
            get
            {
                var UserPermission = new UserPermissionDao().GetByUserId(Id);
                if (UserPermission != null)
                    return UserPermission.Permission;
                return null;
            }
        }
        [NotMapped]
        public int? PermissionId { get; set; }

    }
}
