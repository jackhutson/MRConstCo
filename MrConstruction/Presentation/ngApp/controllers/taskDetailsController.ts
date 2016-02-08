namespace MrConstruction.Controllers {

    export class TaskDetailsController {


        public tasks;

        constructor(private $http: ng.IHttpService) {

            $http.get('/api/jobs')
                .then((response) => {
                    this.tasks = response.data;
                });
        }
    }
} 