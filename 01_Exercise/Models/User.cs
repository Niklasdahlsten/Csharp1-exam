namespace _01_Exercise.Models;

// Den info vi vill ha ifylld av användaren
internal class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Adress { get; set; } = null!;
    public string Email { get; set; } = null!; 


}
