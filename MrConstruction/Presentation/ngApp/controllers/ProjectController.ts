namespace MrConstruction.Controllers {
    export class ProjectController {

        public projects;
        static $inject = ['$http'];

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/project')
                .then((response) => {
                    this.projects = response.data;
                });
        }
    }
}
