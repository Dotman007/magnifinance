var app = angular.module("StudentGradingApp", ['ngAnimate'])
    
app.controller("StudentGradingController", function ($scope, $http) {

    //public int StudentId { get; set; }
    //    public int GradeId { get; set; }
    //    public int CourseId { get; set; }
    //    public int SubjectId { get; set; }
    $scope.startSpin = true;
    $scope.courseList = [];
    $scope.unitList = [];
    $scope.gradeList=[];
    $scope.btnSave = "Save";
    $scope.courseName = "";
    $scope.subjectName = "";
    $scope.selectedValue = "";
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

    $scope.studentGradeAverage = [];
    
    $scope.grade.Name = $scope.Name;
    $scope.studentGrading.StudentId = $scope.StudentId;
    $scope.courseList = [];
   
    $scope.record = [];
    $scope.result = {};
    // Add Teacher
    console.log("CourseName: " + $scope.teacher);
    $scope.AddTeacher = function () {

        $scope.btnSave = "Please Wait..";

        $http({

            method: 'POST',

            url: '/Teachers/CreateTeacher',

            data: $scope.teacher

        }).then(function (response){

            $scope.btnSave = "Save";

            $scope.course = null;
            //$scope.pop();
            $scope.Alert();

           
        }).error(function () {

            alert('Failed');

        });

    };


    $scope.ShowHide = function () {
        $scope.IsVisible = true;
    }

    $scope.Alert = function () {
        alert("Sucess");
    }



    $scope.GetStudentCourse = function () {
        $http.get("/StudentGrading/GetCourseByStudent?studentId=" + $scope.studentGrading.StudentId).then(function (response) {

            $scope.result = response.data;
            //for (key in $scope.record) {
            //    var obj = $scope.record[key];
            //    $scope.courseName = obj["courseName"];
            //}
            $scope.courseName = $scope.result.CourseName;
            
            console.log($scope.result);

        }, function (error) {

            alert('Failed');

        });
    }


    $scope.getGrade = function () {
        alert("Hi +" + parseInt($scope.grade.Name) * $scope.totalCourses.length);
        
        //console.log()
        //console.log("grade Point " + JSON.stringify($scope.grade.Name));
    }
    $scope.GetStudentSubject = function () {
        $http.get("/StudentGrading/GetStudentSubjects?studentId=" + $scope.studentGrading.StudentId).then(function (response) {

            $scope.record = response.data;
            $scope.totalCourses = response.data.length;
            console.log("Data: " + JSON.stringify(response.data));
            $scope.totalCredit = $scope.record.reduce((n, { Unit }) => n+ parseInt(Unit), 0);
            //$scope.totalPoint = $scope.record.reduce((b, {Point }) => b + Point, 0);


            console.log("Grade:  "+$scope.grade.Name);
            
            console.log($scope.totalCourses);
            console.log("Total Credit : " + $scope.totalCredit);
            //console.log("Total Point : " + $scope.totalPoint);

            console.log($scope.record);

        }, function (error) {

            alert('Failed');

        });
    }











    $scope.GradeList = function () {
        $http.get("/StudentGrading/GradeList").then(function (response) {

            $scope.gradeList = response.data;
            console.log($scope.grade.Name);
            console.log(response.data);
        }, function (error) {

            alert('Failed');

        });
    }

    $scope.DisplayGrades = function () {
        console.log("Grades : "+$scope.grade.Name);
    }





    $scope.CalculateGPA = function () {

        $scope.courseGrades = $scope.record.map(({ Name }) => Name)
    }



    $scope.GetGrades = function () {
        $http.get("/Grade/GradeList").then(function (response) {

            $scope.record = response.data;
            console.log($scope.record);

        }, function (error) {

            alert('Failed');

        });
    }

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
            alert('Failed');
        });
    }



    $scope.GetStudentSubjectGrade = function () {
        $http.get("/StudentGrading/GetStudentSubjectGrade").then(function (response) {
            var json = JSON.stringify(response.data)
            $scope.studentGradingList = JSON.parse(json);
            console.log($scope.studentGradingList);
        },function (error) {
            alert('Failed');
        });
    }

    $scope.GetStudentGradingList = function () {
        $http.get("/StudentGrading/GetStudentGradingList").then(function (response) {
            var json = JSON.stringify(response.data)
            $scope.studentGradingLists = JSON.parse(json);
            console.log($scope.studentGradingLists);
        }, function (error) {
            alert('Failed');
        });
    }


    $scope.GetStudentCourseAverage = function () {
        
        $http.get("/StudentGrading/GetStudentCourseAverage").then(function (response) {
            var json = JSON.stringify(response.data)
            $scope.studentGradeAverage = JSON.parse(json);
            console.log($scope.studentGradeAverage);
        }, function (error) {
            alert('Failed');
        });
    }

});