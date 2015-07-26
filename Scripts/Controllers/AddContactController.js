var AddContactController = function ($scope, MainService) {
    $scope.AddContact = function () {
        //create js object corresponding to contact object in asp
        var contact = {
            Tag: $scope.new_tag,
            Name: $scope.new_name,
            Surname: $scope.new_surname,
            Address: $scope.new_address
        };
        //call AddContact service and pass the new contact object
        var addfn = MainService.AddContact(contact);
        addfn.then(function() {
            alert("Contact added");
        });
    }
};
AddContactController.$inject = ["$scope", "MainService"];