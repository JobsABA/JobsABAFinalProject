﻿app.controller('ChangePasswordController', function ($scope, $location, httpService, $rootScope, $http, $filter) {

    $scope.init = function () {
        $scope.loginUserId = parseInt(httpService.readCookie("uid"));
    }

    $scope.ChangePassword = function () {
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
            toastr.success("password change successfully");
            $location.path('/');
        }).error(function (data) {
            toastr.error("error in change password");
        });
    }

    $scope.init();
});