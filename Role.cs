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
        this.allUsers = userManager.getListUser();
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
                var selectedUser = selectUserfromList();
                if (selectedUser == null)
                {
                    goto case Logger.Start;
                }
                else
                {
                    return selectedUser;
                }
                
            case Logger.NewUser:

                string newUserInput;
                Console.Clear();
                Console.WriteLine("Please enter a new user:");
                newUserInput = Console.ReadLine();

                if (check.CheckRole(newUserInput, allUsers) && newUserInput != "")
                {
                    userManager.addNewUser(newUserInput);
                    return userManager;
                }
                else if (!check.CheckRole(newUserInput, allUsers))
                {
                    Console.Clear();
                    Console.WriteLine("User already existing!");
                    Console.ReadLine();
                    goto case Logger.Start;
                }
                else if (newUserInput == "")
                {
                    Console.Clear();
                    Console.WriteLine("Enter a valid user: no empty entries allowed!");
                    Console.ReadLine();
                    goto case Logger.Start;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Unexpected problem!");
                    Console.ReadLine();
                    goto case Logger.Start;
                }
        }
        return null;
    }
    public void showUserList(int selection)
    {
        Console.Clear();
        Console.WriteLine("Please select from the list.");

        for (var i = 0; i < allUsers.Count; i++)
        {
            if (selection == i)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(allUsers[selection]);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(allUsers[i]);
            }
        }

        showInfo();
    }
  
    public UserManager selectUserfromList()
    {
        bool pressedEnter = false;  
        int selection = 0;

        showUserList(selection);       

        //alle User anzeigen in Liste und wählen

        ConsoleKeyInfo cki;

        do
        {
            cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.UpArrow)
            {
                if(selection != 0)
                {
                    selection--;
                    showUserList(selection);
                }        
            }
            else if (cki.Key == ConsoleKey.DownArrow)
            {
                if(selection <= allUsers.Count - 2)
                {
                    selection++;
                    showUserList(selection);
                }
            }
            else if (cki.Key == ConsoleKey.Enter)
            {
                pressedEnter = true;
                return userManager = new UserManager((string)allUsers[selection]);
                
            }
            else if (cki.Key == ConsoleKey.Q)
            {
                return null;
            }
        } while (pressedEnter = true);

        return null;
    }

    public void showInfo()
    {
        Console.WriteLine("");
        Console.WriteLine("----------------------");
        Console.WriteLine("");
        Console.WriteLine("Infos:");
        Console.WriteLine("Press Q: Quit and go Start");
    }



    //switch (userInfo)
    //{
    //    case "1":
    //        Console.WriteLine("You selected User1.");
    //        Console.WriteLine("If you want to choose another user press the Tab button.");
    //        Console.WriteLine("If you want to continue press Enter.");
    //        read = Console.ReadKey();
    //        if (read.Key == ConsoleKey.Tab)
    //        {
    //            break;
    //        }
    //        else
    //        {
    //            user = new UserManager("User1");
    //            break;
    //        }

    //    case "2":
    //        Console.WriteLine("You selected User2.");
    //        Console.WriteLine("If you want to choose another user press the Tab button.");
    //        Console.WriteLine("If you want to continue press Enter.");
    //        read = Console.ReadKey();
    //        if (read.Key == ConsoleKey.Tab)
    //        {
    //            break;
    //        }
    //        else
    //        {
    //            user = new UserManager("User2");
    //            break;
    //        }

    //    case "3":
    //        Console.WriteLine("You selected User3.");
    //        Console.WriteLine("If you want to choose another user press the Tab button.");
    //        Console.WriteLine("If you want to continue press Enter.");
    //        read = Console.ReadKey();
    //        if (read.Key == ConsoleKey.Tab)
    //        {
    //            break;
    //        }
    //        else
    //        {
    //            user = new UserManager("User3");
    //            break;
    //        }
    //}
    //return user;
}