app.controller("EditUserController",
    [
        "$scope", "$stateParams", "userData", "$location", function ($scope, $stateParams,userData, $location) {
            var newUser;
            $scope.regex = "\\d+";
            $scope.validationErrors = false;
            $scope.userType = [{ Name: "Internal" }, { Name: "External" }];
            if ($stateParams.userId !== undefined) {
                userData.getUserById($stateParams.userId).then(function(response) {
                    $scope.user = response.data;
                    newUser = false;
                });
            }
            else {
                newUser = true;
                $scope.user = {};

            }

            $scope.saveUser = function(user) {
                debugger;
                if (newUser) {
                    userData.saveUser(user).then(function(response) {
                            $scope.validationErrors = false;
                        },
                        function(response) {
                            $scope.validationErrors = response.data.errorMessage;
                        });
                } else {
                    userData.updateUser(user, $stateParams.userId);
                }
            };
            $scope.cancel = function(user, form) {
                console.log($location);
                $location.url("/users");
            };
        }
    ]);