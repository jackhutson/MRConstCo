using MrConstruction.Infrastructure;
using MrConstruction.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services
{
    public class LocationService
    {
        public LocationRepository _locationRepo;

        public ProjectRepository _projectRepo;

        public LocationService(LocationRepository locationRepo, ProjectRepository projectRepo) {
            _locationRepo = locationRepo;
            _projectRepo = projectRepo;

        }

        public LocationDTO GetLocation(int id) {
            var project = _projectRepo.Get(id);

            var location = (from p in project
                            select p.Client.Location).FirstOrDefault();

            var dto = new LocationDTO()
            {
                Id = location.Id,
                Street1 = location.Street1,
                Street2 = location.Street2,
                City = location.City,
                State = location.State,
                Country = location.Country
            };

            return dto;

        }


        public void EditLocation(LocationDTO edited) {

            var location = _locationRepo.Get(edited.Id).FirstOrDefault();

            location.Street1 = edited.Street1;
            location.Street2 = edited.Street2;
            location.City = edited.City;
            location.State = edited.State;
            location.Country = edited.Country;

            _locationRepo.SaveChanges();
        }

    }
}