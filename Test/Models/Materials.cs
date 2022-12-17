using Microsoft.Build.Framework;

namespace Test
{
    public class Materials
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string File { get; set; }
        [Required]
        public bool Is_Public { get; set; }
    }
}
