var app = angular.module("CourseApp", [])
    
app.controller("CourseController", function ($scope, $http) {

    $scope.btnSave = "Save";
    $scope.course = {};
    $scope.course.Name = $scope.Name;
    $scope.course.NumberOfTeachers = $scope.NumberOfTeachers;
    $scope.course.CourseCode = $scope.CourseCode;

    $scope.record = [];
    // Add Course
    console.log("CourseName: " + $scope.course.Name);
    $scope.AddCourse = function () {

        $scope.btnSave = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Courses/AddCourse',

            data: $scope.course

        }).then(function (response){

            $scope.btnSave = "Save";

            $scope.course = null;
            //$scope.pop();
            $scope.Alert();

           
        }).error(function () {

            alert('Failed');

        });

    };

    $scope.Alert = function () {
        alert("Sucess");
    }

    //$scope.pop = function () {
    //    toaster.pop('Course Registration', "Course Registration", "Course Added Successfully!!");
    //};
    


    $scope.CourseList = function () {
        $http.get("/Courses/Courses").then(function (response) {

            $scope.record = response.data;
            console.log($scope.record);

        }, function (error) {

            alert('Failed');

        });
    }


});