app.controller('CreatePasswordController', function ($scope, $location, httpService, $rootScope, $http, $filter, $routeParams) {

    $scope.init = function () {
        $scope.UserID = $routeParams.UserID;
    }

    $scope.CreatePassword = function () {
        if ($scope.newPassword != $scope.ConfirmPassword) {
            toastr.error("password and confirm password not match. try again.")
            return;
        }

        var params = {
            UserAccountPassword: $scope.newPassword,
            EncodeUserID: $scope.UserID
        }

        $http.post($rootScope.API_PATH + "/Account/CreatePassword", params).success(function (data) {
            toastr.success("password change successfully");
            $location.path('/login');
        }).error(function (data) {
            toastr.error("error in change password");
        });
    }

    $scope.init();
});