namespace MrConstruction.Controllers {

    export class TaskDetailsController {


        public task;

        constructor(private $http: ng.IHttpService) {

            $http.get('/api/jobs')
                .then((response) => {
                    this.task = response.data;
                });
        }
    }
} 