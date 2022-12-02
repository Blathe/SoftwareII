using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SoftwareII.Models;

namespace SoftwareII.Services
{
    public static class AppointmentService
    {
        public static int open = 8; // 8 AM
        public static int close = 18; // 6 PM

        public static bool DoAppointmentsOverlap(DateTime dateToCheck)
        {
            Console.WriteLine("Checking Date: " + dateToCheck);
            var allAppointments = Program.DBService.GetAllAppointments();
            foreach (var appointment in allAppointments)
            {
                var start = appointment.start;
                var end = appointment.end;
                Console.WriteLine(string.Format("Appointment - Start: {0} | End: {1}", start, end));
                if (dateToCheck >= start && dateToCheck <= end) {
                    MessageBox.Show("An appointment is already booked during that time, try another date or time.");
                    return true;
                }
            }
            return false;
        }

        public static bool WithinBusinessHours(DateTime dateToCheck)
        {
            if (dateToCheck.DayOfWeek == DayOfWeek.Sunday || dateToCheck.DayOfWeek == DayOfWeek.Saturday)
            {
                MessageBox.Show("Business hours are closed on weekends. Try scheduling the appointment for a week day.");
                return false;
            }

            if (dateToCheck.Hour <= open || dateToCheck.Hour >= close)
            {
                MessageBox.Show("You are trying to schedule this appointment outside of business hours. Try between 8 AM and 6 PM UTC time.");
                return false;
            }

            return true;
        }
    }
}
