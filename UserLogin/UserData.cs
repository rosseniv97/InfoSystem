using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserLogin
{
    
    static class UserData
    {
        static private List<User> _testUsers;
        static public List<User> TestUsers
        {
            get {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }
        static private void ResetTestUserData()
        {
            
            
            User _testUser1 = new User();

            _testUser1.Created = DateTime.Now;
            _testUser1.Expired = DateTime.MaxValue;
                _testUser1.username = "Rosen";
                _testUser1.password = "password";
                _testUser1.facNum = "121214123";
                _testUser1.role = 1;

     //       DateTime timeCreated1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
       //         DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
            
            User _testUser2 = new User();
            _testUser2.Expired = DateTime.MaxValue;
            _testUser2.Created = DateTime.Now;
            _testUser2.username = "Teodora";
            _testUser2.password = "password";
            _testUser2.facNum = "121214123";
            _testUser2.role = 4;

            User _testUser3 = new User();
            _testUser3.Expired = DateTime.MaxValue;
            _testUser3.Created = DateTime.Now;
            _testUser3.username = "Stamat";
            _testUser3.password = "password";
            _testUser3.facNum = "121214123";
            _testUser3.role = 4;

            _testUsers = new List<User>();
            _testUsers.Add(_testUser1);
            _testUsers.Add(_testUser2);
            _testUsers.Add(_testUser3);


        }

        static public User IsUserPassCorrect(String username, String password)
        {
            User user =(User) (from userRes in TestUsers
            where userRes.username.Equals(username) && userRes.password.Equals(password)
            select userRes).First();
            if (user == null) return null;
            else return user;
            /* foreach(User user in TestUsers)
             {
                 if (user.username.Equals(username) && user.password.Equals(password))
                 {
                     return user;
                 }

             } */


        }
        static public void SetUserActiveTo (int index, DateTime newExpired)
        {
                    TestUsers[index].Expired = newExpired;
                    Logger.LogActivity("Промяна на активност на " + TestUsers[index].username);

        }
        static public void AssignUserRole(int index, UserRoles role)
        {

                    TestUsers[index].role = (int) role;
                    Logger.LogActivity("Промяна на роля на " + TestUsers[index].username);

        }
        static public Dictionary<string, int> AllUsersUsernames()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            int index=0;
            foreach (User user in TestUsers){
                result.Add(user.username, index);
                index++;
            }
            return result;
        }

    }
}
