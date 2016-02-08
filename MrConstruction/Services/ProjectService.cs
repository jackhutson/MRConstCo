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
                            Title = p.Title,
                            Description = p.Description,
                            Budget = p.Budget,
                            ClientName = p.Client.Name,
                            State = p.State,
                            EstStart = p.EstStart,
                            EstCompleted = p.EstCompleted,
                            JobList = (from j in p.JobList
                                       select new JobListDTO() {
                                           Name = j.Name,
                                           State = j.State,
                                           Deadline = j.Deadline,
                                           Estimate = j.Estimate
                                       }).ToList(),
                        }).ToList();
            return list;
        }
    }
}