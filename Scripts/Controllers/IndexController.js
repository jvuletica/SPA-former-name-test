var IndexController = function ($scope, $location, MainService) {
    $scope.Find = function () {
        var search = MainService.Search($scope.search_string);
        search.then(function (param) {
            $scope.search_results = param.data;
        });
        //delete contact from db
        $scope.Delete = function (contact) {
            var del = MainService.DeleteContact(contact.ContactId);
            del.then(function () {
                var index = $scope.search_results.indexOf(contact);
                $scope.search_results.splice(index, 1);
            });
        };

        $scope.GoToDetails = function (id) {
            $location.path("/contactdetails/" + id);
        };
        $scope.GoToUpdate = function (contact) {
            $location.path("/updatecontact/");
            MainService.TargetContact = contact
        };
    }
};
IndexController.$inject = ["$scope", "$location", "MainService"];