app.controller('PaymentReceiptController', function ($scope, $location, httpService, $rootScope, $http, $filter) {

    $scope.init = function () {
        $scope.initModel();
        var s1 = location.search.substring(1, location.search.length).split('&');
        if (s1[0].length > 0) {
            var s1 = location.search.substring(1, location.search.length).split('&'),
            r = {}, s2, i;
            for (i = 0; i < s1.length; i += 1) {
                s2 = s1[i].split('=');
                r[decodeURIComponent(s2[0]).toLowerCase()] = decodeURIComponent(s2[1]);
            }
            httpService.createCookie("payResUrl", JSON.stringify(r));
            window.location.href = window.location.origin + '#/paymentReceipt';
        }
        else
            $scope.displayReceipt();
    }

    $scope.initModel = function () {
        $scope.modalPaymentResponse = {
            cstsessionid: '',
            internaldata: '',
            orderid: '',
            ssl_account_balance: '',
            ssl_address2: '',
            ssl_amount: '',
            ssl_approval_code: '',
            ssl_avs_address: '',
            ssl_avs_response: '',
            ssl_avs_zip: '',
            ssl_card_number: '',
            ssl_city: '',
            ssl_company: '',
            ssl_country: '',
            ssl_customer_code: '',
            ssl_cvv2_response: '',
            ssl_eci_ind: '',
            ssl_email: '',
            ssl_exp_date: '',
            ssl_first_name: '',
            ssl_invoice_number: '',
            ssl_last_name: '',
            ssl_phone: '',
            ssl_result: '',
            ssl_result_message: '',
            ssl_salestax: '',
            ssl_state: '',
            ssl_txn_id: '',
            ssl_txn_time: '',
            
        }
    }

    $scope.displayReceipt = function () {
        var obj = httpService.readCookie("payResUrl");
        obj = JSON.parse(obj);
        obj.ssl_txn_time = obj.ssl_txn_time.replace('+', ' ').replace('+', ' ');
        $scope.modalPaymentResponse = obj;
    }

    
    $scope.init();
});