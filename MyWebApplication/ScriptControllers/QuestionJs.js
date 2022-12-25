myApp.controller("QuestionJs", function ($scope, $http) {
    console.log("Nhấn link question, bật F12 show log");

    $scope.listData = [];
    $scope.listQuestion = [];

    var getListTest = function () {
        return $http({
            url: "/Question/GetListTest",
            method: "GET",
        });
    }

    var getListQuestion = function () {
        return $http({
            url: "/Question/GetList",
            method: "GET",
        });
    }

    var init = function () {
        getListTest().then(function successCallback (response) {
            console.log(response);
            if (response.status == 200) {
                $scope.listData = response.data;
                console.log($scope.listData);
            }
        }, function errorCallback(error) {
            console.log(error);
        });

        getListQuestion().then(function successCallback(response) {
            console.log(response);
            $scope.listQuestion = response.data;
        }, function errorCallback(error) {
            console.log(error);
        });
    }

    init();
});