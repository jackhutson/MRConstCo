namespace MrConstruction.Controllers {
    export class ProjectDetailsController {

        public project;
        public modalInstance;

        constructor(private $uibModal, private $http: ng.IHttpService, private $routeParams) {
                .then((response) => {
                    this.project = response.data;
                });
        }

        public showModal(): void {
            this.modalInstance = this.$uibModal.open({
                templateUrl: '/Presentation/ngApp/views/newTask.html',
                controller: MrConstruction.Controllers.NewJobController,
                controllerAs: 'controller',
                size: 'lg',
                backdrop: true,
            });
        }
    }
}