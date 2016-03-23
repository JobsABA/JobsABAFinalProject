app.controller('PersonProfileController', function ($scope, httpService, $rootScope, $http, $location, $route, $filter, $routeParams) {

    $scope.init = function () {
        $scope.initModel();
        $scope.iniiUserInfoModel();
        $rootScope.loginUserName = httpService.readCookie("uname");
        $rootScope.showUpdateProfile = false;
        $scope.loginUserId = parseInt(httpService.readCookie("uid"));
        $scope.isOwnLogin = true;
        $scope.routeUserID = parseInt($routeParams.UserID);
        if ($scope.routeUserID) {
            $scope.userId = $scope.routeUserID;
            if ($scope.routeUserID != $scope.loginUserId) {
                $scope.isOwnLogin = false;
            }
        }
        else
            $scope.userId = $scope.loginUserId;

        $rootScope.IsPersonProfile == 1;
        $rootScope.IsPersonalProfile = true;
        $scope.isEditProfile_Image = true;
        $rootScope.reloadDatePicker();
        $rootScope.autocompleteBusinessName();
        $scope.randomNumber = Math.random();

        //initially call api
        $scope.getLoginUserDetail($scope.userId);

        $rootScope.showUpdateProfile = false;
    }

    $scope.iniiUserInfoModel = function () {
        $scope.userProfile = {
            UserID: '',
            UserEmailAddress: '',
            UserName: '',
            FirstName: '',
            MiddleName: '',
            LastName: '',
            DOB: '',
            IsActive: true,
            IsDeleted: false,
            UserAddressLine1: '',
            UserAddressCity: '',
            UserAddressState: '',
            UserAddressZipCode: '',
            UserAddressAddressTypeID: 1,
            UserPhoneNumber: '',
            Description: ''


        }
    }

    $scope.initModel = function () {
        $scope.userExprienceModel = {
            UserID: $scope.userId,
            BussinessName: '',
            BussinessID: '',
            JobPosition: '',
            JobLocation: '',
            StartDate: '',
            EndDate: '',
            ExperienceID: '',
            CompanyCity: '',
            CompanyState: '',
            CompanyZipCode: ''
        }
        $(".bussinessList").val('');
        $(".addLocationDiv").hide();
        $scope.userAchievementModel = {
            AchievementID: '',
            Name: '',
            Date: '',
            UserID: $scope.userId,
        }
        $scope.userEducationModel = {
            UserID: $scope.userId,
            InstituteName: '',
            Degree: '',
            Description: '',
            StartDate: '',
            EndDate: '',
            EducationID: ''
        }
        $scope.userSkillModel = {
            UserID: $scope.userId,
            Skill1: '',
            SkillID: ''
        }
        $scope.userLanguageModel = {
            UserID: $scope.userId,
            LanguageID: '',
            LanguageName: ''
        }
    }


    //get login user detail
    $scope.getLoginUserDetail = function (id) {
        $("#personalProfileMainDiv").block({ message: '<img src="Assets/img/loader.gif" />' });
        $http.get($rootScope.API_PATH + "/Users/GetUser/" + id).success(function (data) {
            $("#personalProfileMainDiv").unblock();
            console.log(data);
            //user basic detail
            $scope.userProfile = data;
            $scope.ImgExt = data.UserImageExt;
            $scope.isEditProfile_Image = false;

            //user exprience detail
            if (data.ExprienceModal != null) {
                for (var i = 0; i < data.ExprienceModal.length; i++) {
                    var newObj = new Object();
                    if (data.ExprienceModal[i].Business != null) {
                        newObj["BusinessName"] = data.ExprienceModal[i].Business.Name;
                        newObj["City"] = "";
                        newObj["State"] = "";
                        newObj["ZipCode"] = "";
                        if (data.ExprienceModal[i].Business != null && data.ExprienceModal[i].Business.BusinessAddresses != null && data.ExprienceModal[i].Business.BusinessAddresses.length > 0) {
                            for (var j = 0; j < data.ExprienceModal[i].Business.BusinessAddresses.length; j++) {
                                if (data.ExprienceModal[i].Business.BusinessAddresses[j].IsPrimary == true) {
                                    newObj["City"] = data.ExprienceModal[i].Business.BusinessAddresses[j].Addres.City;
                                    newObj["State"] = data.ExprienceModal[i].Business.BusinessAddresses[j].Addres.State;
                                    newObj["ZipCode"] = data.ExprienceModal[i].Business.BusinessAddresses[j].Addres.ZipCode;
                                }
                            }
                        }
                    }
                    var newRow = [];
                    newRow.push(newObj);
                    data.ExprienceModal[i]["businessDetail"] = newRow[0];
                }
                for (var i = 0; i < data.ExprienceModal.length; i++) {
                    data.ExprienceModal[i].StartDate = $rootScope.setDateformat(data.ExprienceModal[i].StartDate);
                    data.ExprienceModal[i].EndDate = $rootScope.setDateformat(data.ExprienceModal[i].EndDate);
                }
                $scope.lstUserExprience = data.ExprienceModal;
            }
            else
                $scope.lstUserExprience = [];

            //user achievement & Award
            if (data.AchievementModel != null) {
                for (var i = 0; i < data.AchievementModel.length; i++) {
                    data.AchievementModel[i].Date = $rootScope.setDateformat(data.AchievementModel[i].Date);
                }
                $scope.lstAchievelist = data.AchievementModel;
            }
            else
                $scope.lstAchievelist = [];

            //user education 
            if (data.EducationModel != null) {
                for (var i = 0; i < data.EducationModel.length; i++) {
                    data.EducationModel[i].StartDate = $rootScope.setDateformat(data.EducationModel[i].StartDate);
                    data.EducationModel[i].EndDate = $rootScope.setDateformat(data.EducationModel[i].EndDate);
                }
                $scope.Educationlists = data.EducationModel;
            }
            else
                $scope.Educationlists = [];

            //user skill
            if (data.SkillModel != null)
                $scope.lstSkillList = data.SkillModel;
            else
                $scope.lstSkillList = [];

            //user language
            if (data.LanguageModel != null)
                $scope.lstLanguageList = data.LanguageModel;
            else
                $scope.lstLanguageList = [];

        }).error(function () {
            $("#personalProfileMainDiv").unblock();
            console.log("error");
        })
    }

    //upload user image
    $scope.userImageUpload = function () {
        var formData = new FormData();
        var totalFiles = document.getElementById("uploadimage").files.length;
        for (var i = 0; i < totalFiles; i++) {
            var file = document.getElementById("uploadimage").files[i];

            formData.append("fupload", file);
            formData.append("userID", $scope.userId);
            formData.append("imageTypeId", 3);
        }
        $("#personalProfilePersonaDetail").block({ message: '<img src="Assets/img/loader.gif" />' });
        $.ajax({
            type: "POST",
            url: $rootScope.API_PATH + '/Account/PostFileUser',
            data: formData,
            dataType: 'json',
            contentType: false,
            processData: false,
            cache: false,
            success: function (data) {
                //$route.reload(true);
                $("#personalProfilePersonaDetail").unblock();
                $scope.getLoginUserDetail($scope.userId);
                $scope.isEditProfile_Image = true;
                $scope.randomNumber = Math.random();
            },
            error: function (error) {
                $("#personalProfilePersonaDetail").unblock();
                toastr.error('error in image upload');
            }
        });
    }

    //update user inforamtion
    $scope.updateUserInfo = function (objUser, pname) {
        var params = {
            id: $scope.userId
        }

        $http.put($rootScope.API_PATH + "/Users/PutUser/" + $scope.userId, objUser).success(function (data) {
            toastr.success("profile information updated successfully");
            $scope["isEditProfile_" + pname] = false;
        }).error(function (data) {
            toastr.error("error in update profile");
        })

    }

    //hide/show edit block for user informaiton update
    $scope.editUserInfo = function (userProfile, pname) {
        $scope.copyUserInfoObject = angular.copy(userProfile);
        $scope["isEditProfile_" + pname] = true;
    }

    $scope.cancleUpdateUserInfo = function (pname) {
        $scope.userProfile = $scope.copyUserInfoObject;
        $scope["isEditProfile_" + pname] = false;
    }



    //=======================================   user exprience  ========================================//
    //add user exprience
    $scope.addExprience = function (obj) {
        var name = $(".bussinessList").val();
        var isBusinessFromllist = _.where($rootScope.fulllLstBusiness, { Name: name }).length;
        if (isBusinessFromllist == 0) {//if compnay not in list, add new compnay

            var _addressArr = new Array();
            _addressArr[0] = new Object({
                City: obj.CompanyCity,
                State: obj.CompanyState,
                ZipCode: obj.CompanyZipCode,
                AddressTypeID: 1
            });

            var Company = {
                Name: name,
                BusinessTypeID: 3,
                BusinessUserMapTypeCodeId: 3,
                IsActive: false,
                IsDeleted: false,
                Addresses: _addressArr,
            }
            $http.post($rootScope.API_PATH + "/Businesses/PostBusiness", Company).success(function (data) {

                obj.BusinessID = data.BusinessID;
                obj.ExperienceID = 0;
                $http.post($rootScope.API_PATH + "/Experiences/PostExperience", obj).success(function (data) {
                    toastr.success("Exprience added successfully");
                    $scope.initModel();
                    $scope.isADDExprience = false;
                    $scope.getLoginUserDetail($scope.userId);//bcz in return object not getting company info
                    //$scope.lstUserExprience.push(data);
                }).error(function (data) {
                    toastr.error("error in add exprience");
                });

            });

        }
        else {

            obj.BusinessID = parseInt($(".bussinessList_ID").val());
            obj.ExperienceID = 0;
            $http.post($rootScope.API_PATH + "/Experiences/PostExperience", obj).success(function (data) {
                toastr.success("Exprience added successfully");
                $scope.initModel();
                $scope.isADDExprience = false;
                $scope.getLoginUserDetail($scope.userId);//bcz in return object not getting company info
                //$scope.lstUserExprience.push(data);
            }).error(function (data) {
                toastr.error("error in add exprience");
            });

        }

    }

    //cancel updation
    $scope.cancelUpdateExperience = function (id) {
        $scope["isEditExprience_" + id] = false;
        $scope.initModel();
        $scope.lstUserExprience = $scope.copyLstUserExprience;
    }

    //edit exprience
    $scope.editExprience = function (obj) {
        //$scope.userExprienceModel.BusinessName = obj.Business.Name;
        $scope.userExprienceModel = obj;


        if (obj.Business != null && obj.Business.BusinessAddresses != null && obj.Business.BusinessAddresses.length > 0) {
            for (var j = 0; j < obj.Business.BusinessAddresses.length; j++) {
                if (obj.Business.BusinessAddresses[j].IsPrimary == true) {
                    $scope.userExprienceModel.CompanyCity = obj.Business.BusinessAddresses[j].Addres.City;
                    $scope.userExprienceModel.CompanyState = obj.Business.BusinessAddresses[j].Addres.State;
                    $scope.userExprienceModel.CompanyZipCode = obj.Business.BusinessAddresses[j].Addres.ZipCode;
                }
            }
        }


        $(".addLocationDiv").show();
        $scope["isEditExprience_" + obj.ExperienceID] = true;
        $rootScope.autocompleteBusinessName();
        $rootScope.reloadDatePicker();
        $scope.copyLstUserExprience = angular.copy($scope.lstUserExprience);
    }

    //update user exprience set
    $scope.updateExprience = function (obj) {
        var name;
        if ($(".bussinessList").val().length == 0)
            name = obj.Business.Name;
        else
            name = $(".bussinessList").val();
        var isBusinessFromllist = _.where($rootScope.fulllLstBusiness, { Name: name }).length;
        var isBusinesIDFromList = _.where($rootScope.fulllLstBusiness, { BusinessID: obj.BusinessID }).length;

        if (isBusinessFromllist == 0) {//if compnay not in list, add new compnay

            if (isBusinesIDFromList == 0) {//if business id not already in list, update compmnay
                var _addressArr = new Array();
                _addressArr[0] = new Object({
                    City: obj.CompanyCity,
                    State: obj.CompanyState,
                    ZipCode: obj.CompanyZipCode,
                    AddressTypeID: 1,
                    AddressID: obj.Business.BusinessAddresses[0].AddressID
                });

                var Company = {
                    Name: name,
                    Addresses: _addressArr,
                    BusinessID: obj.BusinessID,
                    BusinessTypeID: 3,
                    BusinessUserMapTypeCodeId: 3,
                }

                $http.put($rootScope.API_PATH + "/Businesses/PutBusiness/" + obj.BusinessID, Company).success(function (data) {
                    obj.BusinessID = data.BusinessID;
                    obj.UserID = $scope.userId;
                    $http.put($rootScope.API_PATH + "/Experiences/PutExperience/" + obj.ExperienceID, obj).success(function (data) {
                        toastr.success("exprience updated successfully");
                        $scope.initModel();
                        $scope["isEditExprience_" + obj.ExperienceID] = false;
                        $scope.getLoginUserDetail($scope.userId);
                    }).error(function (data) {
                        toastr.error("error in update education information. try again");
                    });
                });
            }
            else {//if businessID already in autocomplete list, add new compny
                var _addressArr = new Array();
                _addressArr[0] = new Object({
                    City: obj.CompanyCity,
                    State: obj.CompanyState,
                    ZipCode: obj.CompanyZipCode,
                    AddressTypeID: 1,
                });

                var Company = {
                    Name: name,
                    Addresses: _addressArr,
                    BusinessTypeID: 3,
                    BusinessUserMapTypeCodeId: 3,
                    IsActive: false,
                    IsDeleted: false,
                }

                $http.post($rootScope.API_PATH + "/Businesses/PostBusiness", Company).success(function (data) {
                    obj.BusinessID = data.BusinessID;
                    obj.UserID = $scope.userId;
                    $http.put($rootScope.API_PATH + "/Experiences/PutExperience/" + obj.ExperienceID, obj).success(function (data) {
                        toastr.success("exprience updated successfully");
                        $scope.initModel();
                        $scope["isEditExprience_" + obj.ExperienceID] = false;
                        $scope.getLoginUserDetail($scope.userId);
                    }).error(function (data) {
                        toastr.error("error in update education information. try again");
                    });
                });
            }
            
        }
        else {
            if ($(".bussinessList_ID").val().length > 0)
                obj.BusinessID = parseInt($(".bussinessList_ID").val());
            obj.UserID = $scope.userId;
            $http.put($rootScope.API_PATH + "/Experiences/PutExperience/" + obj.ExperienceID, obj).success(function (data) {
                toastr.success("exprience updated successfully");
                $scope.initModel();
                $scope["isEditExprience_" + obj.ExperienceID] = false;
                $scope.getLoginUserDetail($scope.userId);
            }).error(function (data) {
                toastr.error("error in update education information. try again");
            })
        }

    }

    //delete user exprience
    $scope.deleteExprience = function (id) {
        var params = {
            id: id
        }
        $http.delete($rootScope.API_PATH + "/Experiences/DeleteExperience", { params: params }).success(function (data) {
            toastr.success("exprience deleted successfully");
            $scope.lstUserExprience = $.grep($scope.lstUserExprience, function (list, index) {
                return list.ExperienceID != data.ExperienceID;
            });
        }).error(function (data) {
            toastr.error("error in delete exprience. try again");
        })
    }

    //=======================================   user Achievement  ========================================//
    //add user Achievement
    $scope.addAchievement = function (obj) {
        obj.UserID = $scope.userId;
        obj.AchievementID = 0;
        $http.post($rootScope.API_PATH + "/Achievements/PostAchievement", obj).success(function (data) {
            toastr.success("user award added successfully");
            $scope.initModel();
            $scope.isAddAchievement = false;
            data.Date = $rootScope.setDateformat(data.Date);
            $scope.lstAchievelist.push(data);
        }).error(function (data) {
            toastr.error("error in add achievement. try again.");
        })
    }

    //edit Achievement
    $scope.editAchievement = function (obj) {
        $scope["isEditAchievement_" + obj.AchievementID] = true;
        $scope.userAchievementModel = obj;
        $scope.isEditAchievement = true;
        $rootScope.reloadDatePicker();
        $scope.copylstAchievelist = angular.copy($scope.lstAchievelist);
    }

    //cancel Achievement
    $scope.cancelAchievement = function (id) {
        $scope["isEditAchievement_" + id] = false;
        $scope.initModel();
        $scope.lstAchievelist = $scope.copylstAchievelist;
    }

    //update user Achievement set
    $scope.updateAchievement = function (obj) {
        if (obj.Name == undefined || obj.Name.length == 0) {
            toastr.info('Enter Achievement Name.!');
            return;
        }
        $http.put($rootScope.API_PATH + "/Achievements/PutAchievement/" + obj.AchievementID, obj).success(function (data) {
            toastr.success("award information update successfully");
            $scope["isEditAchievement_" + obj.AchievementID] = false;
            $scope.initModel();
        }).error(function (data) {
            toastr.error("error in update achievement. try again.");
        })
    }

    //delete user Achievement
    $scope.deleteAchievement = function (id) {
        var params = {
            id: id
        }
        $http.delete($rootScope.API_PATH + "/Achievements/DeleteAchievement", { params: params }).success(function (data) {
            toastr.success("award deleted successfully");
            $scope.lstAchievelist = $.grep($scope.lstAchievelist, function (list, index) {
                return list.AchievementID != data.AchievementID
            });
        }).error(function (data) {
            toastr.error("error in delete achievement. try again");
        })
    }

    //=======================================   user Education  ========================================//
    //add user Education
    $scope.addEducation = function (obj) {
        obj.UserID = $scope.userId;
        obj.EducationID = 0;
        $http.post($rootScope.API_PATH + "/Educations/PostEducation", obj).success(function (data) {
            toastr.success("education added successfully");
            $scope.initModel();
            $scope.isAddEducationList = false;

            data.StartDate = $rootScope.setDateformat(data.StartDate);
            data.EndDate = $rootScope.setDateformat(data.EndDate);
            $scope.Educationlists.push(data);
        }).error(function (data) {
            toastr.error("error in add education. try again");
        })
    }

    //edit Education
    $scope.editEducation = function (obj) {
        $scope.userEducationModel = obj;
        $scope["isEditEducation_" + obj.EducationID] = true;
        $rootScope.reloadDatePicker();
        $scope.copyEducationlists = angular.copy($scope.Educationlists);
    }

    //cancle update education list
    $scope.cancelUpdateEducationList = function (id) {
        $scope["isEditEducation_" + id] = false;
        $scope.initModel();
        $scope.Educationlists = $scope.copyEducationlists;
    }

    //update user Education set
    $scope.updateEducation = function (obj) {
        $http.put($rootScope.API_PATH + "/Educations/PutEducation/" + obj.EducationID, obj).success(function (data) {
            toastr.success("education detail update successfully");
            $scope.initModel();
            $scope["isEditEducation_" + obj.EducationID] = false;
        }).error(function (data) {
            toastr.error("error in update education detail. try again.")
        })
    }

    //delete user Education
    $scope.deleteEducation = function (id) {
        var params = {
            id: id
        }
        $http.delete($rootScope.API_PATH + "/Educations/DeleteEducation/", { params: params }).success(function (data) {
            toastr.success("success");
            $scope.Educationlists = $.grep($scope.Educationlists, function (list, index) {
                return list.EducationID != data.EducationID
            });
        }).error(function (data) {
            toastr.error("error in delete education detail. try again");
        })
    }

    //=======================================   user skill  ========================================//
    //add user skill
    $scope.addSkill = function (obj) {
        obj.UserID = $scope.userId;
        obj.SkillID = 0;
        $http.post($rootScope.API_PATH + "/Skills/PostSkill", obj).success(function (data) {
            toastr.success("skill added successfully");
            $scope.initModel();
            $scope.isAddSkill = false;
            $scope.lstSkillList.push(data);
        }).error(function (data) {
            toastr.error("error in add skill. try again");
        })
    }

    //delete skill
    $scope.deleteSkill = function (id) {
        var params = {
            id: id
        }
        $http.delete($rootScope.API_PATH + "/Skills/DeleteSkill", { params: params }).success(function (data) {
            toastr.success("skill deleted successfully");
            $scope.lstSkillList = $.grep($scope.lstSkillList, function (list, index) {
                return list.SkillID != data.SkillID
            });
        }).error(function (data) {
            toastr.error("error in delete skill. try again");
        })
    }

    //=======================================   user LANGUAGE  ========================================//
    //add user LANGUAGE
    $scope.addLanguage = function (obj) {
        obj.UserID = $scope.userId;
        obj.LanguageID = 0;
        $http.post($rootScope.API_PATH + "/Languages/PostLanguage", obj).success(function (data) {
            toastr.success("add langauge successfully");
            $scope.initModel();
            $scope.lstLanguageList.push(data);
            $scope.isAddLanguage = false;
        }).error(function (data) {
            toastr.error("error in add langauge. try again");
        })
    }

    //delete language
    $scope.deleteLanguage = function (id) {
        $http.delete($rootScope.API_PATH + "/Languages/DeleteLanguage/" + id).success(function (data) {
            toastr.success("language delete successfully");
            $scope.lstLanguageList = $.grep($scope.lstLanguageList, function (list, index) {
                return list.LanguageID != data.LanguageID
            });
        }).error(function (data) {
            toastr.error("error in delete langauge. try again");
        })
    }
    //=======================================   end user LANGUAGE  ========================================//

    //add new are you
    $scope.changeAreYouA = function () {
        if ($scope.areYoua == 'other')
            $scope.isOtherAreYou = true;
        else
            $scope.isOtherAreYou = false;
    }

    //close new areYoua
    $scope.closeAddNewAreYou = function () {
        $scope.isOtherAreYou = false;
        $scope.areYoua = '';
    }

    //add new education
    $scope.changeEducation = function () {
        if ($scope.education == 'other')
            $scope.isOtherEducation = true;
        else
            $scope.isOtherEducation = false;
    }

    //close new education
    $scope.closeAddNewEducation = function () {
        $scope.isOtherEducation = false;
        $scope.education = '';
    }

    //add new refrence
    $scope.changeRefrence = function () {
        if ($scope.refrence == 'other')
            $scope.isOtherRefrence = true;
        else
            $scope.isOtherRefrence = false;
    }

    //close new refrence
    $scope.closeAddNewRefrence = function () {
        $scope.isOtherRefrence = false;
        $scope.refrence = '';
    }
    $scope.init();



});