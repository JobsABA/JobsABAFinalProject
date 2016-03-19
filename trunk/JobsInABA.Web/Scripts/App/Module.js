var app = angular.module("myApp", ["ngRoute", "angular-loading-bar"]);

app.config(['$routeProvider', '$locationProvider', 'cfpLoadingBarProvider', function ($routeProvider, $locationProvider, cfpLoadingBarProvider,$rootScope) {
    cfpLoadingBarProvider.includeSpinner = true;
    //$rootScope.isAdminLogin = false;
    $routeProvider.when('/home',
                        {
                            templateUrl: '/App/Home',
                            controller: 'HomeController'
                        });
    $routeProvider.when('/register',
                        {
                            templateUrl: '/App/Register',
                            controller: 'RegisterController'
                        });
    $routeProvider.when('/login',
                        {
                            templateUrl: '/App/SignIn',
                            controller: 'SignInController'
                        });
    $routeProvider.when('/personprofile',
                        {
                            templateUrl: '/App/PersonProfile',
                            controller: 'PersonProfileController'
                        });
    $routeProvider.when('/companyprofile',
                        {
                            templateUrl: '/App/CompanyProfile',
                            controller: 'CompanyProfileController'
                        });
    $routeProvider.when('/viewcompanyprofile',
                        {
                            templateUrl: '/App/ViewCompanyProfile',
                            controller: 'PersonProfileController'
                        });
    $routeProvider.when('/publishjob',
                        {
                            templateUrl: '/App/PublishedJob',
                            controller: 'JobsController'
                        });
    $routeProvider.when('/createjob',
                        {
                            templateUrl: '/App/CreateJob',
                            controller: 'JobsController'
                        });
    $routeProvider.when('/updateJob/:jobId',
                        {
                            templateUrl: '/App/CreateJob',
                            controller: 'JobsController'
                        });
    $routeProvider.when('/jobDetail',
                        {
                            templateUrl: '/App/JobDetail',
                            controller: 'JobsController'
                        });
    $routeProvider.when('/adPackage',
                        {
                            templateUrl: '/App/AdPackageList',
                            controller: 'AdpackageController'
                        });
    $routeProvider.when('/orderList',
                        {
                            templateUrl: '/App/OrderList',
                            controller: 'OrderListController'
                        });
    $routeProvider.when('/abaServiceProvide',
                        {
                            templateUrl: '/App/ABAServiceProvide',
                            controller: 'ABAServiceProviderController'
                        });
    $routeProvider.when('/jobsInAba',
                        {
                            templateUrl: '/App/JobsInABAList',
                            controller: 'JobsInABAListController'
                        });
    $routeProvider.otherwise(
                        {
                            redirectTo: '/updateJob/1'
                        });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}]);