using MrConstruction.Domain;
using MrConstruction.Infrastructure;
using MrConstruction.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services {
    public class UploadService {
        public UploadRepository _uploadRepo;

        public ProjectRepository _projectRepo;

        public UploadService(UploadRepository uploadRepo, ProjectRepository projectRepo) {
            _uploadRepo = uploadRepo;
            _projectRepo = projectRepo;
        }

        public void SaveUpload(int id, UploadDTO file) {
            var currentProject = _projectRepo.Get(id).FirstOrDefault();

            // check if current project is null first
            if (currentProject != null) {
                var newUpload = new Upload() {
                    Name = file.Name,
                    Url = file.Url,
                    Project = currentProject,
                    Type = file.Type
                };

                _uploadRepo.Add(newUpload);
                _uploadRepo.SaveChanges();
            }
        }
    }
}