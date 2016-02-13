namespace MrConstruction.Controllers {
    export class ProjectDetailsController {

        public project;
        public modalInstance;

        constructor(private $uibModal, private $http, private $routeParams) {
            $http.get(`/api/project/${$routeParams.id}`)
                .then((response) => {
                    this.project = response.data;
                    //this.project.contractors.shift(null);
                });
        }

        //public postFiles(file) {
        //    this.$http.postMultipart(`/api/project/${this.$routeParams.id}/upload`, { file: file })
        //        .then((response) => {
        //        });
        //}

        //Upload Modal
        public uploadModal(): void {
            this.modalInstance = this.$uibModal.open({
                templateUrl: '/Presentation/ngApp/views/upload.html',
                controller: MrConstruction.Controllers.UploadsController,
                controllerAs: 'controller',
                size: 'lg',
                backdrop: true,
            });

            this.modalInstance.result
                .then((file) => {
                    this.$http.postMultipart(`/api/project/${this.$routeParams.id}/upload`, { file: file })
                        .then((response) => {
                        });
                })
                .catch((dismiss) => {
                });
        }

        public createPortfolio(port) {
            var pics = [];
            for (var p in port) {
                if (port[p]) {
                    pics.push(p);
                }
            }
            this.$http.post('/api/portfolio', pics)
                .then((response) => {
                    console.log(response);
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
