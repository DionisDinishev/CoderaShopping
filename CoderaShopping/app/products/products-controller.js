angular.module("codera.shopping").controller("ProductsController",
    [
        "$scope",
        "$location",
        "productService",
        function ($scope, $location, productService) {

            //sortProperty

            $scope.propertyName = "Name";
            $scope.reverse = false;
            //pagination
            $scope.currentPage = 1;
            $scope.maxSize = 5;

            productService.getProductsCount().then(function(response) {
                $scope.productsLenght = response.data;
                debugger;
            });
            productService.getProductsOnPage($scope.currentPage, $scope.maxSize).then(function (response) {
                $scope.products = response.data;
            });
            $scope.changePage = function () {
                productService.getProductsOnPage($scope.currentPage, $scope.maxSize).then(function (response) {
                    $scope.products = response.data;
                });
            }
            $scope.change = function (productName) {
                debugger;
                productService.searchByProductName(productName).then(function(response) {
                    $scope.products = response.data;
                });
            }
            $scope.editProduct = function(productId) {
                $location.url("/products/edit/" + productId);
            };

            $scope.deleteProduct = function(product) {
                productService.deleteProduct(product).then(function(re) {
                    productService.getAll().then(function(response) {
                        $scope.products = response.data;
                        debugger;
                    });
                });
            };

            $scope.sortBy = function(propertyName) {
                $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
                $scope.propertyName = propertyName;

                if (propertyName === "Name") {
                    productService.orderByName(!$scope.reverse).then(function (response) {
                        $scope.products = response.data;
                    });
                }
                else if (propertyName === "Description") {
                    productService.orderByDescription(!$scope.reverse).then(function (response) {
                        $scope.products = response.data;
                    });
                }
                else if (propertyName === "Category") {
                    productService.orderByCategory(!$scope.reverse).then(function (response) {
                        $scope.products = response.data;
                    });
                }
            };


        }
    ]);