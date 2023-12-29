namespace JwtAuthDemo.Models
{
    [Serializable]
    public class JwtAuthResponce
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public int ExpireIn { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
