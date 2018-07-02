app.controller("EditMultiOrderController",
    [
        "$scope", "$stateParams", "orderService", "$location", "categoryService", "userData", "productService", "orderProductsService", function ($scope, $stateParams, orderService, $location, categoryService, userData, productService, orderProductsService) {
            var newOrder;
            $scope.productsList = [];



            categoryService.getAll().then(function (response) {
                $scope.categories = response.data;
            });
            userData.getAll().then(function (response) {
                $scope.users = response.data;
            });
            productService.getAll().then(function (response) {
                $scope.products = response.data;
            });
            if ($stateParams.orderProductsId !== undefined) {
                orderService.getById($stateParams.orderProductsId).then(function (response) {
                    $scope.order = response.data;
                   
                });
                newOrder = false;
            } else {
                $scope.order = {};
                newOrder = true;
            }

            $scope.saveOrder = function (order, form) {
                orderProductsService.generateGUID().then(function(response) {
                    $scope.guid = response.data;

                    var orderProduct =
                    {
                        Order: { Id: $scope.guid, Quantity: order.Quantity,User:order.User },
                        Quantity: order.Quantity,
                        Product: { Id: {} },
                        Products: [],
                        Id: {}
                        };
                    for (var o in order.Products) {

                        orderProduct.Products.push({ Id: order.Products[o] });
                        
                    }
                    debugger;
                    orderProductsService.saveOrder(orderProduct);
                   
                });

            };

            $scope.cancel = function(order, form) {
                $location.url("/multiOrders");
            };

            $scope.addToOrder = function(prod, quantity) {
                $scope.productsList.push({
                    productName: prod.Name,
                    productQuantity: prod.Quantity
                });
            };

            $scope.removeFromOrder = function(product) {
                $scope.productsList.pop(product);
            };


        }
    ]);