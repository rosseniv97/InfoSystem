using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    class User
    {
        public string username;
        public string password;
        public string facNum;
        public int role;
        public DateTime Created;
        public DateTime Expired;

        public void PrintUser()
        {
            Console.WriteLine(username);
            Console.WriteLine(password);

        }

    }
}
