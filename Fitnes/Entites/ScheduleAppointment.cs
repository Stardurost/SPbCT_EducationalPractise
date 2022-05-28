using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Entites
{
    internal class ScheduleAppointment
    {
        public int ScheduleId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Date { get; set; }
        public string Trainer { get; set; }

        public AppointmentType AppointmentType { get; set; }
    }
}
