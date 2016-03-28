app.controller('ChangePasswordController', function ($scope, $location, httpService, $rootScope, $http, $filter) {

    $scope.init = function () {
        $scope.loginUserId = parseInt(httpService.readCookie("uid"));
    }

    $scope.ChangePassword = function (validForm) {
        $scope.isSubmit = true;
        if (!validForm)
            return;
        if ($scope.newPassword != $scope.ConfirmPassword) {
            toastr.error("password and confirm password not match. try again.")
            return;
        }

        var params = {
            CurrentPassword:$scope.currentPassword,
            UserAccountPassword: $scope.newPassword,
            UserID:$scope.loginUserId 
        }

        $http.post($rootScope.API_PATH + "/Account/ChangePassword", params).success(function (data) {
            if (data == "MisMatch") {
                toastr.error("enter valid currunt password");
                return;
            }
            else {
                toastr.success("password change successfully");
                $location.path('/');
            }
            
        }).error(function (data) {
            toastr.error("error in change password");
        });
    }

    $scope.init();
});