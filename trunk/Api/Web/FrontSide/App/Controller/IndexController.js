app.controller('IndexController', function ($scope, $location, httpService, $rootScope, $http, $filter) {

    $scope.init = function () {
        $scope.initModel();
        $rootScope.loginUserName = httpService.readCookie("uname");
        $rootScope.userId = parseInt(httpService.readCookie("uid"));
        if ($rootScope.userId) {
            $rootScope.getCompanylist($rootScope.userId);
        }
        $rootScope.getFullCompanylist();
        $scope.randomNumber = Math.random();
        
    }

    $scope.initModel = function () {
        $scope.searchjobModel = {
            KeyWord: '',
            Location: '',
            CompnayName: ''
        }
    }

    //for logout
    $scope.logOut = function () {
        httpService.eraseCookie("uid");
        httpService.eraseCookie("uname");
        $rootScope.loginUserName = httpService.readCookie("uname");
        $rootScope.userId = parseInt(httpService.readCookie("uid"));
        $location.path('/login');
        $rootScope.UserLogin = false;
    }

    //get company list by user for menubar
    $rootScope.getCompanylist = function (uid) {
        var params = {
            id: uid
        }
        $("#menubarBuisnessList").block({ message: '<img src="Assets/img/loader.gif" />' });
        $http.get($rootScope.API_PATH + "/Users/GetUsersWiseCompany", { params: params }).success(function (data) {
            $("#menubarBuisnessList").unblock();
            $rootScope.menuLstBusiness = data;
        }).error(function (data) {
            console.log(JSON.stringify(data));
        });
    }

    //get full company list 
    $rootScope.getFullCompanylist = function () {
        $http.get($rootScope.API_PATH + "/Businesses/GetBusinesses").success(function (data) {
            $rootScope.fulllLstBusiness = data;
        }).error(function (data) {
            console.log(JSON.stringify(data));
        });
    }

    //for reload date picker
    $rootScope.reloadDatePicker = function () {
        $(".datepicer").datepicker({
            changeMonth: true,
            changeYear: true
        });
    }

    //apply for job
    $rootScope.applyJob = function (jobID) {
        var params = {
            JobID: jobID,
            ApplicantUserID: $rootScope.userId
        }
        $http.post($rootScope.API_PATH + "/JobApplications/PostJobApplication", params).success(function (data) {
            toastr.success("successfully apply for this job");
        }).error(function (data, status, headers, config) {
            if (status == 409) {
                toastr.info("you are already applied for this job");
            }
            else {
                toastr.error("error in job apply. try again");
            }
        });
    }

    //for mouse hover div display/hide
    $rootScope.onmousehover = function (name, id) {
        $scope[name + id] = true;
    }
    $rootScope.onmouseleave = function (name, id) {
        $scope[name + id] = false;
    }

    //autocomplete
    $rootScope.autocompleteBusinessName = function () {
        $('.bussinessList').autocomplete({
            source: function (request, response) {
                var newBusinessList = [];
                if ($rootScope.fulllLstBusiness != null) {
                    for (var i = 0; i < $rootScope.fulllLstBusiness.length; i++) {
                        if ($rootScope.fulllLstBusiness[i].Name.toLowerCase().indexOf(request.term.toLowerCase()) !== -1) {
                            newBusinessList.push($rootScope.fulllLstBusiness[i]);
                        }
                    }
                }
                response($.map(newBusinessList, function (value, key) {
                    return {
                        label: value.Name,
                        value: value.Name,
                        key: value.BusinessID,
                    };
                }));
            },
            select: function (event, ui) {
                $(".bussinessList_ID").val(ui.item.key);
                $(".bussinessList").val(ui.item.value);
            },
            minLength: 1,

        });
    }

    //for change dateformat
    $rootScope.setDateformat = function (_date) {
        var date = new Date(_date);
        return (date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear();
    }
    $scope.init();
});
