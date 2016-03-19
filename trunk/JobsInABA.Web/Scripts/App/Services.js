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
});