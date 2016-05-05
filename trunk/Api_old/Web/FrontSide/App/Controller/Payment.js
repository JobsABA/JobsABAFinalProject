app.controller('PaymentController', function ($scope, $location, httpService, $rootScope, $http, $filter, $routeParams) {

    $scope.init = function () {
        $scope.orderID = $routeParams.OrderID;//for curruntly, order id is order value
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

        $("#orderid").val($scope.orderID);
        $("#ssl_amount").val($scope.orderID);
        $("#ssl_customer_code").val(httpService.readCookie("uname"));
        var redirectLkn = window.location.origin + "/#paymentReceipt";
        $("#ssl_receipt_link_url").val(redirectLkn)
        
    }

    $scope.payment = function (formValid) {
        $scope.isSubmit = true;
        if (!formValid)
            return;
    }

    $scope.init();
});