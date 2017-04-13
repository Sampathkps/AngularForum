'use strict';

function forumController($scope, $http, $location, $routeParams, crudForumFactory, crudForumService, categoryFactory) {

    $scope.count = crudForumService.Count();
    GetAllForum();

    function GetAllForum() {
        var getForumData = [];

        if($routeParams.categoryId)
        {
            getForumData = crudForumFactory.getForumByCategory($routeParams.categoryId);
        }
        else            
            getForumData = crudForumFactory.getForum();

        getForumData.then(function (forum) {

            $scope.posts = forum.data;
        }, function () {
            alert('Error in getting forum');
        });
    }

    GetAllCategory();

    function GetAllCategory() {
        var getData = categoryFactory.getCategory();
        getData.then(function (category) {

            $scope.forumCategory = category.data;
        }, function () {
            alert('Error in getting category');
        });
    }

    $scope.formatDate = function (date) {
        var dateOut = new Date(date);
        return dateOut;
    };

    if ($routeParams.forumId) {
        $scope.forumId = $routeParams.forumId;
        $http.get('api/forum/GetForum/' + $routeParams.forumId).success(function (data) {
            $scope.post = data;
            $scope.post.forumId = $scope.forumId; 
        });
    }

    $scope.UpdateForum = function () {        

        $scope.post.ForumID = $scope.forumId;
        var getForumData = crudForumFactory.UpdateForum($scope.post);
        getForumData.then(function (msg) {            
            alert(msg.data);
            $location.path('/forum');
        }, function () {
            alert('Error in updating forum');
        });
    }

    $scope.AddForum = function () {
        var forumData = {
                        Subject: $scope.Subject,
                        CategoryID: $scope.Category,
                        Description: $scope.Description,
                        PostedBy : $scope.PostedBy            
                    };
        
        
        var getForumData = crudForumFactory.AddForum(forumData);
        getForumData.then(function (msg) {            
            alert(msg.data);
            $location.path('/forum');
        }, function () {
            alert('Error in adding forum');
        });
    }


    $scope.DeleteForum = function () {
        var getForumData = crudForumFactory.DeleteForum($scope.forumId);
        getForumData.then(function (msg) {
            alert(msg.data);
            $location.path('/forum');
        }, function () {
            alert('Error in deleting forum');
        });
    }


    
    $scope.sortAttr = 'Subject';
    $scope.curPage = 0;
    $scope.pageSize = 5;

    $scope.numberOfPages = function () {
        if (!$scope.posts || !$scope.posts) { return 1; }
        return Math.ceil($scope.posts.length / $scope.pageSize);
    };

    $scope.doTheBack = function () {
        window.history.back();
    };

    $scope.Close = function () {
        $location.path('/forum');
    }
};