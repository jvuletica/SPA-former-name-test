var ContactDetailsController = function ($scope, $routeParams, MainService) {
    //target from routeParam
    target_id = $routeParams.id;

    function RefreshEmailList() {
        var getmail = MainService.GetEmailById(target_id);
        getmail.then(function (mail) {
            $scope.emails = mail.data;
        });
    }
    function RefreshTelNumList() {
        var gettelnum = MainService.GetTelNumById(target_id);
        gettelnum.then(function (telparam) {
            $scope.telnums = telparam.data;
        });
    }
    function RefreshSingleContact() {
        var getcontact = MainService.GetSingleContact(target_id);
        getcontact.then(function (contact) {
            $scope.contact = contact.data;
        });
    }
    //fetch initial data
    RefreshEmailList();
    RefreshTelNumList();
    RefreshSingleContact();


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
        //check if num object is number
        if (num % 1 != 0)
        {
            alert("Telephone must be number");
            $scope.new_tel = null;            
        }
        else {
            var tel = {
                Number: num,
                ContactId: target_id
            };
            var addtel = MainService.AddTel(tel);
            addtel.then(function () {
                RefreshTelNumList();
                $scope.new_tel = null;
            });
        }
    };
    $scope.DeleteTel = function (id) {
        var del = MainService.DeleteTel(id);
        del.then(function () {
            RefreshTelNumList();
        });
    };
};
ContactDetailsController.$inject = ["$scope", "$routeParams", "MainService"];