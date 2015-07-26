var UpdateContactController = function ($scope, MainService) {
    $scope.target_contact = MainService.TargetContactForUpdate;
    $scope.UpdateContact = function (contact) {
        var update = MainService.UpdateContact(contact);
        update.then(function () {
            alert("Contact updated");
        });
    };
};
UpdateContactController.$inject = ["$scope", "MainService"];