namespace MrConstruction.Controllers {
    export class NewProjectController {

        public project;

        constructor(private $uibModalInstance, private $http: ng.IHttpService, private $location: ng.ILocationService) { }

        public ok(newProject) {
            this.$uibModalInstance.close(newProject);
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
    }
}