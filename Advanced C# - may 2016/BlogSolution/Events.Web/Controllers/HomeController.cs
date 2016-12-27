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
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var events = this.db.Events
                .OrderBy(e => e.StartDateTime)
                .Where(e => e.IsPublic)
                .Select(EventViewModel.ViewModel);

            var upcomingEvents = events.Where(e => e.StartDateTime > DateTime.Now);
            var passedEvents = events.Where(e => e.StartDateTime < DateTime.Now);

            return View(new UpcomingPassedEventViewModel()
            {
                UpcomingEvents = upcomingEvents,
                PassedEvents = passedEvents
            });

        }

        public ActionResult EventDetailsById(int id)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var isAdmin = this.IsAdmin();
            var eventDetails = this.db.Events
                .Where(e => e.Id == id)
                .Where(e => e.IsPublic || isAdmin || (e.Author.Id == null && e.AuthorId == currentUserId))
                .Select(EventDetailsViewModel.ViewModel)
                .FirstOrDefault();

            var isOwner = (eventDetails != null && eventDetails.AuthorId != null && eventDetails.AuthorId == currentUserId);
            this.ViewBag.CanEdit = isOwner || isAdmin;

            return this.PartialView("_EventDetails", eventDetails);
        }

        [HttpGet]
        public ActionResult AddComment(int id)
        {
            return this.PartialView("_AddComment"); 
        }

        [HttpPost]
        public ActionResult AddComment(int id, CommentViewModel model)
        {
            var targetEvent = this.db.Events
                .Where(e => e.Id == id)
                .FirstOrDefault();

            if (targetEvent != null && ModelState.IsValid)
            {
                var comment = new Comment
                {
                    Text = model.Text,
                    Event = targetEvent,
                    AuthorId = this.User.Identity.GetUserId()
                };

                targetEvent.Comments.Add(comment);
                this.db.SaveChanges();
                this.AddNotification("Comment added!", NotificationType.SUCCESS);
                return this.RedirectToAction("Index");
            }

            return this.PartialView("_AddComment", model);
        }
    }
}