app.controller("MultiOrdersController",
    [
        "$scope", "orderProductsService", "$location",
        function ($scope, orderProductsService, $location) {

            $scope.propertyName = "Product";
            $scope.reverse = false;
            $scope.orders = {};

            //pagination
            $scope.currentPage = 1;
            $scope.maxSize = 5;

            orderProductsService.getOrdersCount().then(function (response) {
                $scope.ordersLenght = response.data;
                debugger;
            });
            orderProductsService.getOrdersOnPage($scope.currentPage, $scope.maxSize).then(function (response) {
                $scope.orders = response.data;
            });
            $scope.changePage = function() {
                orderProductsService.getOrdersOnPage($scope.currentPage, $scope.maxSize).then(function(response) {
                    $scope.orders = response.data;
                });
            };
            $scope.change = function(userName) {
                debugger;
                orderProductsService.searchOrderByUserName(userName).then(function(response) {
                    $scope.orders = response.data;
                });
            };
            $scope.editOrder = function (id) {
                $location.url("/multiOrders/edit/" + id);
            };

            $scope.sortBy = function (propertyName) {
                $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
                $scope.propertyName = propertyName;
            };
        }
    ]);