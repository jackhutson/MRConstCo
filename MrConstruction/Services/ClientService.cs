using MrConstruction.Infrastructure;
using MrConstruction.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services {
    public class ClientService {

        private ClientRepository _clientRepo;

        private ProjectRepository _projectRepo;

        public ClientService(ProjectRepository projectRepo, ClientRepository clientRepo) {
            _clientRepo = clientRepo;
            _projectRepo = projectRepo;
        }

        public ClientDTO GetClient(int id) {

            var project = _projectRepo.Get(id);

            var client = (from p in project
                          select p.Client).FirstOrDefault();

            var dto = new ClientDTO() {
                Id = client.Id,
                Name = client.Name,
                PhoneNumber = client.PhoneNumber,
                PhoneNumber2 = client.PhoneNumber2,
                Email = client.Email,
                Description = client.Description
            };

            return dto;
        }

        public void EditClient(ClientDTO edited) {

            var client = _clientRepo.Get(edited.Id).FirstOrDefault();

            client.Name = edited.Name;
            client.PhoneNumber = edited.PhoneNumber;
            client.PhoneNumber2 = edited.PhoneNumber2;
            client.Email = edited.Email;
            client.Description = edited.Description;

            _clientRepo.SaveChanges();
        }
    }
}