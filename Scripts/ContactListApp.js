var ContactListApp = new angular.module("ContactListApp", ["ngRoute"]);

//add services and controllers
ContactListApp.service("MainService", MainService);
ContactListApp.controller("IndexController", IndexController);
ContactListApp.controller("ShowContactsController", ShowContactsController);
ContactListApp.controller("AddContactController", AddContactController);
ContactListApp.controller("UpdateContactController", UpdateContactController);
ContactListApp.controller("ContactDetailsController", ContactDetailsController);

//define routing
var configFunction = function ($routeProvider) {
    $routeProvider.
        when("/showcontacts", {
            templateUrl: "home/showcontacts",
            controller: "ShowContactsController"
        });
    $routeProvider.
        when("/addcontact", {
            templateUrl: "home/addcontact",
            controller: "AddContactController"
        });
    $routeProvider.
    when("/updatecontact", {
        templateUrl: "home/updatecontact",
        controller: "UpdateContactController"
    });
    $routeProvider.
    when("/contactdetails", {
        templateUrl: "home/contactdetails",
        controller: "ContactDetailsController"
    });
}
configFunction.$inject = ["$routeProvider"];
ContactListApp.config(configFunction);
