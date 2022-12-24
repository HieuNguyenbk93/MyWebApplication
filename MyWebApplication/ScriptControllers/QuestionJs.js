myApp.controller("QuestionJs", function ($scope, $http) {
    console.log("Nhấn link question, bật F12 show log");

    $scope.listData = [];

    var getListTest = function () {
        return $http({
            url: "/Question/GetListTest",
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
    }

    init();
});