using MrConstruction.Infrastructure;
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


    }
}