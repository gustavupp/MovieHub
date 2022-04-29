using Microsoft.AspNet.Identity;
using MovieHub.Dtos;
using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieHub.Controllers
{

    [Authorize]
    public class AttendancesController : ApiController
    {

        private ApplicationDbContext _context;

        public AttendancesController()
        {
             _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();

            var exists = _context.Attendances
                .Any(a => a.UpcomingMovieId == attendanceDto.UpcomingMovieId && a.AttendeeId == userId);

            if (exists)
                return BadRequest("Attendance alaredy exists.");


            var attendance = new Attendance()
            {
                UpcomingMovieId = attendanceDto.UpcomingMovieId,
                AttendeeId = userId,
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok("Attendence included");
        }

        [HttpGet]
        public IHttpActionResult test()
        {
            return Ok("all good");
        }
    }
}
