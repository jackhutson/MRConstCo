namespace MrConstruction.Controllers {
    export class ProjectDetailsController {

        public project;
        public modalInstance;

        constructor(private $uibModal, private $http, private $routeParams) {
            $http.get(`/api/project/${$routeParams.id}`)
                .then((response) => {
                    this.project = response.data;
                });
        }
        public postFiles(file) {
            this.$http.postMultipart(`/api/project/${this.$routeParams.id}/upload`, { file: file })
                .then((response) => {

                });
        }

        public showModal(): void {
            this.modalInstance = this.$uibModal.open({
                templateUrl: '/Presentation/ngApp/views/newTask.html',
                controller: MrConstruction.Controllers.NewJobController,
                controllerAs: 'controller',
                resolve: {
                    projectId: () => {
                        this.$routeParams.id;
                    }
                },
                size: 'lg',
                backdrop: true,
            });
        }
    }
}