app.controller('JobsController', function ($scope, httpService, $http, $routeParams) {
    $scope.init = function () {
        $scope.initModel();
        $scope.getJobList();
        $scope.jobId = parseInt($routeParams.jobId);
        if ($scope.jobId != undefined)
            $scope.getJobDetailById($scope.jobId);
    }

    $scope.initModel = function () {
        $scope.jobsModel = {
            JobID: '',
            BusinessID: '',
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

    $scope.getJobList = function () {
        $http.get("api/Jobs").success(function (data) {
            console.log(data);
        }).error(function (data) {
            alert("error");
        });
    }

    $scope.getJobDetailById = function (id) {
        $scope.isEditMode = true;
        $scope.jobsModel.JobID = id;
        $http.get("api/Jobs/" + id).then(function (data) {
            console.log(data);
        }, function (data) {
            //alert("error" + data);
        });
    }

    $scope.createJob = function (obj) {
        var addJobsResult = httpService.post(obj, "api/Jobs");
        addJobsResult.then(function (pl) {
            alert("Success");
        }, function (errorPl) {
            alert("Error");
        });
    }

    $scope.updateJob = function (obj) {
        obj.JobID = $scope.jobsModel.JobID
        console.log(obj);
        var params = {
            id: obj.JobID
        }
        $http.put("api/Jobs/" + obj.JobID, obj, { params: params }).success(function (data) {
            alert("success");
        }).error(function (data) {
            alert("error" + JSON.stringify(data));
        });
    }

    

    $scope.init();

});