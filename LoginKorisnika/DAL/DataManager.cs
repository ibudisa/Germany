using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataManager
    {
        private WienerEntities ctx = new WienerEntities();

        public DataManager()
        {

        }

        public List<Registration> GetRegistrations()
        {
            var list = ctx.Registrations.ToList();
            return list;
        }

        public Registration GetRegistration(string email)
        {
            var item = ctx.Registrations.Where(p => p.Email.Equals(email)).FirstOrDefault();

            return item;
        }

        public void AddRegistration(Registration registration)
        {
            ctx.Registrations.Add(registration);
            ctx.SaveChanges();
        }

        public List<UserInfo> GetUsers()
        {
            var list = ctx.UserInfoes.ToList();
            return list;
        }

        public UserInfo GetUser(int id)
        {
            var user = ctx.UserInfoes.Where(u => u.Id == id).FirstOrDefault();

            return user;
        }

        public void AddUser(UserInfo user)
        {
            ctx.UserInfoes.Add(user);
            ctx.SaveChanges();
        }

        public void UpdateUser(UserInfo user)
        {
            ctx.Entry(user).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = GetUser(id);
            ctx.UserInfoes.Remove(user);
            ctx.SaveChanges();
        }

        public UserInfo GetUserByEmail(string email)
        {
            var user = ctx.UserInfoes.Where(u => u.Email.Equals(email)).FirstOrDefault();
            return user;
        }

        public List<UserLogin> GetLogins()
        {
            var list = ctx.UserLogins.ToList();
            return list;
        }

        public void AddUserLogin(UserLogin login)
        {
            ctx.UserLogins.Add(login);
            ctx.SaveChanges();
        }

        public List<UserLogin> GetLoginsByUser(int userid)
        {
            var list = ctx.UserLogins.Where(p => p.UserId == userid).ToList();
            return list;
        }

        public void DeleteUserLogins(List<UserLogin> list)
        {
            ctx.UserLogins.RemoveRange(list);
            ctx.SaveChanges();
        }
    }
}
