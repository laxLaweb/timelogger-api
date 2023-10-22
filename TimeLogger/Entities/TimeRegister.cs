using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeLogger.Entities
{
    public class TimeRegister
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Date { get; set; }
        public float Hours { get; set; }
    }
}
