namespace MrConstruction.Controllers {

    export class EditLocationController {
        constructor(private $uibModalInstance, private $http: ng.IHttpService, private $location: ng.ILocationService, location) {
            this.location = location;
        }

        public location: any;

        public ok(editLocation) {
            this.$uibModalInstance.close(this.location);
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
    }

}
