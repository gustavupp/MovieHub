﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieHub.Models
{
    public class Attendance
    {
        
        [Key]
        [Column(Order = 1)]
        public int UpcomingMovieId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }

        //Navigation Properties
        public UpcomingMovie UpcomingMovie { get; set; }
        public ApplicationUser Attendee { get; set; }
    }
}