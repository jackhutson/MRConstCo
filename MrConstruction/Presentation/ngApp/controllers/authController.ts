namespace MrConstruction.Controllers {

    export class AuthController {

        constructor(private $http: ng.IHttpService, private $window: ng.IWindowService, private $location: ng.ILocationService) { }

        public login(username, password): void {
            let data = `grant_type=password&username=${username}&password=${password}`;

            this.$http.post('/token', data, {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            })
                .then((response) => {
                    this.$window.localStorage.setItem('token', response.data['access_token']);
                    this.$window.localStorage.setItem('role', response.data['role']);
                    this.$location.path('/');
                })
                .catch((response) => {
                    console.log(response);
                });
        }

        public logout() {
            this.$window.localStorage.removeItem('token');
            this.$window.localStorage.removeItem('role');
        }

        get isAdmin() {
            return this.$window.localStorage.getItem('role') == 'Admin';
        }

        get isContractor() {
            return this.$window.localStorage.getItem('role') == 'Contractor';
        }

        get isLoggedIn() {
            return this.$window.localStorage.getItem('token');
        }
    }

    angular.module('MrConstruction').controller('authController', AuthController);
}