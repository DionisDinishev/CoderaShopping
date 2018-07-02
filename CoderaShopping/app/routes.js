angular.module("codera.shopping").config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/");
    $stateProvider
        .state("users/new", {
            url: "/users/new",
            controller: "EditUserController",
            templateUrl: "/app/users/editUser.html"
        })
        .state("users/edit/:userId", {
            url: "/users/edit/:userId",
            controller: "EditUserController",
            templateUrl: "/app/users/editUser.html"
        })
        .state("users", {
            url: "/users",
            controller: "UsersController",
            templateUrl: "/app/users/users.html"
        })

        .state("products/new", {
            url: "/products/new",
            controller: "EditProductsController",
            templateUrl: "/app/products/editProducts.html"
        })
        .state("products/edit/:productId", {
            url: "/products/edit/:productId",
            controller: "EditProductsController",
            templateUrl: "/app/products/editProducts.html"
        })
        .state("products", {
            url: "/products",
            controller: "ProductsController",
            templateUrl: "/app/products/products.html"
        })
        .state("category", {
            url: "/category",
            controller: "CategoriesController",
            templateUrl: "/app/categories/categories.html"
        })
        .state("category/new", {
            url: "/category/new",
            controller: "EditCategoryController",
            templateUrl: "/app/categories/editCategory.html"
        })
        .state("category/edit/:categoryId", {
            url: "/category/edit/:categoryId",
            controller: "EditCategoryController",
            templateUrl: "/app/categories/editCategory.html"
        })
        .state("orders", {
            url: "/orders",
            controller: "OrdersController",
            templateUrl: "/app/orders/orders.html"
        })
        .state("orders/new", {
            url: "/orders/new",
            controller: "EditOrderController",
            templateUrl: "/app/orders/editOrder.html"
        })
        .state("orders/edit/:orderID", {
            url: "/orders/edit/:orderId",
            controller: "EditOrderController",
            templateUrl: "/app/orders/editOrder.html"
        })
        .state("multiOrders", {
            url: "/multiOrders",
            controller: "MultiOrdersController",
            templateUrl: "/app/multiOrder/multiOrder.html"
        })
        .state("multiOrders/new", {
            url: "/multiOrders/new",
            controller: "EditMultiOrderController",
            templateUrl: "/app/multiOrder/editMultiOrder.html"
        })
        .state("multiOrders/edit/:orderProductsId", {
            url: "/multiOrders/edit/:orderProductsId",
            controller: "EditMultiOrderController",
            templateUrl: "/app/multiOrder/editMultiOrder.html"
        })

        

        .state("about", {
            // we'll get to this in a bit       
        });

});