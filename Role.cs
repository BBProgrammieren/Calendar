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
        this.allUsers = userManager.getListUser();
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
                    Console.Clear();
                    Console.WriteLine("Please enter Y or N!");
                    Console.WriteLine("Press enter to continue.");
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
                    userManager = new UserManager(newUserInput);
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
        UserManager uM = null;

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
                return new UserManager((string)allUsers[selection]);
            }
            else if (cki.Key == ConsoleKey.D)
            {
                deleteUser(selection);
            }
            else if (cki.Key == ConsoleKey.Q)
            {
                return null;
            }
            else if (cki.Key == ConsoleKey.W)
            {
                Console.Clear();
                Console.WriteLine("The key 'W' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.E)
            {
                Console.Clear();
                Console.WriteLine("The key 'E' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.R)
            {
                Console.Clear();
                Console.WriteLine("The key 'R' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.T)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.Z)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.U)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.I)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.O)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.P)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.A)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.S)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.F)
            {
                Console.Clear();
                Console.WriteLine("This key have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.G)
            {
                Console.Clear();
                Console.WriteLine("The key 'G' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.H)
            {
                Console.Clear();
                Console.WriteLine("The key 'H' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.J)
            {
                Console.Clear();
                Console.WriteLine("The key 'J' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.K)
            {
                Console.Clear();
                Console.WriteLine("The key 'K' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.L)
            {
                Console.Clear();
                Console.WriteLine("The key 'L' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.Y)
            {
                Console.Clear();
                Console.WriteLine("The key 'Y' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.X)
            {
                Console.Clear();
                Console.WriteLine("The key 'X' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.C)
            {
                Console.Clear();
                Console.WriteLine("The key 'C' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.V)
            {
                Console.Clear();
                Console.WriteLine("The key 'V' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.B)
            {
                Console.Clear();
                Console.WriteLine("The key 'B' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.N)
            {
                Console.Clear();
                Console.WriteLine("The key 'N' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.M)
            {
                Console.Clear();
                Console.WriteLine("The key 'M' have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
            else if (cki.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                Console.WriteLine("The spacebar have no function!");
                Console.WriteLine("Please read the info!");
                Console.WriteLine("Press enter to continue!");
                Console.ReadKey();
                Console.Clear();
                return selectUserfromList();
            }
        } while (pressedEnter = true);

        return uM;
    }

    public void deleteUser(int selection)
    {
        ConsoleKeyInfo cki;   
        Console.Clear();
        Console.WriteLine("Are you sure that you want to delete the user: " + allUsers[selection] + "?");
        Console.WriteLine("Y or N");
        cki = Console.ReadKey();

        if(cki.Key == ConsoleKey.Y)
        {
            Console.Clear();
            userManager.deleteUser((string) allUsers[selection]);
            this.allUsers = userManager.getListUser();
            this.userManager = selectUserfromList();
            new ShowCalendar(userManager);
        }
        else if (cki.Key == ConsoleKey.N)
        {
            Console.Clear();
            StartCalendar();
        }
        else
        {
            Console.WriteLine("Please press Y or N");
            Console.ReadKey();
            Console.Clear();
        }
        selection = 0;
    }

    public void showInfo()
    {
        Console.WriteLine("");
        Console.WriteLine("----------------------");
        Console.WriteLine("");
        Console.WriteLine("Infos:");
        Console.WriteLine("Press D: Delete user");
        Console.WriteLine("Press Q: Quit and go Start");
    }
}