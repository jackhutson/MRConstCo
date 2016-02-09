namespace MrConstruction.Controllers {
    export class ProjectDetailsController {
        public project;
        constructor(private $http: ng.IHttpService, private $routeParams) {
            $http.get(`/api/projectDetails/${$routeParams.id}`)
                .then((response) => {
                    this.project = response.data;
                });
        }
    }
}