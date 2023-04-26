using System;
using System.Threading.Tasks;
using DALayer;
using EntityLayer;
using DALayer.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DALayer
{
    public class LoginDataService : ILogin
    {
        private OnlineBankingSystemDbContext db;
        public LoginDataService(OnlineBankingSystemDbContext db)
        {
            this.db = db;
        }

        public userloginmodel SignupUser(SignupModel reg)
        {
            UserCredential newuser = new UserCredential();
            newuser.UserName = reg.UserName;
            newuser.Password = reg.Password;
            newuser.CustomerId = reg.CustomerId;
            newuser.MobileNo = reg.MobileNo;
            newuser.UserRole = reg.UserRole;

            DateTime now = DateTime.Now;
            newuser.CreatedDate = now;
            newuser.ModifiedDate = now;

            userloginmodel user = new userloginmodel();
            try
            {
                if (reg.Password==reg.ConfirmPassword)
                {
                    
                    db.UserCredentials.Add(newuser);
                    db.SaveChanges();

                    user.UserName = reg.UserName;
                    user.Role = reg.UserRole;

                    return user;                     
                }
                else
                {
                    throw new Exception("Enter valid details");
                }
                
            }catch(Exception e)
            {
                if(e.InnerException!=null)
                {
                    throw new Exception(e.InnerException.Message);
                }
                throw new Exception(e.Message);
            }
        }

        public userloginmodel LoginUser(SigninModel log)
        {
            userloginmodel model=new userloginmodel();
            try
            {
                var user =db.UserCredentials.Find(log.UserName);
                if(user!=null)
                {
                    if ((user.UserName == log.UserName) & (user.Password == log.Password))
                    {
                        model.UserName = user.UserName;
                        model.Role = user.UserRole;
                        return model;
                    }
                    else
                    {
                        throw new Exception("Invalid username or password");
                    }
                }else
                {
                    throw new Exception("Enter valid details");
                }               
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<UserCredential> GetUsers()
        {
            List<UserCredential> user=new List<UserCredential>();
            try
            {
                user = db.UserCredentials.ToList();
                if (user!=null)
                {
                    return user;
                }
                else
                {
                    throw new Exception("Invalid username or password");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
