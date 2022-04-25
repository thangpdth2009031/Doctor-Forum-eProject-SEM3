using Doctor_Forum_eProject_SEM3.Data;
using Doctor_Forum_eProject_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Doctor_Forum_eProject_SEM3.Dao
{
    public class UserDao
    {
        private MyIdentityDbContext db = null;

        public UserDao()
        {
            db = new MyIdentityDbContext();
        }

        /*public string Insert(Account user)
        {
            try
            {
                db.Accounts.Add(user);
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            return user.Id;
        }*/
        public int Login(string userName, string passWord)
        {
            var result = db.Users.FirstOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;

                }
                else
                {
                    if (result.Password == passWord)

                        return 1;

                    else

                        return -2;

                }

            }


        }
        public Account GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool ChangeStatusPost(long id)
        {
            var post = db.Posts.Find(id);
            post.Status = !post.Status;
            db.SaveChanges();
            return post.Status;
        }

    }
}