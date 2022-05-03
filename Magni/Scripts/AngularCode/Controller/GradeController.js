var app = angular.module("GradeApp", ['angularUtils.directives.dirPagination', 'ngAnimate', 'toaster'])
    
app.controller("GradeController", function ($scope, $http, toaster, $window) {


    $scope.grade = {};
    $scope.gradeDetail = {};
    $scope.grades = [];
    $scope.grade.Name = $scope.Name;
    $scope.grade.Score = $scope.Score;
    $scope.updateGrade = {};
    $scope.message = "";

    $scope.showModal = false;
    $scope.showDiv = false;

    $scope.ShowHide = function () {
        $scope.showModal = true;
        $scope.showDiv = true;
        return;
    }


    $scope.success = function () {
        toaster.pop('success', "Success", "Grade Created Successfully");
        //toaster.pop('success', "title", '<ul><li>Render html</li></ul>', 5000, 'trustedHtml');
        //toaster.pop('error', "title", '<ul><li>Render html</li></ul>', null, 'trustedHtml');
        //toaster.pop('wait', "title", null, null, 'template');
        //toaster.pop('warning', "title", "myTemplate.html", null, 'template');
        //toaster.pop('note', "title", "text");
    };


    $scope.delete = function () {
        toaster.pop('success', "Success", "Grade Deleted Successfully");
        //toaster.pop('success', "title", '<ul><li>Render html</li></ul>', 5000, 'trustedHtml');
        //toaster.pop('error', "title", '<ul><li>Render html</li></ul>', null, 'trustedHtml');
        //toaster.pop('wait', "title", null, null, 'template');
        //toaster.pop('warning', "title", "myTemplate.html", null, 'template');
        //toaster.pop('note', "title", "text");
    };

    $scope.update = function () {
        toaster.pop('success', "Success", "Grade Updated Successfully");
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

    $scope.Hide = function () {
        $scope.showModal = false;
        $scope.showDiv = false;
    }
    //Create Course
    $scope.CreateGrade = function () {
        $http({
            method: 'POST',
            url: '/Grade/CreateGrade',
            data: $scope.grade
        }).then(function (data) {
            $scope.grade = null;
            $scope.AllGrades();
            $scope.success();
        }).catch(function (error) {
            $scope.error(error);
        });
    };



    $scope.GetGradeById = function (id) {

        $http.get("/Grade/GetGradeById?Id=" + id).then(function (response) {
            $scope.gradeDetail = response.data;
            $scope.gradeDetail.Name = response.data.Name;
            $scope.gradeDetail.Score = response.data.Score;
            $scope.gradeDetail.GradeId = response.data.GradeId;
            console.log($scope.gradeDetail);
        }, function (error) {
            $scope.error(error);
        });
    }



    $scope.UpdateGrade = function (id, name, score) {
        $scope.updateGrade.GradeId =id;
        $scope.updateGrade.Name = name;
        $scope.updateGrade.Score = score;
        $http({
            method: 'POST',
            url: '/Grade/UpdateGrade',
            data: $scope.updateGrade
        }).then(function (data) {
            var resp = JSON.stringify(data);
            //alert(data.data.ResponseMessage);
            $scope.updateGrade= null;
            $scope.AllGrades();
            $scope.update();
        }).catch(function (error) {
            $scope.error(error);
        });
    }



    $scope.DeleteGrade = function (id) {
        $http.get("/Grade/DeleteGrade?Id=" + id).then(function (response) {
            $scope.AllGrades();
            $scope.delete();
        }, function (error) {
            $scope.error(error);
        });
    }



    $scope.courses = [];
    $scope.AllGrades = function () {
        $http.get("/Grade/AllGrades").then(function (response) {
            var resp = JSON.stringify(response.data);
            var obj = JSON.parse(resp);
            $scope.grades = obj;
            console.log($scope.courses);
        }, function (error) {
            $scope.error(error);
        });
    }

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }

});