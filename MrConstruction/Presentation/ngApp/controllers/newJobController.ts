namespace MrConstruction.Controllers {

    export class NewJobController{

        public task;
        public selectedContractor;

        constructor(private $uibModalInstance, private $http: ng.IHttpService,
            private $location: ng.ILocationService, private $routeParams) {
            
        }
        
        public addTask(task): void {

        }
    }
}