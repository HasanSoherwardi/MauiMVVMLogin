using SQLite;
using static SQLite.SQLite3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiMVVMLogin.Models;

namespace MauiMVVMLogin.Services
{
    public class SQLite_Android
    {
        SQLiteConnection database;

        public SQLite_Android()
        {
            database = new SQLiteConnection(DbConnection.DBPath, DbConnection.flags);
            database.CreateTable<User>();
        }
        public bool DeleteUser(int id)
        {
            bool res = false;
            try
            {
                string sql = $"Delete from User where id={id}";
                database.Execute(sql);
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }

        public List<User> GetUsers(User user)
        {
            string sql = $"Select * from User Where UserId ='{user.UserId}' and password='{user.Password}'";
            List<User> employees = database.Query<User>(sql);
            return employees;
        }

        public User GetUserLogin(User user)
        {
            try
            {
                return database.Table<User>().Where(x => x.UserId == user.UserId && x.Password == user.Password).SingleOrDefault();

            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        public bool SaveUser(User user)
        {
            bool res = false;
            try
            {
                database.Insert(user);
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }

        public bool UpdateUser(User user)
        {
            bool res = false;
            try
            {
                // string sql = $"Update Employee set Name='{employee.Name}', Address='{employee.Address}',PhoneNumber='{employee.PhoneNumber}',Email='{employee.Email}', myArray='{employee.myArray}' Where id={employee.id}";
                // database.Execute(sql);
                database.Update(user);
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }
    }
}
