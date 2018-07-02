app.controller("OrdersController",
    [
        "$scope","orderService","$location",
        function ($scope, orderService, $location) {

            $scope.propertyName = "Product";
            $scope.reverse = false;
            $scope.currentPage = 1;
            $scope.maxSize = 5;

            orderService.countOrders().then(function(response) {
                $scope.ordersLenght = response.data;
                debugger;
            });
           /* orderService.getAll().then(function(response) {
                $scope.ordersLenght = response.data.length;
                debugger;
            });*/
            orderService.getOrdersOnPage($scope.currentPage,$scope.maxSize).then(function(response) {
                $scope.orders = response.data;
            });
            $scope.changePage= function() {
                orderService.getOrdersOnPage($scope.currentPage, $scope.maxSize).then(function (response) {
                    $scope.orders = response.data;
                });
            }
            $scope.editOrder = function(id) {
                $location.url("/orders/edit/" + id);
            };
            $scope.deleteOrder = function(order) {
                orderService.deleteOrder(order).then(function() {
                    orderService.getAll().then(function(response) {
                        $scope.orders = response.data;
                    });
                });
            };

            $scope.sortBy = function (propertyName) {
                $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
                $scope.propertyName = propertyName;
            };
        }
    ]);