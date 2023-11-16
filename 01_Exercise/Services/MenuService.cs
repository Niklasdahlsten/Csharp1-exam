using _01_Exercise.Interfaces;
using _01_Exercise.Models;

namespace _01_Exercise.Services;

// interface för att styra upp vad menyn ska innehålla
internal interface IMenuService
{
    public void MainMenu();
    public void CreateMenu();
    public void ListAllMenu();
    public void ListSpecificMenu();

}
internal class MenuService : IMenuService
{
    private readonly IUserService _userService = new UserService();


    // huvudmeny
    public void MainMenu()
    {
        var exit = false;

        do
        {
            Console.Clear();
            Console.WriteLine("------MENY------");
            Console.WriteLine("1. Skapa en ny användare");
            Console.WriteLine("2. Visa en spicifik Användare");
            Console.WriteLine("3. Visa alla användare");
            Console.WriteLine("4. Radera en användare");
            Console.WriteLine("0. Avsluta");
            Console.Write("Välj ett av ovanstående alternativ (0-4): ");
            var option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    CreateMenu();
                    break;

                case "2":
                    ListSpecificMenu();
                    break;

                case "3":
                    ListAllMenu();
                    break;

                case "4":
                    DeleteUserMenu();
                    break;

                case "0":
                    exit = true;
                    break;

                default:
                    break;
            }
        }
        while (exit == false);
    }
    // Skapa en ny användare
    public void CreateMenu()
    {
        Console.Clear();
        Console.WriteLine("Skapa en ny användare");
        Console.WriteLine("--------------");

        var user = new UserCreateRequest();

        Console.Write("Förnamn: ");
        user.FirstName = Console.ReadLine()!.Trim();

        Console.Write("Efternamn: ");
        user.LastName = Console.ReadLine()!.Trim();

        Console.Write("Gatuadress: ");
        user.Adress = Console.ReadLine()!.Trim();

        Console.Write("E-postadress: ");
        user.Email = Console.ReadLine()!.Trim();


        _userService.CreateUser(user);
        Console.WriteLine("En ny användare har blivit tillagt, tryck på valfri knapp för att återgå till menyn.");
        Console.ReadKey();

    }

    // Alternativ att skriva ut alla användare

    public void ListAllMenu()
    {
        Console.Clear();
        Console.WriteLine("Alla användare");
        Console.WriteLine("--------------");

        var users = _userService.GetUsers();

        foreach (var user in users)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} <{user.Email}>");
        }

        Console.ReadKey();
    }

    // alternativ för att hitta en specifik användare
    public void ListSpecificMenu()
    {
        Console.Clear();
        Console.WriteLine("Specifik användare");
        Console.WriteLine("--------------");
        Console.Write("Ange efternamn: ");
        var lastName = Console.ReadLine()!.Trim().ToLower();

        var user = _userService.GetUser(user => user.LastName == lastName);

        if (user != null) 
            Console.WriteLine($"{user.FirstName} {user.LastName} {user.Adress} <{user.Email}>");
        else 
            Console.WriteLine("Kunde inte hitta någon användare med detta efternamn. ");

        Console.ReadKey();
    }

    // Alternativ att ta bort användare  
    public void DeleteUserMenu()
    {
        Console.Clear();
        Console.WriteLine("Ta bort en användare");
        Console.WriteLine("--------------");

        Console.Write("Ange e-postadress för användaren du vill ta bort: ");
        string emailToDelete = Console.ReadLine()!;

        if (_userService.DeleteUserByEmail(emailToDelete!))
        {
            Console.WriteLine("Användaren har tagits bort.");
        }
        else
        {
            Console.WriteLine("Kunde inte hitta någon användare med den e-postadressen.");
        }

        Console.ReadKey();
    }


}
