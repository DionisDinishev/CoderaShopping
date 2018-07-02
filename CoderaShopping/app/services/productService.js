"use strict"

app.factory("productService",
    ["$http", function ($http) {

            return {
                getAll: function () {
                    return $http.get("/products/getall");
                },
                getById:function(id) {
                    return $http.get("/products/getbyid/"+id);
                },
                saveProduct:function(product) {
                    return $http.post("/products/add/", product);
                },
                updateProduct: function (product) {
                    return $http.post("/products/update/", product);
                },
                deleteProduct:function(product) {
                    return $http.post("/products/delete", product);
                },
                orderByName: function (ascendingOrder) {
                    return $http.get("/products/orderbyname/?ascendingOrder=" + ascendingOrder);
                },
                orderByDescription: function (ascendingOrder) {
                    return $http.get("/products/orderbydescription/?ascendingOrder=" + ascendingOrder);
                },
                orderByCategory: function (ascendingOrder) {
                    return $http.get("/products/orderbycategory/?ascendingOrder=" + ascendingOrder);
                },
                searchByProductName: function (productName) {
                    return $http.get("/products/SearchByProductName/?productname=" + productName);
                },
                getProductsOnPage: function(page, size) {
                    return $http.get("/products/GetProductsOnPage/?page=" + page + "&size=" + size);
                },
                getProductsCount: function() {
                    return $http.get("/products/getproductscount");
                }

            };
        }
    ]);