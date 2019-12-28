using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA_API.Connection
{
    class Utilities
    {
        public static bool InternetConnected ()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    Console.WriteLine("Internet connection status: CONNECTED");
                    return true;
            }
            catch
            {
                Console.WriteLine("Internet connection status: DISCONNECTED");
                return false;
            }
        }
    }
}
