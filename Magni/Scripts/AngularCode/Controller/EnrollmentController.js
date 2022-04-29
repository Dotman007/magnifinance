var app = angular.module("EnrollmentApp", [])
    
app.controller("EnrollmentController", function ($scope, $http) {

    $scope.btnSave = "Save";
    $scope.enrollment = {};
    $scope.enrollment.SubjectId = $scope.SubjectId;
    $scope.enrollment.StudentId = $scope.StudentId;
    $scope.record = [];
    console.log($scope.enrollment.subjectId);
    // Add Subject
    //console.log("CourseName: " + $scope.subject);
    $scope.CreateEnrollment = function () {

        $scope.btnSave = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Enrollment/CreateEnrollment',

            data: $scope.enrollment

        }).then(function (response){

            $scope.btnSave = "Save";

            $scope.enrollment = null;
            //$scope.pop();
            $scope.Alert();

           
        }).error(function () {

            alert('Failed');

        });

    };

    $scope.Alert = function () {
        alert("Success");
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