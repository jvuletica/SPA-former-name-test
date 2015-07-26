var ShowContactsController = function ($scope, MainService) {
    //returns all contacts in db to scope
    function ShowContactsInDB() {
        var getcontacts = MainService.GetContacts();
        getcontacts.then(function (param) {
            $scope.contacts = param.data;
        })
    }
    //initial call to get contacts when controller is activated
    ShowContactsInDB();

    //delete contact from db
    $scope.Delete = function (id) {
        $scope.deleteid = id
        var del = MainService.DeleteContact(id);
        del.then(function () {
            //refresh scope data with current db data
            ShowContactsInDB();
        });
    };
};
ShowContactsController.$inject = ["$scope", "MainService"];