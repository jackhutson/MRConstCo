namespace MrConstruction.Controllers {

    export class TaskDetailsController {


        public tasks;

        constructor(private $http: ng.IHttpService, private $routeParams) {
            $http.get(`/api/jobs/${$routeParams.id}`)
                .then((response) => {
                    this.tasks = response.data;
                });
        }
    }
} 