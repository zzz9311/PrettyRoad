namespace PrettyRoad.DAL.Entities;

public class User
{
    public Guid ID { get; init; }
    public string Name { get; set; }
    public DateTime RegistrationDate { get; init; } = DateTime.UtcNow;
    public string Login { get; init; }
    public string Password { get; set; }
    public string Email { get; set; }
}