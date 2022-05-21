using MvcEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class logicUser
    {

        public User CheckLogin(string userName, string password)
        {

            DemoEntity demoEntity = new DemoEntity();

            var data = demoEntity.User.Where(p => p.UserName == userName && p.Pwd == password).FirstOrDefault();
            return data;
        }



        public List<User> GetUsersList(string keyWord)
        {

            DemoEntity demoEntity = new DemoEntity();

            var data = demoEntity.User.ToList();
            if (!string.IsNullOrEmpty(keyWord))
            {
                data = data.Where(p => p.RealName.Contains(keyWord)).ToList();
            }
            return data;
        }




        public bool DelUser(int ID)
        {
            DemoEntity demoEntity = new DemoEntity();
            var data = demoEntity.User.Where(p => p.ID == ID).FirstOrDefault();
            if (data != null)
            {
                demoEntity.User.Remove(data);
                demoEntity.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }



        public User GetSingleUser(int ID)
        {
            DemoEntity demoEntity = new DemoEntity();
            var data = demoEntity.User.Where(p => p.ID == ID).FirstOrDefault();
            return data;
        }


        public void UpdateSingleUser(User user)
        {
            DemoEntity demoEntity = new DemoEntity();
            var data = demoEntity.User.Where(p => p.ID == user.ID).FirstOrDefault();
            data.RealName = user.RealName;
            data.Pwd = user.Pwd;
            data.Power = user.Power;
            data.UpdateTime = DateTime.Now;
            demoEntity.SaveChanges();
        }
        public void InsertSingleUser(User user)
        {

            DemoEntity demoEntity = new DemoEntity();
            demoEntity.User.Add(user);
            demoEntity.SaveChanges();
        }

    }
}
