namespace MrConstruction {
    
    angular.module('MrConstruction', ['ngRoute', 'ui.bootstrap']);

    angular.module('MrConstruction').factory('authInterceptor',
        ($q: ng.IQService, $window: ng.IWindowService, $location: ng.ILocationService) => {
            return {
                request: (config) => {
                    config.headers = config.headers || {};
                    let token = $window.localStorage.getItem('token');
                    if (token) {
                        config.headers.Authorization = `Bearer ${token}`;
                    }
                    return config;
                },
                responseError: (response) => {
                    if (response.status === 401) {
                        $location.path('/login');
                    }
                    return $q.reject(response);
                }
            };
        });

    angular.module('MrConstruction')
        .config(function ($routeProvider: ng.route.IRouteProvider, $httpProvider: ng.IHttpProvider) {

            $httpProvider.interceptors.push('authInterceptor');

            $routeProvider
                .when('/newproject', {
                    templateUrl: '/Presentation/ngApp/views/newProject.html',
                    controller: MrConstruction.Controllers.NewProjectController,
                    controllerAs: 'controller'
            });
        });
}