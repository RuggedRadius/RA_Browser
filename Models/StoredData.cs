using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA_API.Models
{
    [Serializable]
    public class StoredData
    {
        public List<SupportedConsole> consoles;
        //public List<Game> games;
        //public List<Achievement> achievements;

        public StoredData()
        {
            consoles = new List<SupportedConsole>();
            //games = new List<Game>();
            //achievements = new List<Achievement>();
        }
    }
}
