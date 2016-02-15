namespace MrConstruction.Controllers {
    export class EditProjectController {

        constructor(private $uibModalInstance, private $http: ng.IHttpService, private $location: ng.ILocationService, project) {
            this.project = project;
        }

        public project: any;

        public ok(editProject) {
            this.$uibModalInstance.close(editProject);
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
    }
}