var MainService = function ($http) {
    this.GetContacts = function () {
        return $http.get("/api/Contacts/");
    };
};
MainService.$inject = ["$http"];