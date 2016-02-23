namespace MrConstruction.Controllers {

    export class ContractorListController {

        public contractors;
        public selectedContractor;
        public modalInstance;
        public edited;

        static $inject = ['$route', '$http', '$uibModal', '$routeParams', '$location'];

        constructor(private $route, private $http: ng.IHttpService, private $uibModal, private $routeParams, private $location) {
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
                //size: 'lg',
                backdrop: true,
            });

            this.modalInstance.result
                .then((reason) => {
                    this.$route.reload();
                    console.log("reason");
                })
                .catch((dismiss) => {
                    console.log("reason");
                });
        }


        public showEditModal(id): void {

            this.$http.get(`/api/contractor/${id}`)
                .then((response) => {
                    this.edited = response.data;

                    this.modalInstance = this.$uibModal.open({
                        templateUrl: '/Presentation/ngApp/views/editContractor.html',
                        controller: MrConstruction.Controllers.EditContractorController,
                        controllerAs: 'controller',
                        size: 'lg',
                        resolve: {
                            edited: () => {
                                return this.edited
                            }
                        },
                        backdrop: true,
                    });

                    this.modalInstance.result
                        .then((editContractor) => {
                            console.log(editContractor);
                            this.$http.post(`/api/contractor/edit/${this.$routeParams.id}`, editContractor)
                                .then((response) => {
                                    this.$route.reload();
                                    console.log("You successfully posted!")
                                })
                                .catch((response) => {
                                    alert(`You have encountered an error! response: ${response}`);
                                });

                        })
                        .catch((dismiss) => {

                        });
                });
        }

        public deleteContractor(Id: any): void {

            var userConfirm = confirm("Are you sure you want to delete this contractor?");

            if (userConfirm) {
                this.$http.get(`/api/contractor/delete/${Id}`)
                    .then((response) => {
                        console.log("Successfully deleted contractor!");
                        this.$route.reload();
                    })
                    .catch(() => {
                        alert("You need to assign a different contractor to the tasks this contractor is assigned to or delete said tasks before deleting this contractor!")
                    });

            }
            else {
                alert("Contractor delete canceled.");
            }
        }

    }
    angular.module('MrConstruction').controller('contractorListController', ContractorListController);
}

    

   
