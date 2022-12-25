myApp.controller("QuestionJs", function ($scope, $http) {
    console.log("Nhấn link question, bật F12 show log");

    $scope.listData = [];
    $scope.listQuestion = [];
    $scope.cauHoi = "";
    $scope.noiDung = "";

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

    $scope.add = function () {
        if ($scope.cauHoi == "" || $scope.cauHoi == null) {
            alert("Chưa nhập nội dung câu hỏi");
        }
        else {
            var data = { Id: 0, Name: $scope.cauHoi };
            $http({
                method: "post",
                url: "/Question/Create",
                datatype: "json",
                data: JSON.stringify(data),
            }).then(function (response) {
                console.log(response);
                $scope.cauHoi = "";
                init();
            });
        }
    }
    $scope.delete = function (data) {
        var dataDelete = data;
        $http({
            method: "post",
            url: "/Question/Delete",
            datatype: "json",
            data: JSON.stringify(dataDelete),
        }).then(function (response) {
            console.log(response);
            init();
        });
    }
    $scope.update = function (idCauHoi) {
        var data = { Id: idCauHoi, Name: $scope.noiDung };
        $http({
            method: "post",
            url: "/Question/Update",
            datatype: "json",
            data: JSON.stringify(data),
        }).then(function (response) {
            console.log(response);
            $scope.noiDung = "";
            init();
        });
    }
});