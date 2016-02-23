namespace MrConstruction.Controllers {
    export class EditClientController {

        static $inject = ['$uibModalInstance', '$http', '$location', 'client'];

        constructor(private $uibModalInstance, private $http: ng.IHttpService, private $location: ng.ILocationService, client) {
            this.client = client;
        }

        public client: any;

        public ok(editProject) {
            this.$uibModalInstance.close(this.client);
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
    }
}