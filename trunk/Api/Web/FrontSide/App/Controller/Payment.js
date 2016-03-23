app.controller('PaymentController', function ($scope, $location, httpService, $rootScope, $http, $filter) {

    $scope.init = function () {
        $scope.initModel();
    }

    $scope.initModel = function () {

        $scope.paymentModel = {
            CreditCardNumber : '',
            ExpirationDate : '',
            CSCNumber : '',
            FirstName : '',
            LastName : '',
            Address : '',
            City : '',
            State : '',
            Zip : '',
            Phone : '',
            Email : '',
            T_C: false,
            NameOnCard:''
        }
        
    }

    $scope.init();
});