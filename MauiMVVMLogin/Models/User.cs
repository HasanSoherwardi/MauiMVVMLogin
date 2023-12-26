using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiMVVMLogin.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public DateTime DOB { get; set; }
        [NotNull]
        public string POB { get; set; }
        [NotNull]
        public string Email { get; set; }
        [NotNull]
        [Unique]
        public string UserId { get; set; }
        [NotNull]
        public string Password { get; set; }

        public byte[] myArray { get; set; }

        
    }
}
