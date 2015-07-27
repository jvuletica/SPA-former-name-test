﻿var UpdateContactController = function ($scope, MainService) {
    //get shared object from service
    $scope.target_contact = MainService.TargetContact;

    $scope.UpdateContact = function (contact) {
        var update = MainService.UpdateContact(contact);
        update.then(function () {
            alert("Updated")
        });
    };
};
UpdateContactController.$inject = ["$scope", "MainService"];