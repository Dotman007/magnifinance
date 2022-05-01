var app = angular.module("StudentApp", [])
    
app.controller("StudentController", function ($scope, $http) {

    $scope.btnSave = "Save";
    $scope.student = {};
    $scope.student.Name = $scope.Name;
    $scope.student.birthday = $scope.Birthday;
    $scope.student.courseId = $scope.CourseId;
    $scope.record = [];
    $scope.students = [];
    // Add Teacher
    console.log("Student: " + $scope.student);
    $scope.AddStudent = function () {

        $scope.btnSave = "Please Wait..";

        $http({
            method: 'POST',

            url: '/Student/CreateStudent',

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
    


    $scope.AllCourses = function () {
        $http.get("/Course/AllCourses").then(function (response) {
            var resp = JSON.stringify(response.data);
            var obj = JSON.parse(resp);
            $scope.record = obj;
            console.log($scope.record);

        }, function (error) {

            alert('Failed');

        });
    }


    $scope.AllStudents = function () {
        $http.get("/Student/AllStudents").then(function (response) {
            var resp = JSON.stringify(response.data);
            var obj = JSON.parse(resp);
            $scope.students = obj;
            console.log($scope.students);

        }, function (error) {

            alert('Failed');

        });
    }


});