namespace Test
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Is_Admin { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int Department_id { get; set; }
        public int Access_id { get; set; }
        public DateTime? Date_of_birth { get; set; }
        public bool Can_access_private { get; set; }
    }
}
