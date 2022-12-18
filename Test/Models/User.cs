using Microsoft.Build.Framework;

namespace Test.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Is_Admin { get; set; }
        [Required]
        public int Job_id { get; set; }
        public DateTime? Date_of_birth { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool Can_access_private { get; set; }
    }
}
