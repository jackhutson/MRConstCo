namespace MrConstruction.Controllers {
    export class NewProjectController {

        public project;

        constructor(private $http: ng.IHttpService) { }

        public newProject() {
            this.$http.post('/api/project', {

            }).then((response) => {

            }).catch((response) => {

            });
        }
    }
}