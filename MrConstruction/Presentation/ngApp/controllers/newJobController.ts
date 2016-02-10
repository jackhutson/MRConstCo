namespace MrConstruction.Controllers {

    export class NewJobController{

        public task;
        public selectedContractor;

        constructor(private $uibModalInstance, private $http: ng.IHttpService, private $location: ng.ILocationService, private $routeParams) { }
        
        public addTask(task): void {
            this.$http.post(`/api/project/${task.project.id}/newTask`, task)
                .then((response) => {
                    this.$location.path('/projectDetails');
                })
                .catch((response) => {
                    console.log(response);
                });
        }
    }
}