using CleanMovie.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application.Interfaces.ISports
{
    public interface IFootballRepository
    {
        string BoardName();
        string TeamName();
        string CaptainName();
        int TotalPlayers();
        Task<Football> InsertFootBallData(Football football);
    }
}
