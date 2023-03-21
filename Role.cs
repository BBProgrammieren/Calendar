using Calendar.enums;
using System.Collections;

namespace Calendar;

internal class Role
{
    private ChooseRoleValidation check = new();
    private string userInfo;
    private ConsoleKeyInfo read;
    private UserManager userManager;
    private ArrayList allUsers = new ArrayList();

    public Role(UserManager userManager)
    {
        this.userManager = userManager;
        StartCalendar();
    }

    public void StartCalendar()
    {
        this.userManager = ChooseUser();
        Console.Clear();
        new ShowCalendar(userManager);
    }


    public UserManager ChooseUser()
    {
        Logger input = Logger.Start;

        ConsoleKeyInfo userInput;
        //while (user == null)
        //{
        switch (input)
        {
            case Logger.Start:
                Console.Clear();
                Console.WriteLine("Do you have already an existing user?");
                Console.WriteLine("Y OR N");
                //Console.WriteLine("User1 --- User2 --- User3");

                userInput = Console.ReadKey();

                if (userInput.Key is ConsoleKey.Y)
                {
                    goto case Logger.Check;
                }

                else if (userInput.Key is ConsoleKey.N)
                {
                    goto case Logger.NewUser;
                }

                else
                {
                    Console.WriteLine("Please enter Y or N!");
                    Console.ReadKey();
                    goto case Logger.Start;
                }
            case Logger.Check:
                this.allUsers = userManager.getListUser();
                if (allUsers.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("No users detected!");
                    Console.ReadLine();
                    goto case Logger.Start;
                }
                else
                {
                    goto case Logger.Signin;
                }


            case Logger.Signin:
                return selectUserfromList();

            case Logger.NewUser:

                string newUserInput;
                Console.Clear();
                Console.WriteLine("Please enter a new user:");
                newUserInput = Console.ReadLine();

                if (check.CheckRole(newUserInput) && newUserInput != "")
                {
                    userManager.addNewUser(newUserInput);
                    return userManager;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Enter a valid user");
                    Console.ReadLine();
                    goto case Logger.Start;
                }
        }
        return null;
    }
    //    userInfo = Console.ReadLine();

    //    while (check.CheckRole(userInfo) == true)
    //    {
    //        Console.WriteLine("Please choose a number between 1 and 3!");
    //        userInfo = Console.ReadLine();
    //    }

    //    switch (userInfo)
    //    {
    //        case "1":
    //            Console.WriteLine("You selected User1.");
    //            Console.WriteLine("If you want to choose another user press the Tab button.");
    //            Console.WriteLine("If you want to continue press Enter.");
    //            read = Console.ReadKey();
    //            if (read.Key == ConsoleKey.Tab)
    //            {
    //                break;
    //            }
    //            else
    //            {
    //                user = new UserManager("User1");
    //                break;
    //            }

    //        case "2":
    //            Console.WriteLine("You selected User2.");
    //            Console.WriteLine("If you want to choose another user press the Tab button.");
    //            Console.WriteLine("If you want to continue press Enter.");
    //            read = Console.ReadKey();
    //            if (read.Key == ConsoleKey.Tab)
    //            {
    //                break;
    //            }
    //            else
    //            {
    //                user = new UserManager("User2");
    //                break;
    //            }

    //        case "3":
    //            Console.WriteLine("You selected User3.");
    //            Console.WriteLine("If you want to choose another user press the Tab button.");
    //            Console.WriteLine("If you want to continue press Enter.");
    //            read = Console.ReadKey();
    //            if (read.Key == ConsoleKey.Tab)
    //            {
    //                break;
    //            }
    //            else
    //            {
    //                user = new UserManager("User3");
    //                break;
    //            }
    //    }
    //    return user;
    //}

    public UserManager selectUserfromList()
    {

        Console.Clear();
        Console.WriteLine("Please select from the list.");

        for (var i = 1; i <= allUsers.Count; i++)
        {
            Console.WriteLine(allUsers[i]);
        }
        //alle User anzeigen in Liste und wählen
        Console.ReadLine();
        return userManager;
    }
}