namespace MrConstruction.Controllers {
    export class NewProjectController {

        public project;

        constructor(private $http: ng.IHttpService, private $location: ng.ILocationService) { }

        public newProject(project) {
            console.log(project);
            this.$http.post('/api/project', project
            ).then((response) => {
                this.$location.path("#/projectDetails")
                console.log("post successful");
            }).catch((response) => {
                console.log(`uh oh, error ${response}`);
            });
        }
    }
}