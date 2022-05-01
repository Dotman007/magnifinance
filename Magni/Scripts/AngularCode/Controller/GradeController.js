var app = angular.module("GradeApp", [])
    
app.controller("GradeController", function ($scope, $http) {


    $scope.grade = {};
    $scope.grades = [];
    $scope.grade.Name = $scope.Name;
    $scope.grade.Score = $scope.Score;
    $scope.message = "";

    //Create Course
    $scope.CreateGrade = function () {
        $http({
            method: 'POST',
            url: '/Grade/CreateGrade',
            data: $scope.grade
        }).then(function (data) {
            var resp = JSON.stringify(data);
            alert(data.data.ResponseMessage);
        }).catch(function (error) {
            alert(error);
        });
    };


    $scope.courses = [];
    $scope.AllGrades = function () {
        $http.get("/Grade/AllGrades").then(function (response) {
            var resp = JSON.stringify(response.data);
            var obj = JSON.parse(resp);
            $scope.grades = obj;
            console.log($scope.courses);
        }, function (error) {
            alert('Failed');
        });
    }

});