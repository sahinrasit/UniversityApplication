namespace BackEnd.Model
{
    public class ApplicationResponse
    {
        public int id { get; set; }
        public int programId { get; set; }
        public string programName { get; set; }
        public string statusName { get; set; }
        public int status { get; set; }
        public string? username { get; set; }
        public string? applicationDate { get; set; }
    }
}
