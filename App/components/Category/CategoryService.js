forumApp.factory("categoryFactory", ['$http', function ($http) {

    var categoryFactory = {};
    //get All Category
    categoryFactory.getCategory = function () {
        return $http.get("api/Category/GetAllCategory");
    };

    // Add Category
    categoryFactory.AddCategory = function (category) {
        var response = $http.post("api/Category/AddCategory", category);
        return response;
    }

    return categoryFactory;
}]);