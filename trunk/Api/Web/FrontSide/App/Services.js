app.service('httpService', function ($http) {
    this.getAll = function (url) {
        return $http.get(url);
    };

    this.getByID = function (id, url) {
        return $http.get(url + id);
    };

    this.post = function (data, url) {
        var request = $http({
            method: "post",
            url: url,
            data: data
        });
        return request;
    };

    this.put = function (data, url) {
        var request = $http({
            method: "put",
            url: url,
            data: data
        });
        return request;
    };

    this.delete = function (id, url) {
        var request = $http({
            method: "delete",
            url: url + id
        });
        return request;
    };

    this.get = function (data, url) {
        var request = $http({
            method: "get",
            url: url,
            data: data
        });
        return request;
    };

    this.createCookie = function (name, value, days) {
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = "; expires=" + date.toGMTString();
        }
        else var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }

    this.readCookie = function (name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') c = c.substring(1, c.length);
            if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
        }
        return null;
    }

    this.eraseCookie = function (name) {
        this.createCookie(name, "", -1);
    }
})

.directive('ngEnter', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                scope.$apply(function () {
                    scope.$eval(attrs.ngEnter);
                });

                event.preventDefault();
            }
        });
    };
})

.directive('ngReallyClick', ['$modal',
    function ($modal) {

        var ModalInstanceCtrl = function ($scope, $modalInstance) {
            $scope.ok = function () {
                $modalInstance.close();
            };

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
        };

        return {
            restrict: 'A',
            scope: {
                ngReallyClick: "&",
                item: "="
            },
            link: function (scope, element, attrs) {
                element.bind('click', function () {
                    var message = attrs.ngReallyMessage || "Are you sure ?";
                    //*This doesn't works
                    var modalHtml = '<div class="modal-body">' + message + '</div>';
                    modalHtml += '<div class="modal-footer"><button class="btn btn-primary" ng-click="ok()">OK</button><button class="btn btn-warning" ng-click="cancel()">Cancel</button></div>';

                    var modalInstance = $modal.open({
                        template: modalHtml,
                        controller: ModalInstanceCtrl
                    });
                    modalInstance.result.then(function () {
                        scope.ngReallyClick({ item: scope.item }); //raise an error : $digest already in progress
                    }, function () {
                        //Modal dismissed
                    });
                    //*/
                });
            }
        }
    }
])