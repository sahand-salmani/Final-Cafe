using AutoMapper;
using Domain.Models;
using Infrastructure.Partners.Commands;
using Infrastructure.Partners.ViewModels;
using Infrastructure.Spends.Commands;
using Infrastructure.Spends.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Partners.Profiles
{
    public class PartnerProfile:Profile
    {
        public PartnerProfile()
        {
            CreateMap<GetPartnersVm, Partner>().ReverseMap();
            CreateMap<CreatePartnersVm, CreatePartnersCommand>().ReverseMap();
            CreateMap<CreatePartnersVm, Partner>().ReverseMap();
            CreateMap<EditPartnersVm, Partner>().ReverseMap();

        }
    }
}
