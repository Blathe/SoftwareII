using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SoftwareII.Models;

namespace SoftwareII.Services
{
    public static class AppointmentService
    {
        public static bool DoAppointmentsOverlap(DateTime dateToCheck)
        {
            var allAppointments = Program.DBService.GetAllAppointments();
            foreach (var appointment in allAppointments)
            {
                var start = appointment.start;
                var end = appointment.end;
                if (dateToCheck > start && dateToCheck < end) {
                    MessageBox.Show("An appointment is already booked during that time, try another date or time.");
                    return true;
                }
            }

            return false;
        }
    }
}
