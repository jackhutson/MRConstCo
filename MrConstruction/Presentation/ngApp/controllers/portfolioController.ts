namespace MrConstruction.Controllers {
    export class PortfolioController {

        public portfolios;

        constructor(private $window, private $http: ng.IHttpService) {
            $http.get('/api/portfolio')
                .then((response) => {
                    this.portfolios = response.data;
                });
        }

        public deletePortfolio(id: number) {
            this.$http.get(`/api/portfolio/delete/${id}`)
                .then((response) => {
                    this.$window.location.reload();
                });
        }

        get isAdmin() {
            return this.$window.localStorage.getItem('role') == 'Admin';
        }
    }
}