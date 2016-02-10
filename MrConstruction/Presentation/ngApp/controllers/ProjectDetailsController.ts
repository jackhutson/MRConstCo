namespace MrConstruction.Controllers {
    export class ProjectDetailsController {

        public project;
        public modalInstance;
        public newTask;
        public tasks;

        constructor(private $uibModal, private $http, private $routeParams) {
            $http.get(`/api/project/${$routeParams.id}`)
                .then((response) => {
                    this.project = response.data;
                });
            $http.get('')
                .then((response) => {
                    this.tasks = response.data;
                });
        }

        public postFiles(file) {
            this.$http.postMultipart(`/api/project/${this.$routeParams.id}/upload`, { file: file })
                .then((response) => {

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

            this.modalInstance
                .then((newTask) => {
                    this.newTask.projectId = this.$routeParams.id;
                    this.$http.post('/api/task', newTask)
                        .then((response) => {
                            this.tasks.push(response.data);
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