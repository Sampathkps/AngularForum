var forumApp = angular.module('myApp', ['ngRoute']);

forumApp.config(['$routeProvider', function ($routeProvider) {
      $routeProvider.
          when('/forum', {
              templateUrl: '/App/components/Forum/ForumList.html',
              controller: forumController
          }).
          when('/forum/:categoryId', {
              templateUrl: '/App/components/Forum/ForumList.html',
              controller: forumController
          }).
           when('/post', {
               templateUrl: '/App/components/Forum/AddForum.html',
               controller: forumController
           }).
          when('/post/:forumId', {
              templateUrl: '/App/components/Forum/EditForum.html',
              controller: forumController
          }).
          when('/deletePost/:forumId', {
              templateUrl: '/App/components/Forum/DeleteForum.html',
              controller: forumController
          }).
          when('/AddCategory', {
              templateUrl: '/App/components/Category/Addcategory.html',
              controller: categoryController
          }).
          otherwise({
              controller: forumController
          });
  }]);


forumApp.filter('pagination', function () {
    return function (input, start) {
        if (!input || !input.length) { return; }

        start = +start;
        return input.slice(start);
    };
});