using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLogger.Entities;

namespace TimeLogger.Dto
{
    public class TimeRegisterDto
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public float Hours { get; set; }

        public void FillWithTimeRegister(TimeRegister timeRegister)
        {
            Id = timeRegister.Id;
            Date = timeRegister.Date;
            Hours = timeRegister.Hours;
        }
    }
}
