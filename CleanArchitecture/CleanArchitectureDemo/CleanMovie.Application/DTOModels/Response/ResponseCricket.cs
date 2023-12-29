using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.DTOModels.Response
{
    public class ResponseCricket
    {
        public int Id { get; set; }
        public string SportName { get; set; }
        public string Country { get; set; }
        public string CaptainName { get; set; }
        public int TotalPlayers { get; set; }
        public string CreatedBy {get; set; }
        public DateTime CreatedDate {get; set; }
        /*public string ModifiedBy { get; set;}
        public DateTime ModifyDate { get; set;}*/
    }
}
