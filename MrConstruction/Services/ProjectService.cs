using MrConstruction.Domain;
using MrConstruction.Infrastructure;
using MrConstruction.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services {
    public class ProjectService {
        public ProjectRepository _projectRepo;
        public ProjectService(ProjectRepository projectRepo) {
            _projectRepo = projectRepo;
        }
        public IList<ProjectDTO> ListProjects() {
            var list = (from p in _projectRepo.GetProjects()
                        select new ProjectDTO() {
                            Id = p.Id,
                            Title = p.Title,
                            Description = p.Description,
                            Budget = p.Budget,
                            ClientName = p.Client.Name,
                            State = p.State,
                            EstStart = p.EstStart,
                            EstCompleted = p.EstCompleted,
                            JobList = (from j in p.JobList
                                       select new JobListDTO() {
                                           Id = j.Id,
                                           Name = j.Name,
                                           State = j.State,
                                           Deadline = j.Deadline,
                                           Estimate = j.Estimate
                                       }).ToList(),
                        }).ToList();
            return list;
        }
        public ProjectDTO GetOneProject(int id) {
            var dto = (from p in _projectRepo.Get(id)
                        select new ProjectDTO() {
                            Id = p.Id,
                            Title = p.Title,
                            Description = p.Description,
                            Budget = p.Budget,
                            ClientName = p.Client.Name,
                            State = p.State,
                            EstStart = p.EstStart,
                            EstCompleted = p.EstCompleted,
                            JobList = (from j in p.JobList
                                       select new JobListDTO() {
                                           Id = j.Id,
                                           Name = j.Name,
                                           State = j.State,
                                           Deadline = j.Deadline,
                                           Estimate = j.Estimate
                                       }).ToList(),
                        }).FirstOrDefault();
            return dto;
        }

        //To check if the project exists
        public bool CheckExists(int id) {
            return _projectRepo.CheckExists(id);
        }

        public void AddNewProject(NewProjectDTO newProject) {

            var project = new Project() {
                Title = newProject.Title,
                Description = newProject.Description,
                Budget = newProject.Budget,
                EstStart = newProject.EstStart,
                EstCompleted = newProject.EstCompleted,
                Client = new Client() {
                    Name = newProject.Client.Name,
                    PhoneNumber = newProject.Client.PhoneNumber,
                    PhoneNumber2 = newProject.Client.PhoneNumber2,
                    Email = newProject.Client.Email,
                    Description = newProject.Client.Description,
                    Location = new Location() {
                        Street1 = newProject.Client.Location.Street1,
                        Street2 = newProject.Client.Location.Street2,
                        City = newProject.Client.Location.City,
                        State = newProject.Client.Location.State,
                        Country = newProject.Client.Location.Country
                    }
                },

            };

            _projectRepo.Add(project);
            _projectRepo.SaveChanges();
        }
    }
}