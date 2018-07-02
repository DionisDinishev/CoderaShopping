    "use strict";

app.factory("userData",
    [
        "$http", function($http) {

            return{
                getAll: function() {
                    return $http.get("/users/getall");
                },
                getUserById: function(userId) {
                    return $http.get("/users/getbyid/" + userId);
                },
                saveUser: function (user) {
                    return $http.post("/users/adduser", user);
                },
                updateUser: function (user, id) {
                    return $http.post("/users/UpdateUser/", user);
                },
                deleteUser: function(user) {
                    return $http.post("/users/deleteuser", user);
                },
                orderByName: function(ascendingOrder) {
                    return $http.get("/users/orderbyname/?ascendingOrder="+ascendingOrder);
                },
                orderByEmail: function(ascendingOrder) {
                    return $http.get("/users/orderbyemail/?ascendingOrder="+ ascendingOrder);
                },
                orderByPhone: function(ascendingOrder) {
                    return $http.get("/users/orderbyphone/?ascendingOrder="+ ascendingOrder);
                },
                orderByUserType: function(ascendingOrder) {
                    return $http.get("/users/orderbyusertype/?ascendingOrder="+ ascendingOrder);
                },
                searchByUserName: function (userName) {
                    debugger;
                    return $http.get("/users/SearchByUserName/?userName=" + userName);
                },
                getUsersOnPage: function(page, size) {
                    return $http.get("/users/getUsersOnPage/?page=" + page + "&size=" + size);
                },
                getUsersCount: function () {
                    return $http.get("/users/GetUsersCount");
                }

            };
        }
    ]);