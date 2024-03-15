using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AWWW_lab2_gr2.Models;

public class EventTypeController : Controller{

    public IEventTypeResult Index(int id=1)
        {
            var eventTypes = new List<EventType>{
                new EventType{
                    Id = 1,
                    Name = "EventType 1"
                },
                new EventType{
                    Id = 2,
                    Name = "EventType 2"
                },
                new EventType{
                    Id = 3,
                    Name = "EventType 3"
                }
            };
            
            return View(articles[id-1]);
        }
}