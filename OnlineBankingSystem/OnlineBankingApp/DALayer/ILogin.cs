using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DALayer.Models;
using EntityLayer;

namespace DALayer
{
    public interface ILogin
    {
        public userloginmodel SignupUser(SignupModel reg);
        public userloginmodel LoginUser(SigninModel log);
        public List<UserCredential> GetUsers();
    }
}
