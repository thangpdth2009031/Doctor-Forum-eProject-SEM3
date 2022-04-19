using Doctor_Forum_eProject_SEM3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doctor_Forum_eProject_SEM3.Dao
{
    public class UserDao
    {
        private DoctorForumDbContext db = null;
        public UserDao()
        {
            db = new DoctorForumDbContext();
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Accounts.SingleOrDefault(x => x.UserName == userName);   
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
        public bool CheckUserName(string userName)
        {
            return db.Accounts.Count(x => x.UserName == userName) > 0;
        }
        public Account GetById(string userName)
        {
            return db.Accounts.SingleOrDefault(x => x.UserName == userName);
        }
    }

}