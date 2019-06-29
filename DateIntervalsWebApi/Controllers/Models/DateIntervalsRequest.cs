using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateIntervalsWebApi.Controllers.Models
{
    public class DateIntervalsRequest
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}