using AzureBootCamp.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureBootCamp.Controllers
{
    public class TracksController : Controller
    {
        private readonly AZBootcamp2021DBContext context;

        public TracksController(AZBootcamp2021DBContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            TempData["Tracks"] = context.Tracks.Include(track => track.Topics.Where(topic => topic.IsActive == true).OrderBy(trackTopic => trackTopic.OrderNo)).ThenInclude(topic => topic.TopicSpeakers).ThenInclude(topicSpeaker => topicSpeaker.Speaker).ToList();
            return View();
        }
    }
}
