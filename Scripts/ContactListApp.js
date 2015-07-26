var ContactListApp = new angular.module("ContactListApp", ["ngRoute"]);

//add services and controllers
ContactListApp.service("MainService", MainService);
ContactListApp.controller("IndexController", IndexController);
ContactListApp.controller("ShowContactsController", ShowContactsController);
ContactListApp.controller("AddContactController", AddContactController);

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
}
configFunction.$inject = ["$routeProvider"];
ContactListApp.config(configFunction);
