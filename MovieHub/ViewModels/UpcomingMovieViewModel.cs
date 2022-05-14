using MovieHub.Controllers;
using MovieHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace MovieHub.ViewModels
{
    public class UpcomingMovieViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        [FutureDate]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int RunningTime { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public byte MovieGenreId { get; set; }

        public IEnumerable<MovieGenres> MovieGenres { get; set; }

        public string  Heading { get; set; }

        public string Action 
        {
            get 
            {
                //simpler way of doing, but using 'magic strings'
                //return (Id != 0) ? "Update" : "Create";  

                //using lambdas you don't have to worry about the method name changing
                Expression<Func<UpcomingMoviesController, ActionResult>> update = c => c.Update(this);
                Expression<Func<UpcomingMoviesController, ActionResult>> create = c => c.Create(this);

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }


    }
}