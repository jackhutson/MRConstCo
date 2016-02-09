namespace MrConstruction.Controllers {
    
    export class ContractorListController {

        public contractors;

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/contractor')
                .then((response) => {
                    this.contractors = response.data;
                });
        }
    }

    angular.module('MrConstruction').controller('contractorListController', ContractorListController);
}