var ContactDetailsController = function ($scope, MainService) {
    var target_id = MainService.TargetContact.ContactId;
    function RefreshEmailList() {
        var getmail = MainService.GetEmailById(target_id);
        getmail.then(function (param) {
            $scope.emails = param.data;;
        });
    }
    function RefreshTelNumList() {
        var gettelnum = MainService.GetTelNumById(target_id);
        gettelnum.then(function (telparam) {
            $scope.telnums = telparam.data;
        });
    }
    //fetch initial data
    RefreshEmailList();
    RefreshTelNumList();
    $scope.AddEmail = function (emailaddr) {
        var email = {
            Address: emailaddr,
            ContactId: target_id
        };
        var addemail = MainService.AddEmail(email);
        addemail.then(function () {
            RefreshEmailList();
            $scope.new_email = null;
        });
    };
    $scope.DeleteEmail = function (id) {
        var del = MainService.DeleteEmail(id);
        del.then(function () {
            RefreshEmailList();
        });
    };
    $scope.AddTel = function (num) {
        var tel = {
            Number: num,
            ContactId: target_id
        };
        var addtel = MainService.AddTel(tel);
        addtel.then(function () {
            RefreshTelNumList();
            $scope.new_tel = null;
        });
    };
    $scope.DeleteTel = function (id) {
        var del = MainService.DeleteTel(id);
        del.then(function () {
            RefreshTelNumList();
        });
    };
};
ContactDetailsController.$inject = ["$scope", "MainService"];