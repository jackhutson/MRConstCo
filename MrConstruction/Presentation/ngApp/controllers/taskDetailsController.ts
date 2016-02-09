namespace MrConstruction.Controllers {

    export class TaskDetailsController {


        public task;

        constructor(private $http: ng.IHttpService, private $routeParams) {
            $http.get(`/api/jobs/${$routeParams.id}`)
                .then((response) => {
                    this.task = response.data;
                });
        }
    }
} 