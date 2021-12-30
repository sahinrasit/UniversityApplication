using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data
{
    public class SiteUser
    {
        [Key]
        public string userName { get; set; }
        public string? password { get; set; }
        public string? name { get; set; }
        public string? family { get; set; }
        public string? tcNumber { get; set; }
        public string? gender { get; set; }
        public string? birthDate { get; set; }
        public string? regDate { get; set; }
        public bool permApply { get; set; }
        public bool permControl { get; set; }
        public bool permDecision { get; set; }
        public bool permAdmin { get; set; }

    }
}
