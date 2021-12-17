using AutoMapper;
using MoreHealth.ViewModels.Account;

namespace MoreHealth.ViewModels.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<DepartmentViewModel, Models.Department>()
                .ForMember(d => d.Id, opt => opt.MapFrom(dvm => dvm.Id))
                .ForMember(d => d.DepartmentName, opt => opt.MapFrom(dvm => dvm.DepartmentName))
                .ForMember(d => d.Specializations, opt => opt.Ignore()).ReverseMap();
            CreateMap<SpecializationViewModel, Models.Specialization>()
                .ForMember(s => s.Id, opt => opt.MapFrom(svm => svm.Id))
                .ForMember(s => s.SpecializationName, opt => opt.MapFrom(svm => svm.SpecializationName))
                .ForMember(s => s.Doctors, opt => opt.Ignore())
                .ForMember(s => s.Department, opt => opt.Ignore()).ReverseMap();
            CreateMap<AppointmentHomeViewModel, Models.AppointmentHome>()
                .ForMember(ah => ah.Id, opt => opt.MapFrom(ahvm => ahvm.Id))
                .ForMember(ah => ah.PatientId, opt => opt.MapFrom(ahvm => ahvm.PatientId))
                .ForMember(ah => ah.Address, opt => opt.MapFrom(ahvm => ahvm.Address))
                .ForMember(ah => ah.Patient,  opt => opt.Ignore())
                .ForMember(ah => ah.Date, opt => opt.MapFrom(ahvm => ahvm.Date)).ReverseMap();
            CreateMap<FeedbackViewModel, Models.Feedback>()
                .ForMember(f => f.Id, opt => opt.MapFrom(fvm => fvm.Id))
                .ForMember(f => f.PatientId, opt => opt.MapFrom(fvm => fvm.PatientId))
                .ForMember(f => f.Patient, opt => opt.Ignore())
                .ForMember(f => f.Doctor, opt => opt.Ignore())
                .ForMember(f => f.DoctorId, opt => opt.MapFrom(fvm => fvm.DoctorId))
                .ForMember(f => f.IsLike, opt => opt.MapFrom(fvm => fvm.IsLike))
                .ForMember(f => f.Text, opt => opt.MapFrom(fvm => fvm.Text)).ReverseMap();
            CreateMap<AppointmentViewModel, Models.Appointment>()
                .ForMember(a => a.Address, opt => opt.MapFrom(avm => avm.Address))
                .ForMember(a => a.PatientId, opt => opt.MapFrom(avm => avm.PatientId))
                .ForMember(a => a.DateStart, opt => opt.MapFrom(avm => avm.DateStart))
                .ForMember(a => a.DateEnd, opt => opt.MapFrom(avm => avm.DateEnd))
                .ForMember(a => a.Doctor,opt => opt.MapFrom(avm => avm.Doctor))
                .ForMember(a => a.Id, opt => opt.MapFrom(avm => avm.Id))
                .ForMember(a => a.Patient, opt => opt.Ignore()).ReverseMap();
            CreateMap<DoctorViewModel, Models.Doctor>()
                .ForMember(d => d.Id, opt => opt.MapFrom(dvm => dvm.Id))
                .ForMember(d => d.User, opt => opt.MapFrom(dvm => dvm.User))
                .ForMember(d => d.Specialization, opt => opt.MapFrom(dvm => dvm.Specialization))
                .ForMember(d => d.Name, opt => opt.MapFrom(dvm => dvm.Name))
                .ForMember(d => d.Surname, opt => opt.MapFrom(dvm => dvm.Surname))
                .ForMember(d => d.LastName, opt => opt.MapFrom(dvm => dvm.LastName))
                .ForMember(d => d.Feedbacks, opt => opt.Ignore())
                .ForMember(d => d.Cabinet, opt => opt.Ignore())
                .ForMember(d => d.WorkSchedules, opt => opt.Ignore()).ReverseMap();
            CreateMap<WorkScheduleViewModel, Models.WorkSchedule>()
                .ForMember(ws => ws.DoctorId, opt => opt.MapFrom(wsvm => wsvm.DoctorId))
                .ForMember(ws => ws.RecurrenceRule, opt => opt.MapFrom(wsvm => wsvm.RecurrenceRule))
                .ForMember(ws => ws.StartDate, opt => opt.MapFrom(wsvm => wsvm.StartDate))
                .ForMember(ws => ws.EndDate, opt => opt.MapFrom(wsvm => wsvm.EndDate))
                .ForMember(ws => ws.Doctor, opt => opt.Ignore()).ReverseMap();
        }
    }
}