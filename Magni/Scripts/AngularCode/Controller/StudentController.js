var app = angular.module("StudentApp", ['angularUtils.directives.dirPagination', 'ngAnimate', 'toaster'])
    
app.controller("StudentController", function ($scope, $http, toaster, $window) {
    var courseId = 0;
    $scope.btnSave = "Save";
    $scope.student = {};
    $scope.course = {};
    $scope.studentDetail = {};
    $scope.student.Name = $scope.Name;
    $scope.student.Birthday = new Date($scope.Birthday);
    $scope.student.CourseId = $scope.CourseId;
    $scope.record = [];
    $scope.students = [];
    $scope.updateStudent = {};

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
        toaster.pop('success', "Success", "Student Created Successfully");
        //toaster.pop('success', "title", '<ul><li>Render html</li></ul>', 5000, 'trustedHtml');
        //toaster.pop('error', "title", '<ul><li>Render html</li></ul>', null, 'trustedHtml');
        //toaster.pop('wait', "title", null, null, 'template');
        //toaster.pop('warning', "title", "myTemplate.html", null, 'template');
        //toaster.pop('note', "title", "text");
    };


    $scope.delete = function () {
        toaster.pop('success', "Success", "Student Deleted Successfully");
        //toaster.pop('success', "title", '<ul><li>Render html</li></ul>', 5000, 'trustedHtml');
        //toaster.pop('error', "title", '<ul><li>Render html</li></ul>', null, 'trustedHtml');
        //toaster.pop('wait', "title", null, null, 'template');
        //toaster.pop('warning', "title", "myTemplate.html", null, 'template');
        //toaster.pop('note', "title", "text");
    };

    $scope.update = function () {
        toaster.pop('success', "Success", "Student Updated Successfully");
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
    console.log("Student: " + $scope.student);
    $scope.AddStudent = function () {
        $scope.student.CourseId = $scope.course;

        $http({
            method: 'POST',

            url: '/Student/CreateStudent',
            data: $scope.student
        }).then(function (response){
            $scope.student = null;
            $scope.AllStudents();
            $scope.success();
        }).catch(function (error) {
            $scope.error(error)
        });

    };




    $scope.UpdateStudent = function (studentId, dob, courseId) {
        $scope.updateStudent.StudentId = studentId;
        $scope.updateStudent.Birthday = new Date(dob);
        $scope.updateStudent.CourseId = courseId;
        console.log($scope.updateStudent);
        $http({
            method: 'POST',
            url: '/Student/UpdateStudent',
            data: $scope.updateStudent
        }).then(function (data) {
            var resp = JSON.stringify(data);
            $scope.updateStudent.StudentId = null;
            $scope.updateStudent.Birthday = null;
            $scope.updateStudent.CourseId = null;
            $scope.AllStudents();
            $scope.success();
        }).catch(function (error) {
            $scope.error(error);
        });
    }



    $scope.GetStudentById = function (id) {
        $http.get("/Student/GetStudentById?Id=" + id).then(function (response) {
            $scope.studentDetail.CourseId = response.data.CourseId;
            $scope.studentDetail.Name = response.data.Name;
            $scope.studentDetail.Birthday = new Date(response.data.Birthday);
            $scope.studentDetail.RegistrationNumber = response.data.RegistrationNumber;
            $scope.studentDetail.StudentId = response.data.StudentId;
            console.log($scope.studentDetail);
        }, function (error) {
            $scope.error(error);
        });
    }

    $scope.AllStudents = function () {
        $http.get("/Student/AllStudents").then(function (response) {
            var resp = JSON.stringify(response.data);
            var obj = JSON.parse(resp);
            $scope.students = obj;
            //$scope.student.Birthday = $scope.student.Birthday;
            console.log($scope.students);

        }, function (error) {

            $scope.error(error);

        });
    }

    $scope.GetCourseId = function (cour) {
        courseId = $scope.courseId;
        var studentName = $.grep($scope.record, function (cour) {
            return cour.CourseId == courseId;
        })[0].Name;
        $scope.course.CourseId = courseId;
    }



    $scope.DeleteStudent = function (id) {
        $http.get("/Student/DeleteStudent?Id=" + id).then(function (response) {
            $scope.AllStudents();
            $scope.delete();
        }, function (error) {
            $scope.error(error);
        });
    }


    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }


    $scope.AllCourses = function () {
        $http.get("/Course/AllCourses").then(function (response) {
            $scope.record = response.data;
        }, function (error) {
            $scope.error(error);
        });
    }

});