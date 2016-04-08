app.controller('SubScriptionController', function ($scope, $location, httpService, $rootScope, $http, $filter) {

    $scope.init = function () {
        
    }

    //make payment
    $scope.gotoPayment = function (val) {

        $location.path('/payment/' + val);


        //$("#ssl_amount").val(val);
        //$("#ssl_customer_code").val(httpService.readCookie("uname"));
        //var redirectLkn = window.location.origin + "/#paymentReceipt";
        //$("#ssl_receipt_link_url").val(redirectLkn)
        //$("#paymentForm")[0].submit();
        //return;
        
    }

    $scope.init();
});