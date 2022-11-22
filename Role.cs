using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class Role
    {
        public void StartCalendar()
        {
            ChooseRole();
        }
        public static void ChooseRole()
        {
            ChooseRoleValidation check = new ChooseRoleValidation();
            User user = new User();

            Console.WriteLine("Please choose an user! Enter a number between 1 and 3.");
            Console.WriteLine("User1 --- User2 --- User3");

            var userInfo = Console.ReadLine();

            while (check.CheckRole(userInfo) == true)
            {
                Console.WriteLine("Please choose a number between 1 and 3!");
                userInfo = Console.ReadLine();
            }

            switch(userInfo)
            {
                case "1":
                    Console.WriteLine("You selected User1. If you want to choose another user press the ESC button.");
                    user.User1();
                    break;

                case "2": 
                    Console.WriteLine("You selected User2. If you want to choose another user press the ESC button.");
                    user.User2();
                    break;

                case "3":
                    Console.WriteLine("You selected User3.");
                    Console.WriteLine("If you want to choose another user press the ESC button.");
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

            if (cki.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                ChooseRole();
            }
            
        }
    }
}
