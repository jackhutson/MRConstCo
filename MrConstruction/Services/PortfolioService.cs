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
        public void MakePortfolio(NewPortfolioBindingModel port) {
            var uploads = (from p in port.PictureIds
                           where p == _uploadRepo.FindUploadById(p).Id
                           select p).ToList();
            var portfolio = new Portfolio() {
                Uploads = (from u in uploads
                           select new Upload() {
                               Url = _uploadRepo.FindUploadById(u).Url
                           }).ToList(),
                Description = (from u in uploads
                               select _uploadRepo.FindUploadById(u).Project.Description).FirstOrDefault(),
                AfterPicture = (from u in uploads
                                where _uploadRepo.FindUploadById(u).IsAfter == true
                                select new Upload() {
                                    Url = _uploadRepo.FindUploadById(u).Url
                                }).FirstOrDefault(),
                BeforePicture = (from u in uploads
                                 where _uploadRepo.FindUploadById(u).IsBefore == true
                                 select new Upload() {
                                     Url = _uploadRepo.FindUploadById(u).Url
                                 }).FirstOrDefault()
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