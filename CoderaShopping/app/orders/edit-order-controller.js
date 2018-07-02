app.controller("EditOrderController",
    [
        "$scope", "$stateParams", "orderService", "$location", "categoryService", "userData", "productService", function ($scope, $stateParams, orderService, $location, categoryService, userData, productService) {
            var newOrder;

            categoryService.getAll().then(function (response) {
                $scope.categories = response.data;
            });
            userData.getAll().then(function (response) {
                $scope.users = response.data;
            });
            productService.getAll().then(function (response) {
                $scope.products = response.data;
            });
            if ($stateParams.orderId !== undefined) {
                orderService.getById($stateParams.orderId).then(function (response) {
                    $scope.order = response.data;
                    console.log(response.data);
                });
                newOrder = false;
            } else {
                $scope.order = {};
                newOrder = true;
            }

            $scope.saveOrder = function (order, form) {
                var promiseHandle = undefined;
                if (newOrder) {
                    promiseHandle = orderService.saveOrder(order);
                } else {
                    promiseHandle = orderService.updateOrder(order);
                }

                promiseHandle.then(
                    function (response) {
                        $location.url("/orders");
                    }, function (response) {
                        alert(JSON.stringify(response.data));
                    });
                
            }

            $scope.cancel = function (order, form) {
                $location.url("/orders");
            }



        }
    ]);