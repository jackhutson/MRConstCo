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
                            Budget = p.Budget,
                            Description = p.Description,
                        }).ToList();
        }
    }
}