using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data
{
    public class AcademicProgram
    {
        [Key]
        public int id { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 character in length.")]
        public string? programName { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 character in length.")]
        public string? faculty { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 character in length.")]
        public string? branch { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Must be between 1 and 50 character in length.")]
        public string? term { get; set; }
    }
}
