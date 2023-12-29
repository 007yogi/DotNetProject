using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.DTOModels.Request
{
    public class RequestCricket
    {
        public string SportName { get; set; }
        public string Country { get; set; }
        public string CaptainName { get; set; }
        public int TotalPlayers { get; set; }
    }
}
