using Events.Data;
using Events.Web.Extensions;
using Events.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Events.Web.Controllers
{
    [Authorize]
    public class EventsController : BaseController
    {
        // GET: Event
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var e = new Event()
                {
                    AuthorId = this.User.Identity.GetUserId(),
                    Title = model.Title,
                    StartDateTime = model.StartDateTime,
                    Duration = model.Duration,
                    Description = model.Description,
                    Location = model.Location,
                    IsPublic = model.IsPublic
                };
                this.db.Events.Add(e);
                this.db.SaveChanges();
                this.AddNotification("Event Created.", NotificationType.INFO);
                return this.RedirectToAction("My");
            }

            return this.View(model);
        }

        // Get: Events/My
        public ActionResult My()
        {
            var userId = this.User.Identity.GetUserId();
            var myEvents = this.db.Events
                .OrderBy(e => e.StartDateTime)
                .Where(e => e.AuthorId == userId)
                .Select(EventViewModel.ViewModel);

            var upcomingEvents = myEvents.Where(e => e.StartDateTime > DateTime.Now);
            var passedEvents = myEvents.Where(e => e.StartDateTime < DateTime.Now);

            return this.View(new UpcomingPassedEventViewModel()
            {
                UpcomingEvents = upcomingEvents,
                PassedEvents = passedEvents
            });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var eventToEdit = this.LoadEvent(id);
            if (eventToEdit == null)
            {
                this.AddNotification("Cannot edit event #" + id, NotificationType.ERROR);
                return this.RedirectToAction("My");
            }

            var model = EventInputModel.CreateFromEvent(eventToEdit);
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventInputModel model)
        {
            var eventToEdit = this.LoadEvent(id);
            if (eventToEdit == null)
            {
                this.AddNotification("Cannot Edit event #" + id, NotificationType.ERROR);
                return this.RedirectToAction("My");
            }

            if (model != null && this.ModelState.IsValid)
            {
                eventToEdit.Title = model.Title;
                eventToEdit.StartDateTime = model.StartDateTime;
                eventToEdit.Duration = model.Duration;
                eventToEdit.Description = model.Description;
                eventToEdit.Location = model.Location;
                eventToEdit.IsPublic = model.IsPublic;

                this.db.SaveChanges();
                this.AddNotification("Event edited.", NotificationType.INFO);
                return this.RedirectToAction("My");
            }

            return this.View(model);
        } 

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var eventToDelete = this.LoadEvent(id);
            if (eventToDelete == null)
            {
                this.AddNotification("Cannot delete event #" + id, NotificationType.ERROR);
                return this.RedirectToAction("My");
            }

            var model = EventInputModel.CreateFromEvent(eventToDelete);
            return this.View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, EventInputModel model)
        {
            var eventToDelete = this.LoadEvent(id);
            this.db.Events.Remove(eventToDelete);
            this.db.SaveChanges();

            this.AddNotification("Event deleted.", NotificationType.SUCCESS);
            return this.RedirectToAction("My");
        }

        

        private Event LoadEvent(int id)
        {
            var currentUserID = this.User.Identity.GetUserId();
            var isAdmin = this.IsAdmin();
            var eventToEdit = this.db.Events
                .Where(e => e.Id == id)
                .FirstOrDefault(e => e.AuthorId == currentUserID || isAdmin);
            return eventToEdit;
        }
    }
}