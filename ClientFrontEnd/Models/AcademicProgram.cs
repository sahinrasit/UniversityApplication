using System.ComponentModel.DataAnnotations;

namespace ClientFrontEnd.Models
{
    public class AcademicProgram
    {
        [Key]
        public int id { get; set; }
        public string? programName { get; set; }
        public string? faculty { get; set; }
        public string? branch { get; set; }
        public string? term { get; set; }
    }
}
