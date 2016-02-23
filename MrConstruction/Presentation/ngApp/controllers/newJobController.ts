﻿namespace MrConstruction.Controllers {

    export class NewJobController{

        public task;
        public newTask;
        public selectedContractor;

        static $inject = ['$uibModalInstance', '$http', '$location'];

        constructor(private $uibModalInstance, private $http: ng.IHttpService,
            private $location: ng.ILocationService) { }
            
        public ok(newTask){
            this.$uibModalInstance.close(newTask);
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
    }
}