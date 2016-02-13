namespace MrConstruction.Controllers {
    export class PortfolioController {
        public portfolios;
        constructor(private $http: ng.IHttpService) {
            $http.get('api/portfolio')
                .then((response) => {
                    this.portfolios = response.data;
                });
        }
    }
}