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
        public PortfolioService(PortfolioRepository portfolioRepo) {
            _portfolioRepo = portfolioRepo;
        }
        public void MakePortfolio(NewPortfolioBindingModel port) {
            var uploads = (from p in port.PictureIds
                          where p == _uploadRepo.FindUploadById(p).Id
                          select p).ToList();
            var portfolio = new Portfolio() {
                Uploads = (from u in uploads
                           select new Upload() {
                               Url = _uploadRepo.FindUploadById(u).Url,

                           }).ToList()
            };
            _portfolioRepo.Add(portfolio);
            _portfolioRepo.SaveChanges();
            
        }
    }
}