namespace MrConstruction.Controllers {
    
    export class ContractorListController {

        public contractors;
        public selectedContractor;

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/contractor')
                .then((response) => {
                    this.contractors = response.data;
                });
        }
    }

    angular.module('MrConstruction').controller('contractorListController', ContractorListController);
}