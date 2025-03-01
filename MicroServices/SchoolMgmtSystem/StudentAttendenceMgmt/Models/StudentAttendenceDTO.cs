namespace StudentAttendenceMgmt.Models
{
    public class StudentAttendenceDTO
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentClass { get; set; }
        public double AttendencePercentage { get; set; }
    }
}
