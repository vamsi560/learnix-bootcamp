using AutoMapper;
using AzureBootCamp.Context;
using AzureBootCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureBootCamp
{
    public class Profiler : Profile
    {
        public Profiler()
        {
            this.CreateMap<RegisterUser, User>();
        }
    }
}
