app.controller("EditCategoryController",
    [
        "$scope", "categoryService", "$stateParams", "$location",
        function($scope, categoryService, $stateParams, $location) {
            var newCategory;

            $scope.validationErrors = false;
            $scope.regex = "[a-zA-Z]*";
            if ($stateParams.categoryId !== undefined) {
                newCategory = false;
                categoryService.getById($stateParams.categoryId).then(function(response) {
                    $scope.category = response.data;
                    console.log(response.data);
                });

            } else {
                newCategory = true;
                $scope.category = { Status: false};
            }

            $scope.saveCategory = function(category, form) {
                
                if (newCategory) {
                    categoryService.saveCategory(category)
                        .then(function(response) {
                                $scope.validationErrors = false;
                                $location.url("/category");
                            },
                            function(response) {
                                $scope.validationErrors = response.data.errorMessage;
                                debugger;
                            });
                } else {
                    categoryService.updateCategory(category);
                }
            }

            categoryService.getAll().then(function(response) {
                $scope.categories = response.data;
            });

        }
    ]);