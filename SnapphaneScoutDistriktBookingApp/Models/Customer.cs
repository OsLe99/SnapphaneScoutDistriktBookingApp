﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapphaneScoutDistriktBookingApp.Models
{
    internal class Customer
    {
        public enum TypeOfBooking
        {
            Canoe,
            CampGrounds,
            LeanTo,
            Cabin
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsOrg { get; set; }
        public string? OrgName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TypeOfBooking BookingType { get; set; }
    }
}
