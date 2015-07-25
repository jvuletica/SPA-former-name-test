var ShowContactsController = function ($scope, MainService) {
    var contacts = MainService.GetContacts();
    contacts.then(function (param) {
        $scope.contacts = param.data;
    })
};
ShowContactsController.$inject = ["$scope", "MainService"];