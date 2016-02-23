﻿namespace MrConstruction.Controllers {
    export class EditProjectController {

        static $inject = ['$uibModalInstance', '$http', '$location', 'project'];

        public status = [
            "ToDo",
            "AwaitingEstimate",
            "InProgress",
            "PendingReview",
            "Completed"
        ];

        constructor(private $uibModalInstance, private $http: ng.IHttpService, private $location: ng.ILocationService, project) {
            this.project = project;
        }

        public project: any;

        public ok(editProject) {
            this.$uibModalInstance.close(this.project);
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
    }
}