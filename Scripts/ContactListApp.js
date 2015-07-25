var ContactListApp = new angular.module("ContactListApp", ["ngRoute"]);

//add services and controllers
ContactListApp.service("MainService", MainService);
ContactListApp.controller("ShowContactsController", ShowContactsController);

//define routing
var configFunction = function ($routeProvider) {
    $routeProvider.
        when("/showcontacts", {
            templateUrl: "home/showcontacts",
            controller: "ShowContactsController"
        });
}
configFunction.$inject = ["$routeProvider"];
ContactListApp.config(configFunction);
