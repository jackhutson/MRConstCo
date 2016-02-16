namespace MrConstruction.Controllers {

    export class ContractorListController {

        public contractors;
        public selectedContractor;
        public modalInstance;

        constructor(private $http: ng.IHttpService, private $uibModal, private $routeParams) {
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
        public showEditModal(id): void {

            var edited;

            this.$http.get(`/api/contractor/${id}`)
                .then((response) => {
                    edited = response.data;

                    this.modalInstance = this.$uibModal.open({
                        templateUrl: '/Presentation/ngApp/views/editContractor.html',
                        controller: MrConstruction.Controllers.EditContractorController,
                        controllerAs: 'controller',
                        size: 'lg',
                        resolve: {
                            edited: () => {
                                return edited
                            }
                        },
                        backdrop: true,
                    });

                    this.modalInstance.result
                        .then((reason) => {
                            console.log("reason");
                        })
                        .catch((dismiss) => {
                            console.log("reason");
                        });
                });
        }
        
    }
    angular.module('MrConstruction').controller('contractorListController', ContractorListController);
}

    

   
