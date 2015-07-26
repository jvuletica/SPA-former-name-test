var ContactDetailsController = function ($scope, MainService) {
    $scope.target_contact = MainService.TargetContact;
};
ContactDetailsController.$inject = ["$scope", "MainService"];