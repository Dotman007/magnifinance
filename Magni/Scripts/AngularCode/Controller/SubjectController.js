var app = angular.module("SubjectApp", ['angularUtils.directives.dirPagination', 'ngAnimate', 'toaster'])
    
app.controller("SubjectController", function ($scope, $http, toaster, $window) {

    $scope.subject = {};
    $scope.updateSubject = {};
    $scope.subject.Name = $scope.Name;
    $scope.subject.Unit = $scope.Unit;
    $scope.subject.teacherId = $scope.teacherId;
    $scope.subject.courseId = $scope.courseId;
    $scope.subjectDetails = {};
    $scope.subjectDetails.Name =  ""
    $scope.subjectDetails.Unit =  0
    $scope.subjectDetails.TeacherName =  0
    $scope.subjectDetails.CourseName =  0
    $scope.courses = [];
    $scope.record = [];
    $scope.teachers = [];

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

    // Add Subject
    $scope.AddSubject = function () {
        $http({
            method: 'POST',
            url: '/Subject/CreateSubject',
            data: $scope.subject
        }).then(function (response) {
            console.log($scope.teacherId + " " + $scope.courseId + $scope.Name);
            $scope.subject = null;
            $scope.AllSubjects();
            $scope.success();
        }).catch(function (error) {

            $scope.error(error);

        });

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


    $scope.AllTeachers = function () {
        $http.get("/Teacher/AllTeachers").then(function (response) {
            $scope.teachers = response.data;
        }, function (error) {
            $scope.error(error);
        });
    }

    $scope.GetSubjectById = function (id) {

        $http.get("/Subject/GetSubjectById?Id=" + id).then(function (response) {
            $scope.subjectDetails.Name = response.data.Name;
            $scope.subjectDetails.Unit = response.data.Unit;
            $scope.subjectDetails.TeacherName = response.data.TeacherId;
            $scope.subjectDetails.CourseName = response.data.CourseId;
            $scope.subjectDetails.Id = response.data.SubjectId;
            console.log($scope.subjectDetails);
        }, function (error) {
            $scope.error();
        });
    }


    $scope.DeleteSubject = function (id) {
        $http.get("/Subject/DeleteSubject?Id=" + id).then(function (data) {
            $scope.subjectDetails = data;
            console.log($scope.subjectDetails);
            $scope.AllSubjects();
            $scope.delete();
        }, function (error) {
            $scope.error();
        
        });
    }

    $scope.UpdateSubject = function (id, unit, teacher, name, courseId) {
        $scope.updateSubject.SubjectId = id;
        $scope.updateSubject.Unit = unit;
        $scope.updateSubject.TeacherId = teacher;
        $scope.updateSubject.CourseId = courseId;
        
        $http({
            method: 'POST',
            url: '/Subject/UpdateSubject',
            data: $scope.updateSubject
        }).then(function (data) {
            var resp = JSON.stringify(data);
            $scope.updateSubject = null;
            $scope.AllSubjects();
            $scope.update();
        }).catch(function (error) {
            alert(error);
        });
    }


    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }
});