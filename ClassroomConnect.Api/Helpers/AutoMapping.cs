using AutoMapper;
using ClassroomConnect.Api.ViewModels;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassroomConnect.Api.Profiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Address, AddressViewModel>();
            CreateMap<Allergy, AllergyViewModel>();
            CreateMap<Child, ChildViewModel>()
                .ForMember(dest => dest.Allergies,
                opts => opts.MapFrom(src => src.Allergies));
            CreateMap<Child, StudentViewModel>();
            CreateMap<Classroom, ClassroomViewModel>();
            CreateMap<Contact, ContactViewModel>().ForMember(dest => dest.Address,
                opts => opts.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone,
                opts => opts.MapFrom(src => src.Phone));
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Family, FamilyViewModel>();
            CreateMap<Family, FamilyDetailViewModel>();
            CreateMap<Guardian, GuardianViewModel>()
                .ForMember(dest => dest.HomeAddress,
                opts => opts.MapFrom(src => src.HomeAddress))
                .ForMember(dest => dest.MobilePhone,
                opts => opts.MapFrom(src => src.MobilePhone))
                .ForMember(dest => dest.WorkAddress,
                opts => opts.MapFrom(src => src.WorkAddress))
                .ForMember(dest => dest.WorkPhone,
                opts => opts.MapFrom(src => src.WorkPhone));
            CreateMap<Phone, PhoneViewModel>();
        }
    }
}
