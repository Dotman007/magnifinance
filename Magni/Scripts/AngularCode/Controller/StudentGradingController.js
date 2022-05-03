var app = angular.module("StudentGradingApp", ['angularUtils.directives.dirPagination', 'ngAnimate', 'toaster'])
    
app.controller("StudentGradingController", function ($scope, $http, toaster, $window) {

    //public int StudentId { get; set; }
    //    public int GradeId { get; set; }
    //    public int CourseId { get; set; }
    //    public int SubjectId { get; set; }
    var studentId = 0;
    var gradeId = 0;
    var subjectId = 0;
    $scope.studentz = [];
    $scope.startSpin = true;
    $scope.courseList = [];
    $scope.unitList = [];
    $scope.gradeList = [];
    $scope.student = {};
    $scope.studentModel = {};
    $scope.subject = {};
    $scope.grade = {};
    $scope.btnSave = "Save";
    $scope.courseName = "";
    $scope.subjectName = "";
    $scope.selectedValue = "";
    $scope.filteredList  = [];
    $scope.currentPage = 1;
    $scope.numPerPage = 10;
    $scope.subjects = [];
    $scope.maxSize = 5;
    $scope.unit = "";
    $scope.courseId = "";
    $scope.studentGrading = {};
    $scope.grade = {};
    $scope.totalCourses = "0";
    $scope.overallGPA = "5.0";
    $scope.totalCredit = "0";
    $scope.calculatedGPA = "";
    $scope.IsVisible = false;
    $scope.courseGrades = [];
    $scope.editable = false;
    $scope.studentGradingList = [];
    $scope.studentGradings = [];
    $scope.studentGradingLists = [];
    $scope.grades = [];
    $scope.studentGradeAverage = [];
    
    $scope.grade.Name = $scope.Name;
    $scope.studentGrading.StudentId = $scope.StudentId;
    $scope.courseList = [];
   
    $scope.record = [];
    $scope.result = {};
    $scope.courses = [];
    

    $scope.error = function (err) {
        toaster.pop('error', "Error", err);
    };
    

    $scope.AddStudentGrading = function () {
        $scope.studentModel.StudentId = $scope.student;
        $scope.studentModel.GradeId = $scope.grade;
        $scope.studentModel.SubjectId = $scope.subject;
        $http({
            method: 'POST',
            url: '/StudentGrading/CreateStudentGrading',
            data: $scope.studentModel
        }).then(function (response) {
            $scope.studentModel = null;
            $scope.GetStudentGradingList();
            $scope.success();
            $window.location.reload();
        }).catch(function (error) {
            $scope.error(error)
        });

    };

    $scope.AllStudents = function () {
        $http.get("/Student/AllStudents").then(function (response) {
            var resp = JSON.stringify(response.data);
            var obj = JSON.parse(resp);
            $scope.studentz = obj;
            //$scope.student.Birthday = $scope.student.Birthday;
            console.log($scope.studentz);

        }, function (error) {

            $scope.error(error);

        });
    }

    

    $scope.GetStudentId = function (stud) {
        studentId = $scope.student;
        var studentName = $.grep($scope.studentz, function (stud) {
            return stud.StudentId == studentId;
        })[0].Name;
        $scope.student.StudentId = studentId;
    }

    $scope.GetSubjetId = function (subs) {
        subjectId = $scope.subject;
        var subjetName = $.grep($scope.subjects, function (subs) {
            return subs.SubjectId == subjectId;
        })[0].Name;
        $scope.subject.SubjectId = subjectId;
    }


    $scope.GetGradeId = function (grad) {
        gradeId = $scope.grade;
        var gradeName = $.grep($scope.grades, function (grad) {
            return grad.GradeId == gradeId;
        })[0].Name;
        $scope.grade.GradeId = gradeId;
    }

    $scope.ShowHide = function () {
        $scope.IsVisible = true;
    }

    $scope.Alert = function () {
        alert("Sucess");
    }
    $scope.AllGrades = function () {
        $http.get("/Grade/AllGrades").then(function (response) {
            var resp = JSON.stringify(response.data);
            var obj = JSON.parse(resp);
            $scope.grades = obj;
            console.log($scope.grades);
        }, function (error) {
            $scope.error(error);
        });
    }

    $scope.AllSubjects = function () {
        $http.get("/Subject/AllSubjects").then(function (response) {
            $scope.subjects = response.data;
            console.log($scope.subjects);
        }, function (error) {
            $scope.error(error);
        });
    }

    $scope.GetStudentCourse = function () {
        $http.get("/StudentGrading/GetCourseByStudent?studentId=" + $scope.studentGrading.StudentId).then(function (response) {

            $scope.result = response.data;
            //for (key in $scope.record) {
            //    var obj = $scope.record[key];
            //    $scope.courseName = obj["courseName"];
            //}
            $scope.courseName = $scope.result.CourseName;
            
            
        }, function (error) {

            $scope.error(error);

        });
    }


   
    $scope.GetStudentSubject = function () {
        $http.get("/StudentGrading/GetStudentSubjects?studentId=" + $scope.studentGrading.StudentId).then(function (response) {

            $scope.record = response.data;
            $scope.totalCourses = response.data.length;
            
            $scope.totalCredit = $scope.record.reduce((n, { Unit }) => n+ parseInt(Unit), 0);
            //$scope.totalPoint = $scope.record.reduce((b, {Point }) => b + Point, 0);

        }, function (error) {

            $scope.error(error);


        });
    }











    $scope.GradeList = function () {
        $http.get("/StudentGrading/GetStudentGradingList").then(function (response) {

            $scope.gradeList = response.data;
            
        }, function (error) {

            $scope.error(error);


        });
    }






    $scope.CalculateGPA = function () {

        $scope.courseGrades = $scope.record.map(({ Name }) => Name)
    }



    $scope.GetGrades = function () {
        $http.get("/Grade/GradeList").then(function (response) {

            $scope.record = response.data;
            console.log($scope.record);

        }, function (error) {

            $scope.error(error);


        });
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
    //$scope.pop = function () {
    //    toaster.pop('Course Registration', "Course Registration", "Course Added Successfully!!");
    //};

    $scope.ConfirmGrade = function () {
        
        $scope.editable = true;

    }

    $scope.EditGrade = function () {

        $scope.editable = false;
    }

    $scope.CourseList = function () {
        $http.get("/Courses/Courses").then(function (response) {

            $scope.record = response.data;
            console.log($scope.record);

        }, function (error) {
            $scope.error(error);

        });
    }



    $scope.GetStudentSubjectGrade = function () {
        $http.get("/StudentGrading/GetStudentSubjectGrade").then(function (response) {
            var json = JSON.stringify(response.data)
            $scope.studentGradingList = JSON.parse(json);
            console.log($scope.studentGradingList);
        },function (error) {
            $scope.error(error);

        });
    }

    $scope.GetStudentGradingList = function () {
        $http.get("/StudentGrading/GetStudentGradingList").then(function (response) {
            var json = JSON.stringify(response.data)
            $scope.studentGradingLists = JSON.parse(json);
            console.log($scope.studentGradingLists);
        }, function (error) {
            $scope.error(error);

        });
    }


    $scope.GetStudentCourseAverage = function () {
        
        $http.get("/StudentGrading/GetStudentCourseAverage").then(function (response) {
            var json = JSON.stringify(response.data)
            $scope.studentGradeAverage = JSON.parse(json);
            console.log($scope.studentGradeAverage);
        }, function (error) {
            $scope.error(error);
        });
    }
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

});