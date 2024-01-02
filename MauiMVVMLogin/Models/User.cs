using SQLite;
using System.ComponentModel.DataAnnotations;

namespace MauiMVVMLogin.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Date of Birth is Required")]
        public DateTime DOB { get; set; } = DateTime.Today;
        [Required(ErrorMessage = "Place of Birth is Required")]
        public string POB { get; set; }
        [Required(ErrorMessage = "Email Id is Required")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Invalid Email Id")]
        public string Email { get; set; }
        [Required(ErrorMessage = "UserId is Required")]
        [Unique]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        public byte[] myArray { get; set; }


    }
}
