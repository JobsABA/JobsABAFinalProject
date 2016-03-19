app.controller('ContactUsController', function ($scope, $location, httpService, $rootScope, $http, $filter, $anchorScroll) {

    $scope.init = function () {
        //$scope.initModel();
    }

    $scope.initModel = function(){
        $scope.ContactUsModel = {
            UserType: '',
            Category: '',
            FirstName: '',
            LastName: '',
            EmailAddress: '',
            Phone: '',
            Title: '',
            Company: '',
            Message: '',
        }
    }

    $scope.scrollTo = function (id) {
        $location.hash(id);
        $anchorScroll();
    }

    $scope.contactUs = function () {

    }

    $scope.init();
});