﻿var app = angular.module("myApp", ["ngRoute", "angular-loading-bar", "lazy-scroll", "ui.bootstrap"]);

app.config(['$routeProvider', '$locationProvider', 'cfpLoadingBarProvider', function ($routeProvider, $locationProvider, cfpLoadingBarProvider, $rootScope) {
    cfpLoadingBarProvider.includeSpinner = true;
    //$rootScope.isAdminLogin = false;

    $routeProvider
       .when('/home', {
           templateUrl: 'Template/Home.html',
           controller: 'HomeController'
       })
    .when('/register', {
        templateUrl: 'Template/Register.html',
        controller: 'RegisterController'
    })
    .when('/login', {
        templateUrl: 'Template/SignIn.html',
        controller: 'SignInController'
    })
        .when('/login/:isVerify', {
            templateUrl: 'Template/SignInAfterVerify.html',
            controller: 'SignInController'
        })
    .when('/personprofile', {
        templateUrl: 'Template/PersonProfile.html',
        controller: 'PersonProfileController'
    })
        .when('/personprofile/:UserID', {
            templateUrl: 'Template/PersonProfile.html',
            controller: 'PersonProfileController'
        })
    .when('/companyprofile', {
        templateUrl: 'Template/CompanyProfile.html',
        controller: 'CompanyProfileController'
    })
    .when('/editCompanyProfile/:BusinessId', {
        templateUrl: 'Template/CompanyProfile.html',
        controller: 'CompanyProfileController'
    })
    .when('/viewcompanyprofile/:BusinessId', {
        templateUrl: 'Template/ViewCompanyProfile.html',
        controller: 'BusinessDetailController'
    })
    //.when('/publishjob', {
    //    templateUrl: 'Template/PublishedJob.html',
    //    controller: 'JobsController'
    //})
    .when('/createjob/:BusinessID', {
        templateUrl: 'Template/CreateJob.html',
        controller: 'JobsController'
    })
    .when('/updateJob/:JobID/:BusinessID', {
        templateUrl: 'Template/CreateJob.html',
        controller: 'JobsController'
    })
    .when('/jobDetail/:JobID', {
        templateUrl: 'Template/JobDetail.html',
        controller: 'JobsController'
    })
    .when('/adPackage', {
        templateUrl: 'Template/AdPackageList.html',
        controller: 'AdpackageController'
    })
    .when('/orderList', {
        templateUrl: 'Template/OrderList.html',
        controller: 'OrderListController'
    })
    .when('/abaServiceProvide', {
        templateUrl: 'Template/ABAServiceProvide.html',
        controller: 'ABAServiceProviderController'
    })
    .when('/jobsInAba', {
        templateUrl: 'Template/JobsInABAList.html',
        controller: 'JobsInABAListController'
    })
        .when('/blog', {
            templateUrl: 'Template/BlogList.html',
            controller: 'BlogListController'
        })
         .when('/blogDetail', {
             templateUrl: 'Template/BlogDetail.html',
             controller: 'BlogListController'
         })
         .when('/changePassword', {
             templateUrl: 'Template/ChangePassword.html',
             controller: 'ChangePasswordController'
         })
        .when('/privacyPolicy', {
            templateUrl: 'Template/PrivacyPolicy.html',
            controller: 'FooterMenuController'
        })
        .when('/termsCondition', {
            templateUrl: 'Template/TermsCondition.html',
            controller: 'FooterMenuController'
        })
        .when('/contactUs', {
            templateUrl: 'Template/ContactUs.html',
            controller: 'ContactUsController'
        })
        .when('/verify', {
            templateUrl: 'Template/VerifyRegisterPage.html',
            controller: 'VerifyRegistrationController'
        })
        .when('/resetPassword/:UserID', {
            templateUrl: 'Template/CreatePassword.html',
            controller: 'CreatePasswordController'
        })
            .when('/subscription', {
                templateUrl: 'Template/SubScription.html',
                controller: 'SubScriptionController'
            })
        .when('/payment/:OrderID', {
            templateUrl: 'Template/Payment.html',
            controller: 'PaymentController'
        })
         .when('/paymentReceipt', {
             templateUrl: 'Template/PaymentReceipt.html',
             controller: 'PaymentReceiptController'
         })
        .when('/aboutus', {
            templateUrl: 'Template/AboutUs.html',
            controller: 'AboutusController'
        })
        .when('/events', {
            templateUrl: 'Template/Events.html',
            controller: 'EventsController'
        })
    .otherwise({
        redirectTo: '/home'
    });

}])

.run(function ($rootScope, $location, httpService, $q, $routeParams) {

    $rootScope.API_PATH = 'http://localhost:64872/api/';
    $rootScope.API_PATH_Image = 'http://localhost:64872/';

    //$rootScope.API_PATH = 'https://test.jobsinaba.com/api/';
    //$rootScope.API_PATH_Image = 'https://test.jobsinaba.com/';

    $rootScope.$on("$routeChangeStart", function (event, next, current) {
        if (current && current.$$route) {
            $rootScope.previousPath = current.$$route.originalPath;
            $rootScope.previousPathParam = current.params.BusinessId;
        }

        /* this line not working */
        var canceler = $q.defer();
        canceler.resolve();

    });
    $rootScope.$on("$routeChangeSuccess", function (event, currentRoute, previousRoute) {
        window.scrollTo(0, 0);

    });

    $rootScope.$watch(function () {
        return $location.path();
        $rootScope.IsPersonalProfile = false;
        $rootScope.IsBussinessDetail = false;
    }, function (a) {
        if (httpService.readCookie("uid") != null && httpService.readCookie("uid") != "") {
            $rootScope.UserLogin = true;
        }
        else {
            $rootScope.UserLogin = false;

        }

        //console.log('url has changed: ' + a);
        // show loading div, etc...
    });
});
;

