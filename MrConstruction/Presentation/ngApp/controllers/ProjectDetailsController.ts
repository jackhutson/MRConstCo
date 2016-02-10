namespace MrConstruction.Controllers {
    export class ProjectDetailsController {
        public project;
        constructor(private $http, private $routeParams) {
            $http.get(`/api/project/${$routeParams.id}`)
                .then((response) => {
                    this.project = response.data;
                });
        }
        public postFiles(file) {
            this.$http.postMultipart(`/api/project/${this.$routeParams.id}/upload`, { file: file })
                .then((response) => {

                });
        }
    }
}