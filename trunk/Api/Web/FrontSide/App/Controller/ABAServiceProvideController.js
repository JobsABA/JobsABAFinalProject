app.controller('ABAServiceProviderController', function ($scope, httpService, $http, $rootScope) {
    $scope.init = function () {
        $scope.initModel();
        $scope.getFullCompanyListABAService();
        $scope.randomNumber = Math.random();
        $rootScope.autocompleteBusinessName();
    }

    $scope.initModel = function () {
        $scope.companySearchModel = {
            companyName: '',
            City: ''
        }

        $scope.CompanyPagingModel = {
            pagingCompanyList: [],
            isComplete: true,
            isLastRecord: false,
            initialFrom: 0,
            initialTo: 8,
            dataLoadPerReq: 8,
            totalReocrd: 0,
        }
    }

    //get companuy
    $scope.getFullCompanyListABAService = function () {
        if ($scope.CompanyPagingModel.isComplete && !$scope.CompanyPagingModel.isLastRecord) {
            $scope.CompanyPagingModel.isComplete = false;
            var params = {
                companyname: $scope.companySearchModel.companyName,
                city: $scope.companySearchModel.City,
                from: $scope.CompanyPagingModel.initialFrom,
                to: $scope.CompanyPagingModel.initialTo
            }
            $("#abaServiceProviderMainDiv").block({ message: '<img src="Assets/img/loader.gif" />' });
            $http.get($rootScope.API_PATH + "/Businesses/GetBusinessesBySearch", { params: params }).success(function (data) {
                $("#abaServiceProviderMainDiv").unblock();

                //lazy loading
                if (data.length != 0)
                    $scope.CompanyPagingModel.totalReocrd = data[0].Count;
                else
                    $scope.CompanyPagingModel.totalReocrd = 0;
                $scope.CompanyPagingModel.pagingCompanyList = $scope.CompanyPagingModel.pagingCompanyList.concat(data);
                $scope.CompanyPagingModel.initialFrom += $scope.CompanyPagingModel.dataLoadPerReq;
                $scope.CompanyPagingModel.initialTo += $scope.CompanyPagingModel.dataLoadPerReq;
                $scope.CompanyPagingModel.isComplete = true;
                if ($scope.CompanyPagingModel.pagingCompanyList.length >= $scope.CompanyPagingModel.totalReocrd) {
                    $scope.CompanyPagingModel.isLastRecord = true;
                }

                $scope.lstBusinessList = $scope.CompanyPagingModel.pagingCompanyList;
            }).error(function (data) {
                console.log(data);
            });
        }
    }


    //search job
    $scope.searchCompanyList = function () {
        $scope.CompanyPagingModel = {
            pagingCompanyList: [],
            isComplete: true,
            isLastRecord: false,
            initialFrom: 0,
            initialTo: 8,
            dataLoadPerReq: 8,
            totalReocrd: 0,
        }
        $scope.getFullCompanyListABAService();
    }
    $scope.init();
});