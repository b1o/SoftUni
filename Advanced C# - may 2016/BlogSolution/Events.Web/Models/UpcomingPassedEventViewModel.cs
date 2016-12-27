using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Events.Web.Models
{
    public class UpcomingPassedEventViewModel
    {
        public IEnumerable<EventViewModel> UpcomingEvents { get; set; }

        public IEnumerable<EventViewModel> PassedEvents { get; set; }
    }
}