namespace MrConstruction.Controllers {

    export class ProjectDetailsController {

        public project;
        public client;
        public modalInstance;
        public location;
        public netEstCost: number;
        private beforeId;
        private afterId;

        constructor(private $route, private $uibModal, private $http, private $routeParams, private $location) {


            $http.get(`/api/project/${$routeParams.id}`)
                .then((response) => {
                    this.project = response.data;
                    this.netEstCost = this.getNetBalance();
                });

            $http.get(`/api/location/${$routeParams.id}`)
                .then((response) => {
                    this.location = response.data;
                });

            $http.get(`api/client/${$routeParams.id}`)
                .then((response) => {
                    this.client = response.data;
                });
        }

        public getNetBalance(): number {
            var budget: number = this.project.budget;
            var tasksTotal: number = 0;

            this.project.jobList.forEach(function (s) {
                tasksTotal = tasksTotal + s.estimate;
            });

            return budget - tasksTotal;
        }

        public uploadModal(): void {
            this.modalInstance = this.$uibModal.open({
                templateUrl: '/Presentation/ngApp/views/upload.html',
                controller: MrConstruction.Controllers.UploadsController,
                controllerAs: 'controller',
                //size: 'lg',
                backdrop: true,
            });

            this.modalInstance.result
                .then((upload) => {

                    console.log(upload);

                    this.$http.postMultipart(`/api/project/${this.$routeParams.id}/upload`, upload)
                        .then((response) => {
                            this.$route.reload();
                        });
                })
                .catch((dismiss) => {
                });
        }

        public createPortfolio(port) {
            var pics = [];
            for (let p in port) {
                if (port[p]) {
                    pics.push(p);
                }
            }
            this.$http.post(`/api/portfolio/${this.$routeParams.id}`, {
                pictureIds: pics,
                beforeId: this.beforeId,
                afterId: this.afterId
            })
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
                            this.$route.reload();
                        })
                        .catch((response) => {
                            alert("Post failed, must have a contractor.");
                        });

                })
                .catch((dismiss) => {

                });

        }

        public editLocationModal(): void {

            this.modalInstance = this.$uibModal.open({
                templateUrl: '/Presentation/ngApp/views/editLocation.html',
                controller: MrConstruction.Controllers.EditLocationController,
                controllerAs: 'controller',
                size: 'lg',
                resolve: {
                    location: () => {
                        return this.location
                    }
                },
                backdrop: true,
            });

            this.modalInstance.result
                .then((location) => {
                    this.$http.post(`/api/location/${this.$routeParams.id}`, location)
                        .then((response) => {
                            this.$route.reload();
                        })
                        .catch((response) => {
                            alert('failed');

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
                            this.$route.reload();
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
                            this.$route.reload();
                        })
                        .catch((response) => {
                            alert("Post failed, must have a contractor.");
                        });

                })
                .catch((dismiss) => {

                });

        }

        public deleteProject(): void {

            var userConfirm = confirm("Are you sure you want to delete this project?");

            if (userConfirm) {
                this.$http.get(`/api/project/delete/${this.$routeParams.id}`)
                    .then((response) => {
                        this.$route.reload();
                    });
            } else {
                alert("Delete canceled.");
            }
        }

        public deleteTask(Id: any): void {

            var userConfirm = confirm("Are you sure you want to delete this task?");

            if (userConfirm) {
                this.$http.get(`/api/task/delete/${Id}`)
                    .then((response) => {
                        this.$route.reload();
                });
            } else {
                alert("Task delete canceled.");
            }
        }
    }
}
