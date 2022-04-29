var app = angular.module("StudentApp", [])
    
app.controller("StudentController", function ($scope, $http) {

    $scope.btnSave = "Save";
    $scope.student = {};
    $scope.student.Name = $scope.Name;
    $scope.student.birthday = $scope.Birthday;
    $scope.student.courseId = $scope.CourseId;
    $scope.record = [];
    // Add Teacher
    console.log("Student: " + $scope.student);
    $scope.AddStudent = function () {

        $scope.btnSave = "Please Wait..";

        $http({
            method: 'POST',

            url: '/Students/CreateStudent',

            data: $scope.student

        }).then(function (response){

            $scope.btnSave = "Save";

            $scope.student = null;
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