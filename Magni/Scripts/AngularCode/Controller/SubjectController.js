var app = angular.module("SubjectApp", [])
    
app.controller("SubjectController", function ($scope, $http) {

    $scope.subject = {};
    $scope.subject.Name = $scope.Name;
    $scope.subject.Unit = $scope.Unit;
    $scope.subject.teacherId = $scope.teacherId;
    $scope.subject.courseId = $scope.courseId;
    $scope.courses = [];
    $scope.record = [];
    $scope.teachers = [];
    // Add Subject
    $scope.AddSubject = function () {
        $http({
            method: 'POST',
            url: '/Subject/CreateSubject',
            data: $scope.subject
        }).then(function (response) {
            console.log($scope.teacherId + " " + $scope.courseId + $scope.Name);
            $scope.subject = null;
            $scope.Alert(response.responseMessage);
        }).catch(function (error) {

            alert(error);

        });

    };

    $scope.Alert = function (message) {
        alert("Sucess");
    }

    //$scope.pop = function () {
    //    toaster.pop('Course Registration', "Course Registration", "Course Added Successfully!!");
    //};


    $scope.AllCourses = function () {
        $http.get("/Course/AllCourses").then(function (response) {
            $scope.courses = response.data;
            console.log($scope.courses);
        }, function (error) {
            alert('Failed');
        });
    }


    $scope.AllSubjects = function () {
        $http.get("/Subject/AllSubjects").then(function (response) {

            $scope.record = response.data;
            console.log($scope.record);
        }, function (error) {
            alert('Failed');
        });
    }


    $scope.AllTeachers = function () {
        $http.get("/Teacher/AllTeachers").then(function (response) {
            $scope.teachers = response.data;
            console.log($scope.teachers);
        }, function (error) {
            alert('Failed');
        });
    }

});