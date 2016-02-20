namespace MrConstruction {

    angular.module('MrConstruction', ['ngRoute', 'ui.bootstrap', 'ngAnimate']);

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
                .when('/contractors', {
                    templateUrl: 'Presentation/ngApp/views/contractorList.html',
                    controller: MrConstruction.Controllers.ContractorListController,
                    controllerAs: 'controller'
                });

            $routeProvider
                .when('/project-list', {
                    templateUrl: 'Presentation/ngApp/views/projectList.html',
                    controller: MrConstruction.Controllers.ProjectController,
                    controllerAs: 'controller'
                });

            $routeProvider
                .when('/new-project', {
                    templateUrl: 'Presentation/ngApp/views/newProject.html',
                    controller: MrConstruction.Controllers.NewProjectController,
                    controllerAs: 'controller'
                });

            $routeProvider
                .when('/login', {
                    templateUrl: 'Presentation/ngApp/views/login.html',
                    controller: MrConstruction.Controllers.AuthController,
                    controllerAs: 'controller'
                });

            $routeProvider
                .when('/task-details/:id', {
                    templateUrl: '/Presentation/ngApp/views/taskDetails.html',
                    controller: MrConstruction.Controllers.TaskDetailsController,
                    controllerAs: 'controller'
                });

            $routeProvider
                .when('/project-details/:id', {
                    templateUrl: 'Presentation/ngApp/views/projectDetails.html',
                    controller: MrConstruction.Controllers.ProjectDetailsController,
                    controllerAs: 'controller'
                });

            $routeProvider
                .when('/portfolio', {
                    templateUrl: 'Presentation/ngApp/views/publicPortfolio.html',
                    controller: MrConstruction.Controllers.PortfolioController,
                    controllerAs: 'controller'
                });

            $routeProvider
                .when('/about', {
                    templateUrl: 'Presentation/ngApp/views/publicAbout.html'
                });

            $routeProvider
                .when('/', {
                    templateUrl: 'Presentation/ngApp/views/publicLanding.html'
                });
        });
}

