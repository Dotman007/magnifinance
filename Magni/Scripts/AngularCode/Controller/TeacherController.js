var app = angular.module("TeacherApp", [])
    
app.controller("TeacherController", function ($scope, $http) {

    $scope.btnSave = "Save";
    $scope.teacher = {};
    $scope.teacher.Name = $scope.Name;
    $scope.teacher.salary = $scope.Salary;
    $scope.teacher.birthday = $scope.Birthday;
    $scope.record = [];
    // Add Teacher
    console.log("CourseName: " + $scope.teacher);
    $scope.CreateTeacher = function () {

        $scope.btnSave = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Teacher/CreateTeacher',

            data: $scope.teacher

        }).then(function (response){

            $scope.btnSave = "Save";

            $scope.course = null;
            //$scope.pop();
            $scope.Alert();

           
        }).catch(function (error) {

            alert(error);

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



    $scope.AllTeachers = function () {
        $http.get("/Teacher/AllTeachers").then(function (response) {

            var resp = JSON.stringify(response.data);
            var obj = JSON.parse(resp);
            $scope.record = obj
            console.log($scope.record);

        }, function (error) {

            alert('Failed');

        });
    }


});