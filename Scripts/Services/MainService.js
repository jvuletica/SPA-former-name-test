var MainService = function ($http) {
    //shared object between controllers
    var TargetContact = {};

    //return all contacts
    this.GetContacts = function () {
        return $http.get("/api/Contacts/");
        //return $http.get("/Contacts1");
    };
    //return contact by id
    this.GetSingleContact = function (id) {
        return $http.get("/api/Contacts/" + id);
    };
    this.Search = function (search_string) {
        return $http.get("/api/Contacts/search/" + search_string);
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
    //updates contact based on id
    this.UpdateContact = function (contact) {
        id = contact.ContactId;
        var request = $http({
            method: "PUT",
            url: "/api/Contacts/" + id,
            data: contact
        });
        return request;
    }
    this.GetEmailById = function (id) {
        return $http.get("/api/EmailAddrs/" + id);
    };
    this.AddEmail = function (email) {
        id = email.ContactId;
        var request = $http({
            method: "POST",
            url: "/api/EmailAddrs/" + id,
            data: email
        });
        return request;
    };
    this.DeleteEmail = function (id) {
        var request = $http({
            method: "DELETE",
            url: "/api/EmailAddrs/" + id,
            data: id
        });
        return request;
    };
    this.GetTelNumById = function (id) {
        return $http.get("/api/TelNums/" + id);
    };
    this.AddTel = function (tel) {
        id = tel.ContactId;
        var request = $http({
            method: "POST",
            url: "/api/TelNums/" + id,
            data: tel
        });
        return request;
    };
    this.DeleteTel = function (id) {
        var request = $http({
            method: "DELETE",
            url: "/api/TelNums/" + id,
            data: id
        });
        return request;
    };
}
MainService.$inject = ["$http"];