using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class Role
    {

        static ChooseRoleValidation check = new ChooseRoleValidation();
        static User user = new User();
        static string userInfo;

        public void StartCalendar()
        {
            ChooseRole();
            Console.Clear();
            new ShowCalendar(user.selectedUser);
        }
        public static void ChooseRole()
        {
                Console.WriteLine("Please choose an user! Enter a number between 1 and 3.");
                Console.WriteLine("User1 --- User2 --- User3");

               userInfo = Console.ReadLine();

                while (check.CheckRole(userInfo) == true)
                {
                    Console.WriteLine("Please choose a number between 1 and 3!");
                    userInfo = Console.ReadLine();
                }

                switch (userInfo)
                {
                    case "1":
                        Console.WriteLine("You selected User1.");
                        Console.WriteLine("If you want to choose another user press the Tab button.");
                        Console.WriteLine("If you want to continue press Enter.");
                        user.User1();
                        break;

                    case "2":
                        Console.WriteLine("You selected User2.");
                        Console.WriteLine("If you want to choose another user press the Tab button.");
                        Console.WriteLine("If you want to continue press Enter.");
                        user.User2();
                        break;

                    case "3":
                        Console.WriteLine("You selected User3.");
                        Console.WriteLine("If you want to choose another user press the Tab button.");
                        Console.WriteLine("If you want to continue press Enter.");
                        user.User3();
                        break;
                }      
            GoBack();
        }

        public static void GoBack()
        {
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.Tab)
            {
                Console.Clear();
                ChooseRole();
            }

        }
    }
}
