using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MovieHub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "G",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out DateTime dateTime);

            return (isValid && dateTime > DateTime.Now);
        }
    }
}