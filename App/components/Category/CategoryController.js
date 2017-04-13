'use strict';

function categoryController($scope, $location, categoryFactory) {

   
    GetAllCategory();

    function GetAllCategory() {
        var getData = categoryFactory.getCategory();
        getData.then(function (category) {

            $scope.categories = category.data;
        }, function () {
            alert('Error in getting category');
        });
    }

    $scope.AddCategory = function () {
        var categoryData = {
            Category: $scope.Category
        };


        var getData = categoryFactory.AddCategory(categoryData);
        getData.then(function (msg) {           
            alert(msg.data);
            $location.path('/forum');
        }, function () {
            alert('Error in adding category');
        });
    }

    $scope.doTheBack = function () {
        window.history.back();
    };

    $scope.Close = function () {
        $location.path('/forum');
    }

};