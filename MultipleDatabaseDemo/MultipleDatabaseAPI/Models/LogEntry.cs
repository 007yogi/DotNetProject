namespace MultipleDatabaseAPI.Models
{
    public class LogEntry
    {
        public int id { get; set; }
        public string LogMessage { get; set; }
        public string LogMethod { get; set; }
        public string LogController { get; set; }
        public string LogFile { get; set; }
        public DateTime LogDate { get; set; }
    }
}
