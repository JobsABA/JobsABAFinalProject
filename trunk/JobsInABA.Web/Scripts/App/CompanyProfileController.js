app.controller('CompanyProfileController', function ($scope, httpService) {
    $scope.init = function () {
        $scope.initModel();

        $scope.getCompanySpecialist();
        $scope.getCompanyEmployeelist();
        $scope.getCompanyAchievelist();
        $scope.getCompanyLocationlist();
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
            BusinessPhoneNumber:''
        }

        //specialist
        $scope.addCompanySpecialistModel = {
            Name: ''
        }

        $scope.editCompanySpecialistModel = {
            id: '',
            Name: ''
        }
        //employee
        $scope.addCompanyEMPlistModel = {
            Name: ''
        }

        $scope.editCompanyEMPlistModel = {
            id: '',
            Name: ''
        }

        //company achievement
        $scope.addCompanyAchievelistModel = {
            Name: '',
            Date: '',
        }

        $scope.editCompanyAchievelistModel = {
            id: '',
            Name: '',
            Date: '',
            ImgUrl: ''
        }

        //company location
        $scope.addCompanyLocationlistModel = {
            Address1: '',
            Address2: '',
            City: '',
            State: '',
            Country: '',
            Employee: '',
            Phone: ''

        }

        $scope.editCompanyLocationlistModel = {
            id: '',
            Address1: '',
            Address2: '',
            City: '',
            State: '',
            Country: '',
            Employee: '',
            Phone: ''
        }
    }

    $scope.addCompany = function () {
        var Company = {
            Name: $scope.companyDetailModel.Name,
            Abbreviation: $scope.companyDetailModel.Abbreviation,
            StartDate: $scope.companyDetailModel.StartDate,
            BusinessTypeID: 3,
            IsActive: true,
            IsDeleted: false
        }

        var addCompanyResult = httpService.post(Company, "api/Businesses");
        addCompanyResult.then(function (pl) {
            alert("Success" + pl);
        }, function (errorPl) {
            alert("Error" + errorPl);
        });
    };

    //*********** start edit specialist **************//

    $scope.isEditSpecialist = false;
    // sample array for get comapny specialist record
    $scope.arrComSpe = [
        { id: 1, Name: "Hardik" },
        { id: 2, Name: "Krunal" },
        { id: 3, Name: "Arjun" },
        { id: 4, Name: "Test" }
    ];

    $scope.getCompanySpecialist = function () {
        $scope.objSpecialist = $scope.arrComSpe;

        //var getCompanyspecialist = httpService.getAll("set get company specialist url");
        //getCompanyspecialist.then(function (data) {
        //    console.log(data);
        //    $scope.objSpecialist = //put data list object

        //}, function () {
        //    alert("error");
        //})
    }

    $scope.addCompanySpecialist = function (obj) {
        console.log(obj);
        var params = {
            Name: obj.Name
        }
        $("#specialitiesform").hide();
        var addSpecialist = httpService.get(params, "api");
        //addSpecialist.then(function (data) {
        //    console.log(data);

        //    }, function () {
        //        alert("error");
        //    })
    }

    $scope.editSpecialist = function (obj) {
        $scope["isEditSpecialist_" + obj.id] = true;
        $scope.editCompanySpecialistModel.Name = obj.Name;
        $scope.editCompanySpecialistModel.id = obj.id;
    }

    $scope.saveEditSpecialist = function (obj) {
        $scope["isEditSpecialist_" + obj.id] = false;
        var params = {
            id: obj.id,
            Name: obj.Name
        }

        //var editSpecialist = httpService.get(params,"set get company specialist url");
        //editSpecialist.then(function (data) {
        //    console.log(data);
        //    $scope.objSpecialist = //put data list object

        //    }, function () {
        //        alert("error");
        //    })
    }

    $scope.cancelEditSpecialist = function (obj) {
        $scope["isEditSpecialist_" + obj.id] = false;
    }

    $scope.deleteSpecialist = function (id) {
        alert(id);
        var params = {
            id: id
        }
        //var deleteSpecialist = httpService.get(params,"set get company specialist url");
        //deleteSpecialist.then(function (data) {
        //    console.log(data);
        //    $scope.objSpecialist = //put data list object

        //    }, function () {
        //        alert("error");
        //    })
    }

    //*************end specialist  ****************//


    //*********** start edit employee **************//

    $scope.isEditEmplist = false;
    // sample array for get comapny specialist record
    $scope.arrEmpl = [
        { id: 1, Name: "Hardik Emp" },
        { id: 2, Name: "Krunal Emp" },
        { id: 3, Name: "Arjun Emp" },
        { id: 4, Name: "Test Emp" }
    ];

    $scope.getCompanyEmployeelist = function () {
        $scope.objEmplist = $scope.arrEmpl;

        //var getCompanyspecialist = httpService.getAll("set get company specialist url");
        //getCompanyspecialist.then(function (data) {
        //    console.log(data);
        //    $scope.objEmplist = //put data list object

        //}, function () {
        //    alert("error");
        //})
    }

    $scope.addCompanyEmplist = function (obj) {
        console.log(obj);
        var params = {
            Name: obj.Name
        }
        $("#employeeform").hide();
        var addSpecialist = httpService.get(params, "api");
        //addSpecialist.then(function (data) {
        //    console.log(data);

        //    }, function () {
        //        alert("error");
        //    })
    }

    $scope.editEMPlist = function (obj) {
        $scope["isEditEmplist_" + obj.id] = true;
        $scope.editCompanyEMPlistModel.Name = obj.Name;
        $scope.editCompanyEMPlistModel.id = obj.id;
    }

    $scope.saveEditEMPlist = function (obj) {
        $scope["isEditEmplist_" + obj.id] = false;
        var params = {
            id: obj.id,
            Name: obj.Name
        }

        //var editSpecialist = httpService.get(params,"set get company specialist url");
        //editSpecialist.then(function (data) {
        //    console.log(data);

        //    }, function () {
        //        alert("error");
        //    })
    }

    $scope.cancelEditEMPlist = function (obj) {
        $scope["isEditEmplist_" + obj.id] = false;
    }

    $scope.deleteEMPlist = function (id) {
        alert(id);
        var params = {
            id: id
        }
        //var deleteSpecialist = httpService.get(params,"set get company specialist url");
        //deleteSpecialist.then(function (data) {
        //    console.log(data);
        //    $scope.objSpecialist = //put data list object

        //    }, function () {
        //        alert("error");
        //    })
    }

    //*************end employee  ****************//


    //*********** start company achievement **************//


    // sample array for get comapny achievemrnt record
    $scope.arrAchieve = [
        { id: 1, Name: "test achievement 1", Date: "", imgUrl: "\\Assets\\img\\icon3.png" },
        { id: 2, Name: "test achievement 2", Date: "", imgUrl: "" },
        { id: 3, Name: "test achievement 3", Date: "", imgUrl: "" },
        { id: 4, Name: "test achievement 4", Date: "", imgUrl: "" }
    ];

    $scope.getCompanyAchievelist = function () {
        $scope.objAchievelist = $scope.arrAchieve;

        //var getCompanyspecialist = httpService.getAll("set get company specialist url");
        //getCompanyspecialist.then(function (data) {
        //    console.log(data);
        //    $scope.objEmplist = //put data list object

        //}, function () {
        //    alert("error");
        //})
    }

    $scope.addCompanyAchievelist = function (obj) {
        console.log(obj);

        $("#achivementform").hide();

        var formData = new FormData();
        var totalFiles = document.getElementById("fupload").files.length;
        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("fupload").files[i];
            formData.append("fupload", file);
        }
        formData.append("Name", obj.Name);
        formData.append("Date", obj.Date);
        $.ajax({
            type: "POST",
            url: '/Api/Users/Get',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (response) {

            },
            error: function (error) {

            }
        });
    }

    $scope.editAchievelist = function (obj) {
        $scope["isEditAchievelist_" + obj.id] = true;
        $scope.editCompanyAchievelistModel.Name = obj.Name;
        $scope.editCompanyAchievelistModel.id = obj.id;
        $scope.editCompanyAchievelistModel.Date = obj.Date;
    }

    $scope.saveEditAchievelist = function (obj) {
        $scope["isEditAchievelist_" + obj.id] = false;
        $("#achivementform").hide();

        var formData = new FormData();
        var totalFiles = document.getElementById("fupload_" + obj.id).files.length;
        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("fupload_" + obj.id).files[i];
            formData.append("fupload", file);
        }
        formData.append("Name", obj.Name);
        formData.append("Date", obj.Date);
        $.ajax({
            type: "POST",
            url: '/Api/Users/Get',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (response) {

            },
            error: function (error) {

            }
        });
    }

    $scope.cancelEditAchievelist = function (obj) {
        $scope["isEditAchievelist_" + obj.id] = false;
    }

    $scope.deleteAchievelist = function (id) {
        alert(id);
        var params = {
            id: id
        }
        //var deleteSpecialist = httpService.get(params,"set get company specialist url");
        //deleteSpecialist.then(function (data) {
        //    console.log(data);
        //    $scope.objSpecialist = //put data list object

        //    }, function () {
        //        alert("error");
        //    })
    }

    //*************end achievement  ****************//


    //*********** start company location **************//


    // sample array for get comapny achievemrnt record
    $scope.arrLocation = [
        { id: 1, Address1: "sarthana-1", Address2: "varachha-1", City: "surat-1", State: "gujarat-1", Country: "india-1", Employee: "testing-1", Phone: "1212121212" },
        { id: 2, Address1: "sarthana-2", Address2: "varachha-2", City: "surat-2", State: "gujarat-2", Country: "india-2", Employee: "testing-2", Phone: "1212121212" },
        { id: 3, Address1: "sarthana-3", Address2: "varachha-3", City: "surat-3", State: "gujarat-3", Country: "india-3", Employee: "testing-3", Phone: "1212121212" },
        { id: 4, Address1: "sarthana-4", Address2: "varachha-4", City: "surat-4", State: "gujarat-4", Country: "", Employee: "testing-4", Phone: "1212121212" },
    ];

    $scope.getCompanyLocationlist = function () {
        $scope.objLocationlist = $scope.arrLocation;

        //var getCompanyspecialist = httpService.getAll("set get company specialist url");
        //getCompanyspecialist.then(function (data) {
        //    console.log(data);
        //    $scope.objEmplist = //put data list object

        //}, function () {
        //    alert("error");
        //})
    }

    $scope.addCompanyLocationlist = function (obj) {
        console.log(obj);
        $("#locationform").hide();
        var addLocationlist = httpService.post(obj, "api");
        //addLocationlist.then(function (data) {
        //    console.log(data);

        //    }, function () {
        //        alert("error");
        //    })

    }

    $scope.editLocationlist = function (obj) {
        $scope["isEditLocationlist_" + obj.id] = true;
        $scope.editCompanyLocationlistModel = obj;
    }

    $scope.saveEditLocationlist = function (obj) {
        $scope["isEditLocationlist_" + obj.id] = false;
        $("#locationform").hide();

        var addLocationlist = httpService.post(obj, "api");
        //addSpecialist.then(function (data) {
        //    console.log(data);

        //    }, function () {
        //        alert("error");
        //    })
    }

    $scope.cancelEditLocationlist = function (obj) {
        $scope["isEditLocationlist_" + obj.id] = false;
    }

    $scope.deleteLocationlist = function (id) {
        alert(id);
        var params = {
            id: id
        }
        //var deleteSpecialist = httpService.get(params,"set get company specialist url");
        //deleteSpecialist.then(function (data) {
        //    console.log(data);
        //    $scope.objSpecialist = //put data list object

        //    }, function () {
        //        alert("error");
        //    })
    }

    //*************end location  ****************//
    $scope.init();
});