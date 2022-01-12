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
            CreateMap<PatientViewModel, Models.Patient>()
                .ForMember(p => p.Id, opt => opt.MapFrom(pvm => pvm.Id))
                .ForMember(p => p.Address, opt => opt.MapFrom(pvm => pvm.Address))
                .ForMember(p => p.IsPatient, opt => opt.MapFrom(pvm => pvm.IsPatient))
                .ForMember(p => p.Name, opt => opt.MapFrom(pvm => pvm.Name))
                .ForMember(p => p.LastName, opt => opt.MapFrom(pvm => pvm.LastName))
                .ForMember(p => p.Surname, opt => opt.MapFrom(pvm => pvm.Surname))
                .ForMember(p => p.DateBirth, opt => opt.MapFrom(pvm => pvm.DateBirth)).ReverseMap();
            CreateMap<CabinetViewModel, Models.Cabinet>()
                .ForMember(d => d.Id, opt => opt.MapFrom(dvm => dvm.Id))
                .ForMember(d => d.CabinetNumber, opt => opt.MapFrom(dvm => dvm.CabinetNumber))
                .ForMember(d => d.Doctors, opt => opt.Ignore()).ReverseMap();
            CreateMap<SpecializationViewModel, Models.Specialization>()
                .ForMember(s => s.Id, opt => opt.MapFrom(svm => svm.Id))
                .ForMember(s => s.SpecializationName, opt => opt.MapFrom(svm => svm.SpecializationName))
                .ForMember(s => s.Doctors, opt => opt.Ignore())
                .ForMember(s => s.Department, opt => opt.MapFrom(svm => svm.Department))
                .ForMember(s => s.DepartmentId, opt => opt.MapFrom(svm => svm.DepartmentId)).ReverseMap();

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
                .ForMember(a => a.DoctorId, opt => opt.MapFrom(avm => avm.DoctorId))
                .ForMember(a => a.Patient, opt => opt.Ignore()).ReverseMap();
            CreateMap<DoctorViewModel, Models.Doctor>()
                .ForMember(d => d.Id, opt => opt.MapFrom(dvm => dvm.Id))
                .ForMember(d => d.User, opt => opt.MapFrom(dvm => dvm.User))
                .ForMember(d => d.Specialization, opt => opt.MapFrom(dvm => dvm.Specialization))
                .ForMember(d => d.SpecializationId, opt => opt.MapFrom(dvm => dvm.SpecializationId))
                .ForMember(d => d.Name, opt => opt.MapFrom(dvm => dvm.Name))
                .ForMember(d => d.Surname, opt => opt.MapFrom(dvm => dvm.Surname))
                .ForMember(d => d.LastName, opt => opt.MapFrom(dvm => dvm.LastName))
                .ForMember(d => d.Feedbacks, opt => opt.Ignore())
                .ForMember(d => d.Cabinet, opt => opt.MapFrom(dvm => dvm.Cabinet))
                .ForMember(d => d.CabinetId, opt => opt.MapFrom(dvm => dvm.CabinetId))
                .ForMember(d => d.StartWorkTimeEvenDay, opt => opt.MapFrom(dvm => dvm.StartWorkTimeEvenDay))
                .ForMember(d => d.EndWorkTimeEvenDay, opt => opt.MapFrom(dvm => dvm.EndWorkTimeEvenDay))
                .ForMember(d => d.StartWorkTimeOddDay, opt => opt.MapFrom(dvm => dvm.StartWorkTimeOddDay))
                .ForMember(d => d.EndWorkTimeOddDay, opt => opt.MapFrom(dvm => dvm.EndWorkTimeOddDay))
                .ForMember(d => d.Weekend, opt => opt.MapFrom(dvm => dvm.Weekend)).ReverseMap();
            CreateMap<PaidServiceViewModel, Models.PaidServices>()
                .ForMember(ws => ws.Description, opt => opt.MapFrom(wsvm => wsvm.Description))
                .ForMember(ws => ws.Price, opt => opt.MapFrom(wsvm => wsvm.Price))
                .ForMember(ws => ws.ForeignPrice, opt => opt.MapFrom(wsvm => wsvm.ForeignPrice))
                .ForMember(ws => ws.ServiceName, opt => opt.MapFrom(wsvm => wsvm.ServiceName)).ReverseMap();
        }
    }
}