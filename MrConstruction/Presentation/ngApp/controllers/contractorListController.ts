namespace MrConstruction.Controllers {
    
    export class ContractorListController {

        public contractors;
        public selectedContractor;
        public modalInstance;

        constructor(private $http: ng.IHttpService, private $uibModal) {
            $http.get('/api/contractor')
                .then((response) => {
                    this.contractors = response.data;
                });
        }

        public showModal(): void {

            this.modalInstance = this.$uibModal.open({
                templateUrl: '/Presentation/ngApp/views/newContractor.html',
                controller: MrConstruction.Controllers.NewContractorController,
                controllerAs: 'controller',
                size: 'lg',
                backdrop: true,
            });

            this.modalInstance.result
                .then((reason) => {
                    console.log("reason");
                })
                .catch((dismiss) => {
                    console.log("reason");
                });
        }
    }

    angular.module('MrConstruction').controller('contractorListController', ContractorListController);
}