namespace MrConstruction.Controllers {
    export class NewProjectController {

        public project;

        constructor(private $uibModalInstance, private $http: ng.IHttpService, private $location: ng.ILocationService) { }

        public ok(editProject) {
            this.$uibModalInstance.close(editProject);
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
    }
}