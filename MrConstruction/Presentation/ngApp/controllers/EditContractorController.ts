namespace MrConstruction.Controllers {

    export class EditContractorController {
        public edited: any;
        
        constructor(private $uibModalInstance, private $http: ng.IHttpService, private $location: ng.ILocationService, edited) {
            this.edited = edited;
        }

        public ok(edit) {
            this.$uibModalInstance.close(this.edited);
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
        
    }
}