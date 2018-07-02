app.controller("EditProductsController",
    [
        "$scope", "$stateParams", "$location", "productService", "categoryService",
        function ($scope, $stateParams, $location, productService, categoryService) {
            var newProduct;
            $scope.validationErrors = false;
            if ($stateParams.productId !== undefined) {
                productService.getById($stateParams.productId).then(function(response) {
                    $scope.product = response.data;
                    console.log(response.data);
                });
            } else {
                newProduct = true;
                $scope.product = {};
            }

            // fetch the categories
            $scope.categories = [];
            categoryService.getAll().then(function(response) {
                $scope.categories = response.data;
                debugger;
                console.log(response.data);
                $scope.product.Category = response.data[0];
            });

            $scope.saveProduct = function (product, form) {
                debugger;
                if (newProduct) {
                    debugger;
                        productService.saveProduct(product).then(function(response) {
                            $scope.validationErrors = false;
                            $location.url("/products");
                        },function(response) {
                            $scope.validationErrors = response.data.errorMessage;
                            debugger;
                        });
                        
                    } else {
                        productService.updateProduct(product);
                        $scope.validationErrors = false;
                    }

            }
            $scope.cancel=function() {
                $location.url("/products");
            }



        }
    ]);