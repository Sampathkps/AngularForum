forumApp.service("crudForumService", ['crudForumFactory', function (crudForumFactory) {

    this.Count = function () {
        var forum = crudForumFactory.getForum();
        return angular.isDefined(forum) && forum.length > 0 ? books.length : 0;
    }

}]);