var app = angular.module("SubjectApp", [])
    
app.controller("SubjectController", function ($scope, $http) {

    $scope.btnSave = "Save";
    $scope.subject = {};
    $scope.subject.Name = $scope.Name;
    $scope.subject.code = $scope.Code;
    $scope.subject.title = $scope.Title;
    $scope.subject.unit = $scope.Unit;
    $scope.subject.courseId = $scope.CourseId;
    $scope.subject.teacherId = $scope.TeacherId;
    $scope.record = [];
    // Add Subject
    //console.log("CourseName: " + $scope.subject);
    $scope.AddSubject = function () {

        $scope.btnSave = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Subjects/CreateSubject',

            data: $scope.subject

        }).then(function (response){

            $scope.btnSave = "Save";

            $scope.subject = null;
            //$scope.pop();
            $scope.Alert(response.responseMessage);

           
        }).error(function () {

            alert('Failed');

        });

    };

    $scope.Alert = function (message) {
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