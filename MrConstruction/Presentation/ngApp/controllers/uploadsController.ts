namespace MrConstruction.Controllers {

    export class UploadsController {

        constructor(private $uibModalInstance, private $http: ng.IHttpService) { }

        public postFiles(file, type) {

            if (type == 0) {
                file.type = 0;
            }
            else {
                file.type = 1;
            }
            this.$uibModalInstance.close(file);
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
    }
}