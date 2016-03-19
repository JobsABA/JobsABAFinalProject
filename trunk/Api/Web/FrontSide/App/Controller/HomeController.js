app.controller('HomeController', function ($scope, $location, httpService, $rootScope, $http, $filter) {

    $scope.init = function () {
        $rootScope.loginUserName = httpService.readCookie("uname");
        $scope.userId = parseInt(httpService.readCookie("uid"));
        $rootScope.autocompleteBusinessName();
        $scope.getCompanyList();
        $scope.getJobsinABAList();
        $scope.randomNumber = Math.random();
    }

    //redirect to company detail page
    $scope.goToViewCompanyDetailPage = function (companyID) {
        $location.path('/viewcompanyprofile/' + companyID);
    }

    //for search job
    $scope.searchJob = function () {
        //$location.url('/jobsInAba?JobKeyword=' + $scope.searchjobModel.KeyWord + '&Location=' +  $("#txtCompanyName").val(), + '&CompnayName=' + $scope.searchjobModel.CompnayName);
        $location.url('/jobsInAba?JobKeyword=' + $scope.searchjobModel.KeyWord + '&Location=' + $scope.searchjobModel.Location + '&CompnayName=' + $("#txtCompanyName").val());
    }

    //for display full description for job
    $scope.displayJobFullDetail = function (id) {
        $scope["fullJobDetail_" + id] = true;
    }

    $scope.redirectToABAService = function () {
        $location.path('/abaServiceProvide');
    }

    $scope.redirectToJobsInAba = function () {
        $location.path('/jobsInAba');
    }

    //get full company list
    $scope.getCompanyList = function () {
        var params = {
            companyname: '',
            city:'',
            from: 0,
            to: 8
        }
        $("#homePageBusinessListDiv").block({ message: '<img src="Assets/img/loader.gif" />' });
        $http.get($rootScope.API_PATH + "/Businesses/GetBusinessesBySearch", { params: params }).success(function (data) {
            $("#homePageBusinessListDiv").unblock();
            $scope.lstBusiness = data;
        }).error(function (data) {
            toastr.error("error in fetch company list. try again");
        })
    }

    //for get job list
    $scope.getJobsinABAList = function () {
        var params = {
            companyName: '',
            jobTitle: '',
            location:'',
            from: 0,
            to: 8
        }
        $("#homePageJobDiv").block({ message: '<img src="Assets/img/loader.gif" />' });
        $http.get($rootScope.API_PATH + "/Jobs/GetJobsBySearch", { params: params }).success(function (data) {
            $("#homePageJobDiv").unblock();
            data = data.record;
            if (data != null) {
                for (var i = 0; i < data.length; i++) {
                    var newobj = new Object();
                    var newRow = [];
                    if (data[i].Business != null && data[i].Business != "" && data[i].Business.BusinessImages != undefined && data[i].Business.BusinessImages.length > 0) {
                        for (var j = 0; j < data[i].Business.BusinessImages.length; j++) {
                            if (data[i].Business.BusinessImages[j].IsPrimary == true) {
                                newobj["ImageExtension"] = data[i].Business.BusinessImages[j].Image.ImageExtension;
                            }
                        }
                        newRow.push(newobj);
                    }
                    if (data[i].Business != null && data[i].Business != "" && data[i].Business.BusinessAddresses != undefined && data[i].Business.BusinessAddresses.length > 0) {
                        for (var j = 0; j < data[i].Business.BusinessAddresses.length; j++) {
                            if (data[i].Business.BusinessAddresses[j].IsPrimary == true) {
                                newobj["City"] = data[i].Business.BusinessAddresses[j].Addres.City;
                            }
                        }
                        newRow.push(newobj);
                    }
                    if (data[i].Business != null && data[i].Business.User != null && data[i].Business.User.UserID == $scope.userId) {
                        newobj["IsBusinessOwner"] = 1;
                    }
                    data[i]["businessDetail"] = newRow[0];

                    data[i].StartDate = $rootScope.setDateformat(data[i].StartDate);
                    data[i].EndDate = $rootScope.setDateformat(data[i].EndDate);
                }
            }

            $scope.lstJobs = data;
        }).error(function (data) {
            console.log(JSON.stringify(data));
        })
    }
    $scope.init();
});