var app = angular.module("CourseApp", [])
    
app.controller("CourseController", function ($scope, $http) {


    $scope.course = {};
    $scope.course.Name = $scope.Name;
    $scope.message = "";

    //Create Course
    $scope.CreateCourse = function () {
        $http({
            method: 'POST',
            url: '/Course/CreateCourse',
            data: $scope.course
        }).then(function (data) {
            var resp = JSON.stringify(data);
            alert(data.data.ResponseMessage);
        }).catch(function (error) {
            alert(error);
        });
    };


    $scope.courses = [];
    $scope.AllCourses = function () {
        $http.get("/Course/AllCourses").then(function (response) {
            $scope.courses = response.data;
            console.log($scope.courses);
        }, function (error) {
            alert('Failed');
        });
    }

});