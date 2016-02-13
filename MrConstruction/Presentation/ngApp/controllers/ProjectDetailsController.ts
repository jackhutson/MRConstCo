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
        //public addTask(newTask): void {
        //    this.newTask.projectId = this.$routeParams.id;
        //    this.$http.post('/api/task', newTask)
        //        .then((response) => {
        //            this.tasks.push(response.data);
        //        });
        //}

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
                            this.project.jobs.push(response);
                        });
                    //this.$http.post(`api/projectDetails/${this.$routeParams.id}/newTask`, task)
                    //    .then((response) => {
                    //        this.$location.path("#/taskDetails")
                    //        console.log("post successful");
                    //    }).catch((response) => {
                    //        console.log(`uh oh, error ${response}`);
                    //    });
                })
                .catch((dismiss) => {

                });

        }
    }
}
