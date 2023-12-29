using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleanMovie.Domain.EntityModels
{
    [Table("Cricket")]
    public class Cricket
    {
        public int Id { get; set; }
        public string SportName { get; set; }
        public string Country { get; set; }
        public string CaptainName { get; set; }
        public int TotalPlayers { get; set;}
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
