app.controller('JobsInABAListController', function ($scope, httpService, $http, $rootScope, $filter, $routeParams) {
    $scope.init = function () {
        $scope.initModel();

        if ($routeParams.JobKeyword)
            $scope.JobSearchModel.Keywords = $routeParams.JobKeyword;
        else
            $scope.Keywords = '';

        if ($routeParams.Location)
            $scope.JobSearchModel.Location = $routeParams.Location;
        else
            $scope.Location = '';

        if ($routeParams.CompnayName) {
            $("#txtCompanyName").val($routeParams.CompnayName);
            $scope.JobSearchModel.CompnayName = $routeParams.CompnayName;
        }
        else
            $scope.CompnayName = '';

        $scope.userId = parseInt(httpService.readCookie("uid"));
        $scope.getJobList();
        $scope.randomNumber = Math.random();
        $rootScope.autocompleteBusinessName();
    }

    $scope.initModel = function () {
        $scope.JobSearchModel = {
            CompnayName: '',
            Location: '',
            Keywords: ''
        }
        $scope.jobPagingModel = {
            pagingJobList: [],
            isComplete: true,
            isLastRecord: false,
            initialFrom: 0,
            initialTo: 8,
            dataLoadPerReq: 8,
            totalReocrd: 0,
        }
    }

    //for display full description for job
    $scope.displayJobFullDetail = function (id) {
        $scope["fullJobDetail_" + id] = true;
    }

    //get job list
    $scope.getJobList = function () {
        if ($scope.jobPagingModel.isComplete && !$scope.jobPagingModel.isLastRecord) {
            $scope.jobPagingModel.isComplete = false;
            var params = {
                jobTitle: $scope.JobSearchModel.Keywords,
                companyName: $("#txtCompanyName").val(),//$scope.JobSearchModel.CompnayName,
                location: $scope.JobSearchModel.Location,
                userID: $scope.userId,
                from: $scope.jobPagingModel.initialFrom,
                to: $scope.jobPagingModel.initialTo
            }

            $("#jobsInABAListDiv").block({ message: '<img src="Assets/img/loader.gif" />' });
            $http.get($rootScope.API_PATH + "/Jobs/GetJobsBySearch", { params: params }).success(function (listJob) {
                var data = listJob.record;
                $("#jobsInABAListDiv").unblock();
                for (var i = 0; i < data.length; i++) {
                    var newobj = new Object();
                    var newRow = [];
                    if (data[i].Business != null && data[i].Business != "") {
                        if (data[i].Business.BusinessImages != undefined && data[i].Business.BusinessImages.length > 0) {
                            for (var j = 0; j < data[i].Business.BusinessImages.length; j++) {
                                if (data[i].Business.BusinessImages[j].IsPrimary == true) {
                                    newobj["ImageExtension"] = data[i].Business.BusinessImages[j].Image.ImageExtension;
                                }
                            }
                        }
                        if (data[i].Business.BusinessAddresses.length > 0) {
                            for (var j = 0; j < data[i].Business.BusinessAddresses.length; j++) {
                                if (data[i].Business.BusinessAddresses[j].IsPrimary == true) {
                                    if (data[i].Business.BusinessAddresses[j].Addres != null && data[i].Business.BusinessAddresses[j].Addres != undefined) {
                                        newobj["City"] = data[i].Business.BusinessAddresses[j].Addres.City;
                                    }
                                }
                            }
                        }
                        if (data[i].Business != null && data[i].Business.User != null && data[i].Business.User.UserID == $scope.userId) {
                            newobj["IsBusinessOwner"] = 1;
                        }
                        newobj["BusinessName"] = data[i].Business.Name;

                        newRow.push(newobj);
                    }
                    data[i]["businessDetail"] = newRow[0];
                    data[i].StartDate = $rootScope.setDateformat(data[i].StartDate);
                    data[i].EndDate = $rootScope.setDateformat(data[i].EndDate);
                }
                //lazy loading
                $scope.jobPagingModel.totalReocrd = listJob.TotalJobCount;
                $scope.jobPagingModel.pagingJobList = $scope.jobPagingModel.pagingJobList.concat(data);
                $scope.jobPagingModel.initialFrom += $scope.jobPagingModel.dataLoadPerReq;
                $scope.jobPagingModel.initialTo += $scope.jobPagingModel.dataLoadPerReq;
                $scope.jobPagingModel.isComplete = true;
                if ($scope.jobPagingModel.pagingJobList.length >= $scope.jobPagingModel.totalReocrd) {
                    $scope.jobPagingModel.isLastRecord = true;
                }
                $scope.lstABAJobs = $scope.jobPagingModel.pagingJobList;
                //end
            }).error(function (data) {
                console.log(JSON.stringify(data));
            });
        }
    }

    //search job
    $scope.searchJobList = function () {
        $scope.jobPagingModel = {
            pagingJobList: [],
            isComplete: true,
            isLastRecord: false,
            initialFrom: 0,
            initialTo: 4,
            dataLoadPerReq: 4,
            totalReocrd: 0,
        }
        $scope.getJobList();
    }
    $scope.init();

});