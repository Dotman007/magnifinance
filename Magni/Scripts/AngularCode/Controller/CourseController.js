var app = angular.module("CourseApp", ['angularUtils.directives.dirPagination', 'ngAnimate', 'toaster'])

app.controller("CourseController", function ($scope, $http, toaster, $window) {


    $scope.course = {};
    $scope.record = [];
    $scope.updateCourse = {};
    $scope.courseDetails = {};
    $scope.course.Name = $scope.Name;
    $scope.courseDetails.CourseId = $scope.CourseId;
    $scope.courseDetails.Name = "";
    $scope.message = "";
    $scope.courses = [];
    $scope.updateCourse.Name = "";
    $scope.updateCourse.CourseId = 0;
    $scope.showModal = false;
    $scope.showDiv = false;

    $scope.ShowHide = function () {
        $scope.showModal = true;
        $scope.showDiv = true;
        return;
    }

    $scope.Hide = function () {
        $scope.showModal = false;
        $scope.showDiv = false;
    }


    
    
    $scope.success = function () {
        toaster.pop('success', "Success", "Course Created Successfully");
        
    };


    $scope.delete = function () {
        toaster.pop('success', "Success", "Course Deleted Successfully");
        
    };

    $scope.update = function () {
        toaster.pop('success', "Success", "Course Updated Successfully");
        
    };


    $scope.error = function (err) {
        toaster.pop('error', "Error", err);
    };

    $scope.AllCourses = function () {
        $http.get("/Course/AllCourses").then(function (response) {
            $scope.courses = response.data;
            console.log($scope.courses);
        }, function (error) {
            $scope.error(error);
        });
    }



    $scope.AllSubjects = function () {
        $http.get("/Subject/AllSubjects").then(function (response) {
            $scope.record = response.data;
        }, function (error) {
            $scope.error(error);
        });
    }



    $scope.GetCourseId = function (id) {

        $http.get("/Course/GetCourseId?Id=" + id).then(function (response) {
            $scope.courseDetails = response.data;
            $scope.courseDetails.Name = $scope.courseDetails.Name;
            console.log($scope.courseDetails);
        }, function (error) {
            $scope.error(error);
        });
    }

    

    $scope.UpdateCourse = function (id,name) {
        $scope.updateCourse.Name = name;
        $scope.updateCourse.CourseId = id;
        $http({
            method: 'POST',
            url: '/Course/UpdateCourse',
            data: $scope.updateCourse
        }).then(function (data) {
            var resp = JSON.stringify(data);
            $scope.course.Name = "";
            $scope.AllCourses();
            $scope.update();
        }).catch(function (error) {
            alert(error);
        });
    }

   
    //Create Course
    $scope.CreateCourse = function () {
        $http({
            method: 'POST',
            url: '/Course/CreateCourse',
            data: $scope.course
        }).then(function (data) {
            var resp = JSON.stringify(data);
            //alert(data.data.ResponseMessage);
            $scope.course.Name = "";
            $scope.AllCourses();
            $scope.success();
        }).catch(function (error) {
            $scope.error(error);
        });
    };


    

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

});