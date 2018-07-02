angular.module("codera.shopping").controller("UsersController",
    [
        "$scope",
        "$location",
        "userData",
        function($scope, $location, userData) {


            $scope.sortName = true;
            $scope.sortEmail = false;
            $scope.sortPhone = false;

            $scope.selectedSort = "Name";
            $scope.sortOrder = "Name";


            //sortProperty

            $scope.propertyName = "Name";
            //pagination

            $scope.currentPage = 1;
            $scope.maxSize = 5;


            /*userData.orderByName(true).then(function(response) {
                $scope.users = response.data;
                $scope.reverse = false;
            });*/

            userData.getUsersCount().then(function(response) {
                $scope.usersLenght = response.data;
                debugger;
            });
            userData.getUsersOnPage($scope.currentPage, $scope.maxSize).then(function (response) {
                $scope.users = response.data;
            });

            $scope.change = function (text) {
                userData.searchByUserName(text).then(function(response) {
                    $scope.users = response.data;

                    debugger;
                });
            }
            $scope.changePage = function () {
                userData.getUsersOnPage($scope.currentPage, $scope.maxSize).then(function (response) {
                    $scope.users = {};
                    $scope.users = response.data;
                });
            }
            $scope.editUser = function(userId) {
                $location.url("/users/edit/" + userId);
            }

            $scope.deleteUser = function(user) {
                userData.deleteUser(user)
                    .then(function() {
                        userData.getAll().then(function(response) {
                            $scope.users = response.data;
                        });
                    });

            }

            $scope.clickSort = function(element) {
            }
            $scope.sortBy = function(propertyName) {
                $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
                $scope.propertyName = propertyName;
                if (propertyName === "Name") {
                    userData.orderByName(!$scope.reverse).then(function(response) {
                        $scope.users = response.data;
                    });
                } else if (propertyName === "Email") {
                    userData.orderByEmail(!$scope.reverse).then(function(response) {
                        $scope.users = response.data;
                    });
                } else if (propertyName === "Phone") {
                    userData.orderByPhone(!$scope.reverse).then(function(response) {
                        $scope.users = response.data;
                    });
                } else if (propertyName === "UserType") {
                    userData.orderByUserType(!$scope.reverse).then(function(response) {
                        $scope.users = response.data;
                    });
                }
            };
        }
    ]);