namespace MrConstruction.Controllers {

    export class NewContractorController {

        constructor(private $uibModalInstance, private $http: ng.IHttpService, private $window: ng.IWindowService, private $location: ng.ILocationService) { }

        public register(user): void {

            this.$http.post('/api/account/register', user)
                .then((response) => {
                    console.log('Registered a new user!');
                })
                .catch((response) => {
                    console.log(response);
                });
            this.$uibModalInstance.close();
        }

        public cancel() {
            this.$uibModalInstance.dismiss();
        }
    }
}