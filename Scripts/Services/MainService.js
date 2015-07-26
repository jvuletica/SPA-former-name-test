var MainService = function ($http) {
    //shared object between controllers
    var TargetContact = {};

    //return all contacts
    this.GetContacts = function () {
        return $http.get("/api/Contacts/");
    };
    //return contact by id
    this.GetSingleContact = function (id) {
        return $http.get("/api/Contacts/" + id);
    };
    this.AddContact = function (contact) {
        var request = $http({
            method: "POST",
            url: "/api/Contacts/",
            data: contact
        });
        return request;
    };
    //deletes contact based on id
    this.DeleteContact = function (id) {
        var request = $http({
            method: "DELETE",
            url: "/api/Contacts/"+ id,
            data: id
        });
        return request;
    };
    this.UpdateContact = function (contact) {
        id = contact.ContactId;
        var request = $http({
            method: "PUT",
            url: "/api/Contacts/" + id,
            data: contact
        });
        return request;
    }
}
MainService.$inject = ["$http"];