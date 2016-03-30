app.controller('SubScriptionController', function ($scope, $location, httpService, $rootScope, $http, $filter) {

    $scope.init = function () {
        
    }

    //make payment
    $scope.gotoPayment = function (val) {
        $("#ssl_amount").val(val);
        $("#ssl_customer_code").val(httpService.readCookie("uname"));
        var redirectLkn = window.location.origin + "/#paymentReceipt";
        $("#ssl_receipt_link_url").val(redirectLkn)
        $("#paymentForm")[0].submit();
        return;
        //var params = {
        //    ssl_amount: val,
        //    ssl_merchant_id: '003125',
        //    ssl_user_id: 'webpage',
        //    ssl_pin: 'IG7CEY',
        //    ssl_transaction_type: 'ccsale',
        //    ssl_show_form: true,
        //    ssl_cvv2cvc2_indicator: 1,
        //    ssl_invoice_number: '1234567',
        //    ssl_customer_code: httpService.readCookie("uname"),
        //}

        //$.ajax({
        //    type: 'JSONP',
        //    url: 'https://demo.myvirtualmerchant.com/VirtualMerchantDemo/process.do',
        //    crossDomain: true,
        //    data: 'ssl_amount= ' + val + '&ssl_merchant_id=003125',
        //    dataType: 'json',
        //    success: function (responseData, textStatus, jqXHR) {
        //        alert('success');
        //    },
        //    error: function (responseData, textStatus, errorThrown) {
        //        alert('POST failed.');
        //    }
        //});

        //$http.post("https://demo.myvirtualmerchant.com/VirtualMerchantDemo/process.do", params).success(function (data) {
        //    console.log(data);
        //}).error(function (data) {
        //    console.log(data);
        //});
    }

    $scope.init();
});