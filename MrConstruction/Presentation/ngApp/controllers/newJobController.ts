namespace MrConstruction.Controllers {

    export class NewJobController{

        public task;
        public selectedContractor;

        constructor(private $uibModalInstance, private $http: ng.IHttpService,
            private $location: ng.ILocationService) { }
            
        public addTask(task): void {
            this.$uibModalInstance.close(task);
        }
    }
}