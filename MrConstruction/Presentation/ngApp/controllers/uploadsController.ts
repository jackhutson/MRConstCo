namespace MrConstruction.Controllers {

    export class UploadsController {

        constructor(private $uibModalInstance, private $http: ng.IHttpService) { }

        public postFiles(file, type) {
        
            this.$uibModalInstance.close({ file: file, type: type });
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
    }
}
