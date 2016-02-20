namespace MrConstruction.Controllers {
    export class ContractorTaskListController {

        public contractor: any;

        constructor(private $http, private $routeParams) {

            $http.get('/api/contractor/tasks')
                .then((response) => {
                    this.contractor = response.data;
                });
        }
    }
}