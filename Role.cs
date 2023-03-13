using Calendar.enums;

namespace Calendar;

internal class Role
{
    private ChooseRoleValidation check = new();
    private string userInfo;
    private ConsoleKeyInfo read;

    public void StartCalendar()
    {
        var user = ChooseUser();
        Console.Clear();
        new ShowCalendar(user);
    }


    public UserManager ChooseUser()
    {
        Logger input = Logger.Start;
        UserManager user = null;
        //while (user == null)
        //{
        switch (input)
        {
            case Logger.Start:
                break;
        }

        Console.Clear();
        Console.WriteLine("Do you have already an existing user?");
        Console.WriteLine("Y OR N");
        Console.WriteLine("User1 --- User2 --- User3");

        var userInput = Console.ReadLine();
        if (userInput is "y" or "Y")
        {
        }

        else if (userInput is "n" or "N")
        {
        }


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
                    user = new UserManager("User1");
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
                    user = new UserManager("User2");
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
                    user = new UserManager("User3");
                    break;
                }
        }
        return user;
    }
}