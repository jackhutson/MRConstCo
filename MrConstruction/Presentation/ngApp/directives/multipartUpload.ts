namespace MrConstruction.Directives {

// <input type="file" file-model="upload.file" />
    angular.module('MrConstruction').directive('fileModel',['$parse', '$http', function ($parse, $http) {
        return {
            restrict: 'A',
            link: function (scope, element: any, attrs: ng.IAttributes) {
                var model = $parse(attrs['fileModel']);
                var modelSetter = model.assign;

                element.bind('change', function () {
                    scope.$apply(function () {
                        modelSetter(scope, element[0].files[0]);
                    });
                });
            }
        };
    }]);

    angular.module('MrConstruction').decorator('$http', ['$delegate', function ($delegate) {
        $delegate.postMultipart = function (url, data, options: any = {}) {
            let formData = new FormData();

            for (let k in data) {
                formData.append(k, data[k]);
            }

            options.transformRequest = angular.identity;
            options.headers = options.headers || {};
            options.headers['Content-Type'] = undefined;

            return this.post(url, formData, options);
        };

        return $delegate;
    }]);
}