namespace MrConstruction.Controllers {

    export class EditContractorController {

        public edited: any;

        static $inject = ['$uibModalInstance', '$http', '$location', 'edited'];
        
        constructor(private $uibModalInstance, private $http: ng.IHttpService, private $location: ng.ILocationService, edited) {
            this.edited = edited;
        }

        public ok(edited) {
            this.$uibModalInstance.close(edited);
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
        
    }
}