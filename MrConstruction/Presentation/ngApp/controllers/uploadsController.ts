namespace MrConstruction.Controllers {

    export class UploadsController {

        constructor(private $uibModalInstance, private $http: ng.IHttpService) { }

        public ok() {
            this.$uibModalInstance.close();
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
    }
}