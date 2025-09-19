using AzureBootCamp.Context;
using AzureBootCamp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureBootCamp.Controllers
{
    public class SessionsController : Controller
    {
    // private readonly AZBootcamp2021DBContext context;
    // private readonly SessionModel sessionModel;

        // public SessionsController(AZBootcamp2021DBContext context, SessionModel sessionModel)
        // {
        //     this.context = context;
        //     this.sessionModel = sessionModel;
        // }

        public IActionResult SessionInfo(int id)
        {
            // if (id != 0)
            // {
            //     int topicId = Convert.ToInt32(id);
            //     sessionModel.Topic = context.Topics.Where(topic => topic.TopicId == topicId).Include(topic => topic.TopicSpeakers).ThenInclude(topicSpeaker => topicSpeaker.Speaker).FirstOrDefault();
            //     // var sessionLinks = context.SessionLinks.Where(sessionLinkData => sessionLinkData.TrackId == sessionModel.Topic.TrackId);
            //     foreach (var item in sessionLinks)
            //     {
            //         if (DateTime.UtcNow > item.SessionTime.AddHours(-1) && DateTime.UtcNow < item.SessionTime.AddHours(10))
            //         {
            //             sessionModel.SessionLink = item;
            //         }
            //     }
            //     return View("SessionInfo", sessionModel);
            // }
            return View();
        }
    }
}
