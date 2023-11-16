namespace _01_Exercise.Models;

// Informationen som krävs för skapande av ny användare
internal class UserCreateRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Adress { get; set; } = null!;
    public string Email { get; set; } = null!;

}
