app.controller('RegisterController', function ($scope, httpService, $http) {
    //$scope.init = function () {
    //    $scope.firstName = '';
    //    $scope.lastName = '';
    //    $scope.password = '';
    //    $scope.confirmPassword = '';
    //    $scope.email = '';
    //    $scope.city = '';
    //    $scope.state = '';
    //    $scope.zip = '';
    //    $scope.howDidYouFindABA = '';
    //    $scope.whichOfTheSocialMediaUse = '';
    //}

    $scope.register = function () {

        if ($scope.password != $scope.confirmPassword) {
            alert("Password and  confirm password not match");
            return;
        }

        //var User = {
        //    FirstName: $scope.firstName,
        //    MiddleName: "",
        //    LastName: $scope.lastName,
        //    Password: $scope.password,
        //    ConfirmPassword: $scope.confirmPassword,
        //    UserName: $scope.email,
        //    City: $scope.city,
        //    State: $scope.state,
        //    Zip: $scope.zip,
        //    HighestLevelOfEducation: $scope.highestLevelOfEducation,
        //    HowDidYouFindABA: $scope.howDidYouFindABA,
        //    WhichOfTheSocialMediaUse: $scope.whichOfTheSocialMediaUse,
        //    IsActive: true,
        //    IsDeleted: false
        //}

        //var UserAccount = {
        //    UserName: $scope.email,
        //    Password: $scope.password,
        //    IsActive: true,
        //    IsDeleted: false
        //}

        //var userDataModel = [
        //    {
        //        user: {
        //            name: 'asd',
        //            pass:'asd'
        //        }
        //    }
        //]

        var UserDataModel = {
            FirstName: $scope.firstName,
            MiddleName:'',
            LastName: $scope.lastName,
            DOB: '',
            IsActive: false,
            IsDeleted: false,
            insuser: 0,
            insdt: Date(),
            upduser: 0,
            upddt: Date(),
            UserAccountUserName: $scope.email,
            UserName: $scope.email,
            UserAddressCity: '1',
            UserAddressState: $scope.state,
            UserAddressZipCode: $scope.zip,
            UserAccountPassword: $scope.password,
            HighestLevelOfEducation: $scope.highestLevelOfEducation,
            HowDidYouFindABA: $scope.howDidYouFindABA,
            WhichOfTheSocialMediaUse: $scope.whichOfTheSocialMediaUse,
            UserAccountIsActive: true,
            UserAccountIsDeleted: false
        }

        //var addAccountResult = httpService.post(UserAccount, "/Api/UserAccount/PostUserAccount");
        //addAccountResult.then(function (pl) {
        //    alert("Success" + pl);
        //}, function (errorPl) {
        //    alert("Error" + errorPl);
        //});

        var addUserResult = httpService.post(UserDataModel, "/api/users");
        addUserResult.then(function (pl) {
            alert("Success");
        }, function (errorPl) {
            alert("Error");
        });



        //var responce = $http({
        //    method: "post",
        //    url: "/api/Users/AddUsers",
        //    data: User,
        //    async: false
        //});

        //responce.then(function (pl) {
        //    $scope.message = "Success";
        //},
        //      function (errorPl) {
        //          $scope.message = 'failure loading', errorPl;
        //      });

        //$http({
        //    method: "post",
        //    url: "/api/UserAccount/AddUserAccount",
        //    data: UserAccount,
        //    async: false
        //}).then(function (pl) {
        //    $scope.message = "Success";
        //},
        //      function (errorPl) {
        //          $scope.message = 'failure loading', errorPl;
        //      });
    }
});