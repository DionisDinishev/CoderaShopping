app.controller("CategoriesController",
    [
        "$scope",
        "categoryService",
        "$location",
        function ($scope, categoryService, $location) {

            $scope.propertyName = "Name";
            $scope.reverse = false;


            //pagination
            $scope.currentPage = 1;
            $scope.maxSize = 5;

            categoryService.getCategoriesCount().then(function (response) {
                $scope.categoriesLenght = response.data;
                debugger;
            });
            categoryService.getCategoriesOnPage($scope.currentPage, $scope.maxSize).then(function (response) {
                $scope.categories = response.data;
            });
            categoryService.orderByName(true).then(function(response) {
                $scope.categories = response.data;
            });
            $scope.changePage = function () {
                categoryService.getCategoriesOnPage($scope.currentPage, $scope.maxSize).then(function (response) {
                    $scope.categories = response.data;
                });
            }
            $scope.change = function(categoryName) {
                categoryService.searchByCategoryName(categoryName).then(function(response) {
                    $scope.categories = response.data;
                });
            }
            $scope.editCategory = function(id) {
                $location.url("/category/edit/" + id);
            };

            $scope.deleteCategory = function(category) {
                categoryService.deleteCategory(category).then(function() {
                    categoryService.getAll().then(function(response) {
                        $scope.categories = response.data;
                    });
                });
            };

            $scope.sortBy = function (propertyName) {
                $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
                $scope.propertyName = propertyName;
                if (propertyName === "Name") {
                    categoryService.orderByName(!$scope.reverse).then(function (response) {
                        $scope.categories = response.data;
                    });
                }
                else if (propertyName === "Status") {
                    categoryService.orderByStatus(!$scope.reverse).then(function (response) {
                        $scope.categories = response.data;
                    });
                }
            }
        }
    ]);