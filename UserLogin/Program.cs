using System;
using System.Collections.Generic;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            String username;
            String password;
            Console.WriteLine("Enter username:");
            username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            password = Console.ReadLine();

             void PrintError(String errMsg)
            {
                Console.WriteLine(errMsg);
            }
   
            void Administration()
            {
                
                int option = -1;

                Console.WriteLine("You're admin");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Change user's role");
                Console.WriteLine("2: Change user's expiration date");
                Console.WriteLine("3: List of all users:");
                Console.WriteLine("4: View user logs");
                Console.WriteLine("5: View current user activities");
                option = Convert.ToInt32(Console.ReadLine());
                
                switch (option)
                {

                    case 0:

                        break;
                    case 1:
                        Dictionary<string, int> allusers = UserData.AllUsersUsernames();

                        Console.WriteLine("Select user:");
                        string userSelected = Console.ReadLine();
                        Console.WriteLine("Assign new role:");
                        int newRole = 0;
                        newRole = Convert.ToInt32(Console.ReadLine());
                        UserData.AssignUserRole(allusers[userSelected], (UserRoles)newRole); 
                        break;

                    case 2:
                        allusers = UserData.AllUsersUsernames();
                        Console.WriteLine("Select user:");
                        string selectedUser = Console.ReadLine();
                        Console.WriteLine("Change expiration date:");
                        string date = Console.ReadLine();
                        DateTime newExpDate = Convert.ToDateTime(date);
                        UserData.SetUserActiveTo(allusers[selectedUser], newExpDate);
                        break;

                    case 3:
                        allusers = UserData.AllUsersUsernames();
                        foreach(KeyValuePair<string, int> _user in allusers)
                        {
                            Console.WriteLine(_user.Key);
                        }
                        UserData.AllUsersUsernames();
                        break;
                    case 4:
                        Logger.ViewLogActivity();
                        break;
                    case 5:
                        Logger.GetCurrentSessionActivities();
                        break;

                }

            }

            LoginValidation validation = new LoginValidation(username,password,PrintError);
            User user = null;
            if (validation.ValidateUserInput(out user))
            {
              /*  Console.WriteLine("Hello, " + user.username);
                Console.WriteLine("Created: " + user.Created);
                Console.WriteLine("Expire: " + user.Expired); */

                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ADMIN:
                        Administration();
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("You're inspector");
                        break;
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("You're anonymous");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("You're student");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("You're professor");
                        break;

                }

            }
            

        }
    }
}
