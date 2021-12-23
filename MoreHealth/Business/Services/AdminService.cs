using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoreHealth.Business.Interfaces;
using MoreHealth.Constants.UserMessagesConstants;
using MoreHealth.Models;
using MoreHealth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreHealth.Business.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationContext db;
        private readonly IMapper mapper;
        public AdminService(
            ApplicationContext context,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.db = context;
        }

        public IEnumerable<Cabinet> GetAllCabinets()
        {
            var cabinets = db.Cabinet;

            return cabinets;
        }

        public IEnumerable<AppointmentHome> GetAllAppointmentHome()
        {
            var appointmentHome = db.AppointmentHomes.Include(ah => ah.Patient);

            return appointmentHome;
        }

        public Cabinet UpdateCabinet(Cabinet model)
        {
            var cabinet = db.Cabinet.FirstOrDefault(c => c.Id == model.Id);

            if (cabinet != null)
            {
                cabinet.CabinetNumber = model.CabinetNumber;

                db.SaveChanges();
            }

            var updatedCabinet = db.Cabinet.FirstOrDefault(c => c.Id == cabinet.Id);

            return updatedCabinet;
        }

        public Cabinet CreateCabinet(Cabinet model)
        {
            if (model != null)
            {
                db.Cabinet.Add(model);
                db.SaveChanges();
            }

            var addedCabinet = db.Cabinet.FirstOrDefault(c => c.Id == model.Id);

            return addedCabinet;
        }

        public void RemoveCabinet(Cabinet model)
        {
            var removeCabinet = db.Cabinet.FirstOrDefault(c => c.Id == model.Id);

            if (removeCabinet != null)
            {
                db.Cabinet.Remove(removeCabinet);
                db.SaveChanges();
            }
        }

        public void RemoveAppointmentHome(AppointmentHome model)
        {
            var appointmentHome = db.AppointmentHomes.FirstOrDefault(ah => ah.Id == model.Id);

            if (appointmentHome != null)
            {
                db.AppointmentHomes.Remove(appointmentHome);
                db.SaveChanges();
            }
        }
    }
}
