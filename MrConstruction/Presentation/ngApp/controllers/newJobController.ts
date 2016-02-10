namespace MrConstruction.Controllers {

    export class NewJobController{

        public task;
        public selectedContractor;

        constructor(private $uibModalInstance, private $http: ng.IHttpService, private $location: ng.ILocationService, private projectId: number){ }
        
        public addTask(task): void {
            this.$http.post(`api/projectDetails/${this.projectId}/newTask`, task)
                .then((response) => {
                    this.$location.path("#/taskDetails")
                    console.log("post successful");
                }).catch((response) => {
                    console.log(`uh oh, error ${response}`);
                });
        }
    }
}