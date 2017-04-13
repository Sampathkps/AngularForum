forumApp.factory("crudForumFactory", ['$http', function ($http) {

    var crudForumFactory = {};
    //get All Forum
    crudForumFactory.getForum = function () {
        return $http.get("api/forum/GetAllForum");
    };

    crudForumFactory.getForumByCategory = function (categoryId) {
        return $http.get("api/forum/GetAllForum/" + categoryId);
    };

    // Update Forum 
    crudForumFactory.UpdateForum = function (forum) {
        var forumData = forum;
        var response = $http.put("api/forum/UpdateForum", forum);
        return response;
        
    }

    // Add Forum
    crudForumFactory.AddForum = function (forum) {
        var response = $http.post("api/forum/AddForum", forum);
        return response;
    }

    //Delete Forum
    crudForumFactory.DeleteForum = function (forumId) {
        var response = $http.delete("api/forum/DeleteForum/" + forumId);
        return response;
    }

    return crudForumFactory;
}]);