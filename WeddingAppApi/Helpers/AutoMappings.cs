using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WeddingAppApi.DataObjects;
using WeddingAppApi.Models;

namespace WeddingAppApi.Helpers
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            CreateMap<MainPreparationInputObject, Preparation >();
            CreateMap<Preparation, MainPreparationOutputObject >();
            CreateMap<MainPreparationInputObject, SubPreparation >();
            CreateMap<SubPreparation, MainPreparationOutputObject >();
            CreateMap<Category, CategoryOutputObject>();
            CreateMap<Guest,GuestOutputObject>();
            CreateMap<Event,EventOutputObject>();
            CreateMap<Vendor,VendorOutputObject>();
            CreateMap<Invitation,InvitationObject>().AfterMap((src,dest) => dest.Action="add");
        }
    }
}