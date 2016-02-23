namespace MrConstruction.Controllers {
    export class NewProjectController {

        public project;

        static $inject = ['$http', '$location'];

        constructor(private $http, private $location) { }

        public newProject(project): void {
            this.$http.post('/api/project', project)
                .then((response) => {
                    this.$location.path('/project-list');
                });
        }

        //public ok(editProject) {
        //    this.$uibModalInstance.close(editProject);
        //}

        //public cancel() {
        //    this.$uibModalInstance.dismiss();
        //}
    }
}