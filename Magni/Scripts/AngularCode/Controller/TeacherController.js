var app = angular.module("TeacherApp", ['angularUtils.directives.dirPagination','ngAnimate', 'toaster'])
    
app.controller("TeacherController", function ($scope, $http, toaster, $window) {

    $scope.btnSave = "Save";
    $scope.teacher = {};
    $scope.teacher.Name = $scope.Name;
    $scope.teacher.salary = $scope.Salary;
    $scope.teacher.birthday = $scope.Birthday;
    $scope.teacherDetails = {};
    $scope.record = [];
    $scope.updateTeacher = {};


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
        toaster.pop('success', "Success", "Teacher Created Successfully");
        //toaster.pop('success', "title", '<ul><li>Render html</li></ul>', 5000, 'trustedHtml');
        //toaster.pop('error', "title", '<ul><li>Render html</li></ul>', null, 'trustedHtml');
        //toaster.pop('wait', "title", null, null, 'template');
        //toaster.pop('warning', "title", "myTemplate.html", null, 'template');
        //toaster.pop('note', "title", "text");
    };


    $scope.delete = function () {
        toaster.pop('success', "Success", "Teacher Deleted Successfully");
        //toaster.pop('success', "title", '<ul><li>Render html</li></ul>', 5000, 'trustedHtml');
        //toaster.pop('error', "title", '<ul><li>Render html</li></ul>', null, 'trustedHtml');
        //toaster.pop('wait', "title", null, null, 'template');
        //toaster.pop('warning', "title", "myTemplate.html", null, 'template');
        //toaster.pop('note', "title", "text");
    };

    $scope.update = function () {
        toaster.pop('success', "Success", "Teacher Updated Successfully");
        //toaster.pop('success', "title", '<ul><li>Render html</li></ul>', 5000, 'trustedHtml');
        //toaster.pop('error', "title", '<ul><li>Render html</li></ul>', null, 'trustedHtml');
        //toaster.pop('wait', "title", null, null, 'template');
        //toaster.pop('warning', "title", "myTemplate.html", null, 'template');
        //toaster.pop('note', "title", "text");
    };


    $scope.error = function (err) {
        toaster.pop('error', "Error", err);
        //toaster.pop('success', "title", '<ul><li>Render html</li></ul>', 5000, 'trustedHtml');
        //toaster.pop('error', "title", '<ul><li>Render html</li></ul>', null, 'trustedHtml');
        //toaster.pop('wait', "title", null, null, 'template');
        //toaster.pop('warning', "title", "myTemplate.html", null, 'template');
        //toaster.pop('note', "title", "text");
    };


    // Add Teacher
    console.log("CourseName: " + $scope.teacher);
    $scope.CreateTeacher = function () {

        $scope.btnSave = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Teacher/CreateTeacher',

            data: $scope.teacher

        }).then(function (response){

            $scope.teacher = null;
            $scope.AllTeachers();
            $scope.success();
        }).catch(function (error) {

            $scope.error(error);

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
            $scope.AllTeachers();
            console.log($scope.record);

        }, function (error) {

            $scope.error(error);

        });
    }

    $scope.UpdateTeacher = function (id, dob, salary) {
        $scope.updateTeacher.TeacherId = id;
        $scope.updateTeacher.Birthday = dob;
        $scope.updateTeacher.Salary = salary;
        $http({
            method: 'POST',
            url: '/Teacher/UpdateTeacher',
            data: $scope.updateTeacher
        }).then(function (data) {
            var resp = JSON.stringify(data);
            //alert(data.data.ResponseMessage);
            $scope.updateTeacher.TeacherId = null;
            $scope.updateTeacher.Birthday = null;
            $scope.updateTeacher.Salary = null;
            $scope.AllTeachers();
            $scope.update()
        }).catch(function (error) {
            $scope.error(error);
        });
    }

    $scope.GetGradeById = function (id) {

        $http.get("/Teacher/GetTeacherById?Id=" + id).then(function (response) {
            $scope.teacherDetails = response.data;
            $scope.teacherDetails.Name = data.Name;
            $scope.teacherDetails.Birthday = data.Birthday;
            $scope.teacherDetails.Salary = data.Salary;
            console.log($scope.teacherDetails);
        }, function (error) {
            $scope.error(error);
        });
    }

    $scope.DeleteTeacher = function (id) {
        $http.get("/Teacher/DeleteTeacher?Id=" + id).then(function (response) {
            $scope.AllTeachers();
            $scope.delete();
        }, function (error) {
            $scope.error(error)
        });
    }


    $scope.AllTeachers = function () {
        $http.get("/Teacher/AllTeachers").then(function (response) {

            var resp = JSON.stringify(response.data);
            var obj = JSON.parse(resp);
            $scope.record = obj
            console.log($scope.record);
        }, function (error) {
            $scope.error(error);
        });
    }

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

});