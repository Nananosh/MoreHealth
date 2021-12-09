using AutoMapper;
using ItransitionCourseProject.ViewModels.Account;
using MoreHealth.Models;

namespace MoreHealth.ViewModels.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<DepartmentViewModel, Department>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom
                        (src => src.Id))
                .ForMember(dest => dest.DepartmentName,
                    opt => opt.MapFrom
                        (src => src.DepartmentName))
                .ForMember(dest => dest.Specializations,
                    opt => opt.Ignore()).ReverseMap();

            CreateMap<SpecializationViewModel, Specialization>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom
                        (src => src.Id))
                .ForMember(dest => dest.SpecializationName,
                    opt => opt.MapFrom
                        (src => src.SpecializationName))
                .ForMember(dest => dest.Doctors,
                    opt => opt.Ignore())
                .ForMember(dest => dest.Department,
                    opt => opt.Ignore()).ReverseMap();
            CreateMap<AppointmentViewModel, Appointment>()
                .ForMember(x => x.Address,
                    opt => opt.MapFrom(src => src.Address))
                .ForMember(x => x.DateStart,
                    opt => opt.MapFrom(src => src.DateStart))
                .ForMember(x => x.DateEnd,
                    opt => opt.MapFrom(src => src.DateEnd))
                .ForMember(x => x.Doctor,
                    opt => opt.MapFrom(src => src.Doctor))
                .ForMember(x => x.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Patient,
                    opt => opt.Ignore()).ReverseMap();
            CreateMap<DoctorViewModel, Doctor>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom
                        (src => src.Id))
                .ForMember(dest => dest.User,
                    opt => opt.MapFrom
                        (src => src.User))
                .ForMember(dest => dest.Specialization,
                    opt => opt.MapFrom
                        (src => src.Specialization))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom
                        (src => src.Name))
                .ForMember(dest => dest.Surname,
                    opt => opt.MapFrom
                        (src => src.Surname))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom
                        (src => src.LastName))
                .ForMember(dest => dest.Feedbacks,
                    opt => opt.Ignore())
                .ForMember(dest => dest.Cabinet,
                    opt => opt.Ignore())
                .ForMember(dest => dest.WorkSchedules,
                    opt => opt.Ignore()).ReverseMap();
        }
    }
}