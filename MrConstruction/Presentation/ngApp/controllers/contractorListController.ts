namespace MrConstruction.Controllers {
    
    export class ContractorListController {

        public contractors;

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/contractors')
                .then((response) => {
                    this.contractors = response.data;
                });
        }
    }
}