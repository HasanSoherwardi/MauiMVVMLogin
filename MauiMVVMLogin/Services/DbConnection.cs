using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMVVMLogin.Services
{
    public class DbConnection
    {
        private const string DbFileName = "LoginLocalDB.db";
        public const SQLiteOpenFlags flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static string DBPath
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory,
                    DbFileName);
            }
        }
    }
}
