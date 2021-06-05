var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope, $http, $window) {
    $http.get("https://localhost:44378/api/country")
        .then(function (response) {
            $scope.myData = response.data;
        });
    // initializare datelor pentru request
    $scope.countr = "";
    $scope.year = 0;


    //functia de adaugat state in lista
    $scope.empty = false;
    $scope.addcountry = function () {
        $scope.url = "https://localhost:44378/api/country";
        $window.location.href = $scope.url;
    }

    // functia de trecere de la tara la an
    $scope.primul = true;
    $scope.second = false;
    $scope.goToYear = function (countr) {
        $scope.primul = !$scope.primul;
        $scope.second = !$scope.second;
        $scope.countr = countr;
    }
    //Lista cu sarbatori
    // functia pentru citirea anului introdus  si a face request catre BD
    $scope.request = function (year) {
        $scope.year = year;
        $scope.url = "https://localhost:44378/api/holiday/Year=" + $scope.year + "&Country=" + $scope.countr;
        $window.location.href = $scope.url;
    }//

  //Calcularea numarului de zile libere din an la un anumit stat
// functia pentru facere request

    $scope.requestCount = function (year) {
        $scope.year = year;
        $scope.url = "https://localhost:44378/api/holiday/action=freeDaysYear&Year=" + $scope.year + "&Country=" + $scope.countr;
        $window.location.href = $scope.url;
    }

    // Request pentru a afla ce tip de zi este introdusa
    $scope.requestTypeDay = function (year, month, day) {
        $scope.year = year;
        $scope.day = day;
        $scope.month = month;      
        $scope.url = "https://localhost:44378/api/holiday/action=isfreeday&Day=" + $scope.day + "&Month=" + $scope.month +
            "&Year=" + $scope.year + "&Country=" + $scope.countr;
        $window.location.href = $scope.url;
    }

  
});
