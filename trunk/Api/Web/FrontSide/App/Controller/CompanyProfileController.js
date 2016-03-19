app.controller('CompanyProfileController', function ($scope, httpService, $http, $routeParams, $rootScope, $location) {
    $scope.init = function () {
        $scope.initModel();
        $scope.userId = parseInt(httpService.readCookie("uid"));
        $rootScope.reloadDatePicker();
    }

    $scope.initModel = function () {

        //Company Detail
        $scope.companyDetailModel = {
            BusinessID: '',
            Name: '',
            Abbreviation: '',
            StartDate: '',
            BusinessTypeID: '',
            IsActive: false,
            IsDeleted: false,
            BusinessAddressLine1: '',
            BusinessAddressCity: '',
            BusinessAddressState: '',
            BusinessAddressZipCode: '',
            BusinessEmailAddress: '',
            BusinessPhoneNumber: '',
            Description: '',
        }
    }

    //$scope.getCompanylist = function () {
    //    var params = {
    //        userID: $scope.userId
    //    }
    //    $http.get($rootScope.API_PATH + "/Company/GetUserWiseBusinessList", { params: params }).success(function (data) {
    //        console.log(data);
    //        $scope.lstBusiness = data.businessList;
    //        $rootScope.menuLstBusiness = data.businessList;
    //        //$scope.$apply();
    //    }).error(function (data) {
    //        toastr.error("error in get company list");
    //    });
    //}

    $scope.addCompany = function () {
        //var _date = "";
        //if ($scope.companyDetailModel.StartDate.length > 0) {
        //    _date = new Date($scope.companyDetailModel.StartDate);
        //}
        var _addressArr = new Array();
        _addressArr[0] = new Object({
            Line1: $scope.companyDetailModel.BusinessAddressLine1,
            City: $scope.companyDetailModel.BusinessAddressCity,
            State: $scope.companyDetailModel.BusinessAddressState,
            ZipCode: $scope.companyDetailModel.BusinessAddressZipCode,
            AddressTypeID: 1
        });
        var Company = {
            Name: $scope.companyDetailModel.Name,
            Abbreviation: $scope.companyDetailModel.Abbreviation,
            StartDate: $scope.companyDetailModel.StartDate,
            BusinessTypeID: 3,
            BusinessUserMapTypeCodeId: 3,
            IsActive: true,
            IsDeleted: false,
            BusinessUserId: $scope.userId,
            Addresses: _addressArr,
            BusinessEmailAddress: $scope.companyDetailModel.BusinessEmailAddress,
            BusinessPhoneNumber: $scope.companyDetailModel.BusinessPhoneNumber,

            Description: $scope.companyDetailModel.Description,
        }
        $("#createCompanyDiv").block({ message: '<img src="Assets/img/loader.gif" />' });
        $http.post($rootScope.API_PATH + "/Businesses/PostBusiness", Company).success(function (data) {
            $("#createCompanyDiv").unblock();
            $scope.initModel();
            $rootScope.getCompanylist($scope.userId);
            toastr.success("Company Profile Created successfully");
            $scope.companyImageUpload(data.BusinessID);
        }).error(function (data) {
            $("#createCompanyDiv").unblock();
            toastr.error("error in create company profile. try again");
        });
    };

    //company logo upload
    $scope.companyImageUpload = function (BusinessID) {
        var formData = new FormData();
        var totalFiles = document.getElementById("uploadimage").files.length;
        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("uploadimage").files[i];

            formData.append("fupload", file);
            formData.append("businessID", BusinessID);
            formData.append("imageTypeId", 3);
        }

        $("#formCompanyCreate").block({ message: 'Business logo upload in progress.' });
        $.ajax({
            type: "POST",
            url: $rootScope.API_PATH + '/Account/PostFileBusiness',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            cache: false,
            success: function (data) {
                $("#formCompanyCreate").unblock();
                $location.path('/viewcompanyprofile/' + BusinessID);
            },
            error: function (error) {
                $("#formCompanyCreate").unblock();
                toastr.error('error in image upload');
            }
        });
    }

    //add new service
    $scope.changeService = function () {
        if ($scope.service == 'other')
            $scope.isOtherService = true;
        else
            $scope.isOtherService = false;
    }

    //close new service
    $scope.closeAddNewService = function () {
        $scope.isOtherService = false;
        $scope.service = '';
    }
    $scope.init();
});