namespace MrConstruction.Controllers {

    export class EditTaskController {

        static $inject = ['$uibModalInstance', '$http', '$location', 'task'];

        public status = [
            "ToDo",
            "AwaitingEstimate",
            "InProgress",
            "PendingReview",
            "Completed"
        ];

        public task;
        public selectedContractor;

        constructor(private $uibModalInstance, private $http: ng.IHttpService,
            private $location: ng.ILocationService, task) {
            this.task = task;
        }

        public ok(edittask) {
            this.$uibModalInstance.close(edittask);
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
    }
}