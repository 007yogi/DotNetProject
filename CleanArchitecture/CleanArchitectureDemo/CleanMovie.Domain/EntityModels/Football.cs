using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleanMovie.Domain.EntityModels
{
    public class Football
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string SportName { get; set; }
        public string Country { get; set; }
        public string CaptainName { get; set; }
        public int TotalPlayers { get; set; }
    }
}
