using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class Role
    {
        private ChooseRoleValidation check = new ChooseRoleValidation();
        private string userInfo;
        private ConsoleKeyInfo read;

        public void StartCalendar()
        {
            User user = ChooseUser();
            Console.Clear();
            new ShowCalendar(user);
        }
        public User ChooseUser()
        {
            User user = null;
            while (user == null)
            {
                Console.Clear();
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
                        read = Console.ReadKey();
                        if (read.Key == ConsoleKey.Tab)
                        {
                            break;
                        }
                        else
                        {
                            user = new User("User1");
                            break;
                        }

                    case "2":
                        Console.WriteLine("You selected User2.");
                        Console.WriteLine("If you want to choose another user press the Tab button.");
                        Console.WriteLine("If you want to continue press Enter.");
                        read = Console.ReadKey();
                        if (read.Key == ConsoleKey.Tab)
                        {
                            break;
                        }
                        else
                        {
                            user = new User("User2");
                            break;
                        }                   

                    case "3":
                        Console.WriteLine("You selected User3.");
                        Console.WriteLine("If you want to choose another user press the Tab button.");
                        Console.WriteLine("If you want to continue press Enter.");
                        read = Console.ReadKey();
                        if (read.Key == ConsoleKey.Tab)
                        {
                            break;
                        }
                        else
                        {
                            user = new User("User3");
                            break;
                        }
                }
            }
            return user;
        }
    }     
    }

