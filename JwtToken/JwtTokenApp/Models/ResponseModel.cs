namespace JwtTokenApp.Models
{
    public class ResponseModel
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public int ExpireIn { get; set; }
        public DateTime EntryDate { get; set; }
        public string UserMessage { get; set; }
    }
}
