using MrConstruction.Domain;
using MrConstruction.Infrastructure;
using MrConstruction.Presentation.Models;
using MrConstruction.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services {
    public class PortfolioService {
        public PortfolioRepository _portfolioRepo;
        public UploadRepository _uploadRepo;
        public ProjectRepository _projectRepo;
        public PortfolioService(PortfolioRepository portfolioRepo, UploadRepository uploadRepo, ProjectRepository _projectRepo) {
            _portfolioRepo = portfolioRepo;
            _uploadRepo = uploadRepo;
        }
        public void MakePortfolio(int projectId, NewPortfolioBindingModel port) {

            var uploads = (from p in _uploadRepo.FindUploadsByProjectId(projectId)
                           where port.PictureIds.Contains(p.Id)
                           select p).ToList();
            var project = _projectRepo.Get(projectId).FirstOrDefault();

            var portfolio = new Portfolio() {
                Uploads = uploads,
                Description = project.Description,
                AfterPicture = (from p in uploads
                                where p.Id == port.AfterId
                                select p).FirstOrDefault(),
                BeforePicture = (from p in uploads
                                 where p.Id == port.BeforeId
                                 select p).FirstOrDefault(),
                Name = project.Title
            };
            _portfolioRepo.Add(portfolio);
            _portfolioRepo.SaveChanges();

        }
        public IList<PortfolioDTO> DisplayPortfolio() {
            return (from p in _portfolioRepo.FindPortfolios()
                    select new PortfolioDTO() {
                        Uploads = (from u in p.Uploads
                                   select new UploadDTO() {
                                       Url = u.Url
                                   }).ToList(),
                    }).ToList();
        }
    }
}