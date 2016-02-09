namespace MrConstruction.Controllers {
    export class ProjectDetailsController {
        public projects;
        constructor(private $http: ng.IHttpService, private $routeParams) {
            $http.get(`/api/projectDetails/${$routeParams.id}`)
                .then((response) => {
                    this.projects = response.data;
                });
        }
    }
}