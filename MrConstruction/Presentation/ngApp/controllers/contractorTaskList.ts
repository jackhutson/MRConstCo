namespace MrConstruction.Controllers {
    export class ContractorTaskListController {

        public contractor: any;

        static $inject = ['$window', '$http', '$routeParams'];

        constructor(private $window, private $http, private $routeParams) {

            $http.get('/api/contractor/tasks')
                .then((response) => {
                    this.contractor = response.data;
                });
        }

        public markForReview(id: number): void {
            console.log(id);

            this.$http.get(`/api/task/mark/${id}`)
                .then((response) => {
                    alert('Task marked for review');
                    this.$window.location.reload();
                });
        }
    }
}