using MrConstruction.Infrastructure;
using MrConstruction.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrConstruction.Services {
    public class ContractorService {

        private ContractorRepository _contractorRepo;

        public ContractorService(ContractorRepository contractorRepo) {
            _contractorRepo = contractorRepo;
        }

        public IList<ContractorUserDTO> GetContractors() {
            var contractors = _contractorRepo.GetContractors();
            return (from c in contractors
                    select new ContractorUserDTO() {
                        Name = c.Name,
                    }).ToList();
        }
    }
}