using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeLogger.Models
{
    public class CorsOptions
    {
        public const string Cors = "Cors";

        public string[] Origins { get; set; }
    }
}
