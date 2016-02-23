namespace MrConstruction.Controllers {

    export class TaskDetailsController {

        public task;
        public modalinstance;
        static $inject = ['$http', '$routeParams', '$uibModal'];

        constructor(private $http: ng.IHttpService, private $routeParams, private $uibModal) {
            $http.get(`/api/jobs/${$routeParams.id}`)
                .then((response) => {
                    this.task = response.data;
                });
        }

        public editTaskModal(): void {
            this.modalinstance = this.$uibModal.open({
                templateUrl: '/Presentation/ngApp/views/editTask.html',
                controller: MrConstruction.Controllers.EditTaskController,
                controllerAs: 'controller',
                //size: 'lg',
                resolve: {
                    task: () => {
                        return this.task;
                    }
                },
            });

            this.modalinstance.result
                .then((editedtask) => {
                    console.log(editedtask)
                    this.$http.post(`/api/jobs/${this.task.$routeParams}`, editedtask)
                        .then((response) => {

                        })
                        .catch((response) => {

                        });
                })
        }
    }
} 