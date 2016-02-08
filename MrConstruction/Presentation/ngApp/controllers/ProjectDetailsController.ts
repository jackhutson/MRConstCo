namespace MrConstruction.Controllers {
    export class ProjectDetailsController {
        public projects;
        constructor(private $http: ng.IHttpService) {
            $http.get('/api/project')
                .then((response) => {
                    this.projects = response.data;
                });
        }
    }
}
