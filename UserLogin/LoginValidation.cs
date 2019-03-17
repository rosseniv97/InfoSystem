using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
     class LoginValidation
    {
        static private UserRoles _currentUserRole;
        static private String username;
        private String password;
        private String errMsg;
        public delegate void ActionOnError(string errorMsg);
        private ActionOnError errAction;

        public LoginValidation(String username,String password,ActionOnError errAction)
        {
            currentUserUsername = username;
            this.password = password;
            this.errAction = errAction;
        }
        static public UserRoles currentUserRole
        {
             get { return _currentUserRole; }
            private set { _currentUserRole = value; }
        }
        public static string currentUserUsername
        {
            get { return username; }
            private set { username = value; }
        }
        public bool ValidateUserInput(out User user)
        {
            user = null;
            Boolean emptyUserName,emptyPassword;
            emptyUserName = username.Equals(String.Empty);
            emptyPassword = password.Equals(String.Empty);
            
            
            if (emptyPassword)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                errMsg = "Missing password";
                errAction(errMsg);
               // Console.WriteLine(errMsg);
                return false;
            }
            else if (password.Length < 5)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                errMsg = "Password is too short";
                errAction(errMsg);
                // Console.WriteLine(errMsg);
                return false;
            }

            if (emptyUserName)
            {
                currentUserRole = UserRoles.ANONYMOUS;
                errMsg = "Missing username";
                Console.WriteLine(errMsg);
                return false;
            }
            else if (username.Length < 5)
            {
                errMsg = "Username is too short";
                errAction(errMsg);
                // Console.WriteLine(errMsg);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            user = UserData.IsUserPassCorrect(username, password);
            if (user != null)
            {
                currentUserRole = (UserRoles)user.role;
                Logger.LogActivity("Успешен Login");
                return true;
            }
            else {
                errMsg = "No such user";
                errAction(errMsg);
               // Console.WriteLine(errMsg);
                return false;
            }
                
               

        }
    }
}
