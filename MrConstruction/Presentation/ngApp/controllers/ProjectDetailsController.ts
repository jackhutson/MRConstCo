namespace MrConstruction.Controllers {
    export class ProjectDetailsController {

        public project;
        public client;
        public modalInstance;

        constructor(private $uibModal, private $http, private $routeParams) {
            $http.get(`/api/project/${$routeParams.id}`)
                .then((response) => {
                    this.project = response.data;
                    
                });

            $http.get(`api/client/${$routeParams.id}`)
                .then((response) => {
                    this.client = response.data;
                });
        }

        public uploadModal(): void {
            this.modalInstance = this.$uibModal.open({
                templateUrl: '/Presentation/ngApp/views/upload.html',
                controller: MrConstruction.Controllers.UploadsController,
                controllerAs: 'controller',
                size: 'lg',
                backdrop: true,
            });

            this.modalInstance.result
                .then((upload) => {
                    this.$http.postMultipart(`/api/project/${this.$routeParams.id}/upload`, upload)
                        .then((response) => {
                        });
                })
                .catch((dismiss) => {
                });
        }

        public createPortfolio(port) {
            console.log("Create portfolio function");
            console.log(port);
            var pics = [];
            for (let p in port) {
                if (port[p]) {
                    pics.push(p);
                }
            }

            this.$http.post('/api/portfolio', { pictureIds: pics })
                .then((response) => {
                    console.log(response);
                });
        }

        public editProjectModal(): void {

            this.modalInstance = this.$uibModal.open({
                templateUrl: '/Presentation/ngApp/views/editProject.html',
                controller: MrConstruction.Controllers.EditProjectController,
                controllerAs: 'controller',
                size: 'lg',
                resolve: {
                    project: () => {
                        return this.project
                    }
                },
                backdrop: true,
            });

            this.modalInstance.result
                .then((editProject) => {
                    console.log(editProject);
                    this.$http.post(`/api/project/edit/${this.$routeParams.id}`, editProject)
                        .then((response) => {

                        })
                        .catch((response) => {
                            alert("Post failed, must have a contractor.");
                        });

                })
                .catch((dismiss) => {

                });

        }

        public editClientModal(): void {

            this.modalInstance = this.$uibModal.open({
                templateUrl: '/Presentation/ngApp/views/editClient.html',
                controller: MrConstruction.Controllers.EditClientController,
                controllerAs: 'controller',
                size: 'lg',
                resolve: {
                    client: () => {
                        return this.client
                    }
                },
                backdrop: true,
            });

            this.modalInstance.result
                .then((editClient) => {
                    console.log(editClient);
                    this.$http.post(`/api/client/${this.$routeParams.id}`, editClient)
                        .then((response) => {

                        })
                        .catch((response) => {

                        });

                })
                .catch((dismiss) => {

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

            this.modalInstance.result
                .then((newTask) => {
                    newTask.projectId = this.$routeParams.id;
                    this.$http.post('/api/task', newTask)
                        .then((response) => {

                        })
                        .catch((response) => {
                            alert("Post failed, must have a contractor.");
                        });
                    
                })
                .catch((dismiss) => {

                });

        }
    }
}
