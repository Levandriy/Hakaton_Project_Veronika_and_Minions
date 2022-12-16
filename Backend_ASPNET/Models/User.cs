namespace Backend_ASPNET.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; } // имя пользователя
        public int? Access_id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
