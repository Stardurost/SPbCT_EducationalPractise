using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnes.Utils
{
    internal class ScheduleGenerator
    {
        private DateTime _startDate; // инициилизируем начальную и конечную даты
        private DateTime _endDate;   //
        private List<Entites.WorkDay> _TrainerSchedule;  // создаем список расписания рабочих дней

        // конструктор
        public ScheduleGenerator(DateTime startDate, 
            DateTime endDate, List<Entites.WorkDay> schedule)
        {
            _startDate = startDate;
            _endDate = endDate;
            _TrainerSchedule = schedule
                .Where(p => p.Date >= _startDate.Date && p.Date <= _endDate.Date).ToList();
        }

        // конструктор заголовков
        public List<Entites.ScheduleHeader> GenerateHeaders()
        {
            var result = new List<Entites.ScheduleHeader>();

            var startDate = _startDate;

            while (startDate.Date < _endDate.Date)
            {
                result.Add(new Entites.ScheduleHeader
                { Date = startDate.Date });

                startDate = startDate.AddDays(1);
            }

            return result;
        }

        
        public List<List<Entites.ScheduleAppointment>> GenerateAppointments(List<Entites.ScheduleHeader> headers)
        {
            var result = new List<List<Entites.ScheduleAppointment>>();

            if (_TrainerSchedule.Count() > 0)
            {
             
                var minStartTime = _TrainerSchedule.Min( p => p.StartTime); // поиск начала рабочего дня
                var maxEndTime = _TrainerSchedule.Max(p => p.EndTime);      // поиск окончания рабочего дня
                var Date = _TrainerSchedule[0].Date;

                var startTime = minStartTime;                // стартовое время для увеличения значения
               
                while (startTime < maxEndTime)
                {
                    // по горизонтали 

                    var AppointmentsPerInterval = new List<Entites.ScheduleAppointment>();

                    foreach (var header in headers)
                    {
                        var currentSchedule = _TrainerSchedule.FirstOrDefault(p => p.Date == header.Date);
                        var ScheduleAppointment = new Entites.ScheduleAppointment
                        {
                            ScheduleId = currentSchedule?.Id ?? -1,
                            StartTime = startTime,
                            EndTime = startTime.Add(TimeSpan.FromMinutes(60)),
                            Date = Date
                        };
                        // Определение типа ячейки для записи
                        if (currentSchedule != null)
                        {
                            var BusyAppoimntment = currentSchedule.Appointments.
                                FirstOrDefault(p => p.StartTime == startTime);
                            // если есть запись пациента, то занято
                            if (BusyAppoimntment != null)
                            {
                                ScheduleAppointment.AppointmentType = Entites.AppointmentType.Busy;
                            }
                            // если нет записи, то свободно
                            else
                            {
                                // определение границ рабочего дня
                                if (startTime < currentSchedule.StartTime
                                    || startTime > currentSchedule.EndTime)
                                {
                                    ScheduleAppointment.AppointmentType = Entites.AppointmentType.DayOff;
                                }
                                else
                                {
                                    ScheduleAppointment.AppointmentType = Entites.AppointmentType.Free;
                                }
                            }
                        }
                        else
                        {
                            ScheduleAppointment.AppointmentType = Entites.AppointmentType.DayOff;
                        }

                        AppointmentsPerInterval.Add(ScheduleAppointment);

                    }

                    result.Add(AppointmentsPerInterval);
                    startTime = startTime.Add(TimeSpan.FromMinutes(60));
                    Date = Date.AddDays(1);
                }
            }

            return result;
        }
        /*
         *   

        */

    }
}
