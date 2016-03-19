app.controller('JobsController', function ($scope, httpService, $http, $routeParams, $rootScope, $filter, $location) {
    $scope.init = function () {
        $scope.initModel();
        $scope.jobId = parseInt($routeParams.JobID);
        $scope.businessID = parseInt($routeParams.BusinessID);
        if ($scope.jobId)
            $scope.getJobDetailById($scope.jobId);
        $scope.randomNumber = Math.random();
        $rootScope.reloadDatePicker();
    }

    $scope.initModel = function () {
        $scope.jobsModel = {
            JobID: '',
            BusinessID: $scope.businessID,
            Title: '',
            Description: '',
            JobTypeID: '',
            IsActive: true,
            IsDeleted: false,
            StartDate: '',
            EndDate: '',
        }
        $scope.isEditMode = false;
    }


    //for job detail page
    $scope.getJobDetailById = function (id) {
        var params = {
            id: id
        }
        $http.get($rootScope.API_PATH + "/Jobs/GetJob/", { params: params }).then(function (data) {
            if (data.data.StartDate != null) {
                data.data.StartDate = $rootScope.setDateformat(data.data.StartDate);
            }
            if (data.data.EndDate != null) {
                data.data.EndDate = $rootScope.setDateformat(data.data.EndDate);
            }
            $scope.ImageExtension = '';
            if (data.data.Business != null && data.data.Business != "" && data.data.Business.BusinessImages != undefined && data.data.Business.BusinessImages.length > 0) {
                for (var j = 0; j < data.data.Business.BusinessImages.length; j++) {
                    if (data.data.Business.BusinessImages[j].IsPrimary == true) {
                        $scope.ImageExtension = data.data.Business.BusinessImages[j].Image.ImageExtension;
                    }
                }
            }
            $scope.objJobDetail = data.data;
            $scope.jobsModel = data.data;
        }, function (data) {

        });
    }

    ////create job
    $scope.createJob = function (obj) {
        if ($scope.jobsModel.Title == undefined || $scope.jobsModel.Title.length == 0) {
            toastr.error('Enter job title');
            return;
        }
        obj.BusinessID = $scope.businessID;
        obj.JobTypeID = 4;
        if (obj.JobID == "") {
            obj.JobID = 0;
            $http.post($rootScope.API_PATH + "/Jobs/PostJob", obj).success(function (data) {
                $scope.initModel();
                toastr.success("job created successfully");
                $location.path('/viewcompanyprofile/' + $scope.businessID);
            }).error(function (data) {
                toastr.error("error in job create");
            })
        }
        else {
            $http.put($rootScope.API_PATH + "/Jobs/PutJob/" + obj.JobID, obj).success(function (data) {
                $scope.initModel();
                toastr.success("job updated successfully");
                $location.path('/viewcompanyprofile/' + $scope.businessID);
            }).error(function (data) {
                toastr.error("error in job update");
            })
        }


    }


    $scope.init();

});