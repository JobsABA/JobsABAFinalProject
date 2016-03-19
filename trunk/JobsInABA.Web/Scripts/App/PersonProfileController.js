app.controller('PersonProfileController', function ($scope, httpService) {

    //GetUserDetailByID();

    //Profile Detail
    function GetUserDetailByID() {
        var userDetail = httpService.getByID(1, "api/Users/");
        userDetail.then(function (data) {
            $scope.firstName = data.data.FirstName;
            $scope.middleName = data.data.MiddleName;
            $scope.lastName = data.data.LastName;
            $scope.city = data.data.PrimaryAddressCity;
            $scope.state = data.data.PrimaryAddressState;
            $scope.zip = data.data.PrimaryAddressZipCode;
            $scope.email = data.data.UserName;
            $scope.phoneNo = data.data.PrimaryPhoneNumber;
            $scope.cell = "+91 8866185697";
        }, function (error) {
            alert("Error");
        });
    };

    //$scope.addProfileDetail = function () {
    //    var Detail = {
    //        UserName: $scope.email,
    //        FirstName: $scope.firstName,
    //        MiddleName: $scope.middleName,
    //        LastName: $scope.lastName,
    //        Summary: $scope.Summary
    //    }
    //    var addProfileDetail = httpService.post(Detail, "/api/Users/AddUsers");
    //    addProfileDetail.then(function (pl) {
    //        alert("Success");
    //    }, function (errorPl) {
    //        alert("Error");
    //    });
    //}

    ////Profile Summery
    //$scope.addProfileSummery = function () {
    //    var Summary = {
    //        UserName: $scope.email,
    //        Summary: $scope.Summary
    //    }
    //    var addSummary = httpService.post(Summary, "/api/Users/AddUsers");
    //    addSummary.then(function (pl) {
    //        alert("Success");
    //    }, function (errorPl) {
    //        alert("Error");
    //    });
    //}

    ////Profile Experiance
    //httpService.getByID("", id).then(function (data) {
    //    $scope.ProfileExperiance = data;
    //}, function (error) {
    //    alert("Error");
    //});
    //$scope.addProfileExperiance = function () {
    //    var Experiance = {
    //        UserName: $scope.email,
    //        CompanyName: $scope.companyName,
    //        JobPosition: $scope.jobPosition,
    //        Location: $scope.location,
    //        StartDate: $scope.startDate,
    //        EndDate: $scope.endDate
    //    }
    //    var addExperiance = httpService.post(Experiance, "/api/Users/AddUsers");
    //    addExperiance.then(function (pl) {
    //        alert("Success");
    //    }, function (errorPl) {
    //        alert("Error");
    //    });
    //}

    ////Profile Achievement
    //httpService.getByID("", id).then(function (data) {
    //    $scope.ProfileAchievement = data;
    //}, function (error) {
    //    alert("Error");
    //});
    //$scope.addProfileAchievement = function () {
    //    var Achievement = {
    //        UserName: $scope.email,
    //        Achievement: $scope.achievement,
    //        StartDate: $scope.startDate,
    //        EndDate: $scope.endDate
    //    }
    //    var addAchievement = httpService.post(Achievement, "/api/Users/AddUsers");
    //    addAchievement.then(function (pl) {
    //        alert("Success");
    //    }, function (errorPl) {
    //        alert("Error");
    //    });
    //}

    ////Profile Education
    //httpService.getByID("", id).then(function (data) {
    //    $scope.ProfileEducation = data;
    //}, function (error) {
    //    alert("Error");
    //});
    //$scope.addProfileEducation = function () {
    //    var ProfileEducation = {
    //        UserName: $scope.email,
    //        SchoolName: $scope.schoolName,
    //        StartDate: $scope.startDate,
    //        EndDate: $scope.endDate
    //    }
    //    var addProfileEducation = httpService.post(ProfileEducation, "/api/Users/AddUsers");
    //    addProfileEducation.then(function (pl) {
    //        alert("Success");
    //    }, function (errorPl) {
    //        alert("Error");
    //    });
    //}

    ////Skill Set
    //httpService.getByID("", id).then(function (data) {
    //    $scope.ProfileSkillSet = data;
    //}, function (error) {
    //    alert("Error");
    //});
    //$scope.addProfileSkillSet = function () {
    //    var Skill = {
    //        UserName: $scope.email,
    //        Skill: $scope.skill
    //    }
    //    var addProfileSkillSet = httpService.post(Skill, "/api/Users/AddUsers");
    //    addProfileSkillSet.then(function (pl) {
    //        alert("Success");
    //    }, function (errorPl) {
    //        alert("Error");
    //    });
    //}

    ////Profile Language
    //httpService.getByID("", id).then(function (data) {
    //    $scope.ProfileLanguage = data;
    //}, function (error) {
    //    alert("Error");
    //});
    //$scope.addProfileLanguage = function () {
    //    var Language = {
    //        UserName: $scope.email,
    //        Language: $scope.language
    //    }
    //    var addLanguage = httpService.post(Language, "/api/Users/AddUsers");
    //    addLanguage.then(function (pl) {
    //        alert("Success");
    //    }, function (errorPl) {
    //        alert("Error");
    //    });
    //}

    ////Phone No
    //httpService.getByID("", id).then(function (data) {
    //    $scope.PhoneNo = data;
    //}, function (error) {
    //    alert("Error");
    //});
    //$scope.addPhoneNo = function () {
    //    var Phone = {
    //        UserName: $scope.email,
    //        PhoneNo: $scope.phoneNo
    //    }
    //    var addPhoneNo = httpService.post(Phone, "/api/Users/AddUsers");
    //    addPhoneNo.then(function (pl) {
    //        alert("Success");
    //    }, function (errorPl) {
    //        alert("Error");
    //    });
    //}
});