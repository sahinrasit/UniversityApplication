using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data
{
    public class Applications
    {
        [Key]
        public int id { get; set; }
        public int programId { get; set; }
        public int status { get; set; }
        public string? username { get; set; }
        public string? applicationDate { get; set; }
    }
}
