app.factory("categoryService",
    [
        "$http",
        function($http) {
            return {
                getAll: function() {
                    return $http.get("/categories/getall");
                },
                getById: function(id) {
                    return $http.get("/categories/getbyid/" + id);
                },
                saveCategory: function(category) {
                    return $http.post("/categories/add/", category);
                },
                updateCategory: function(category) {
                    return $http.post("/categories/update/", category);
                },
                deleteCategory: function(category) {
                    return $http.post("/categories/delete/", category);
                },
                orderByName: function(ascendingOrder) {
                    return $http.get("/categories/orderbyname/?ascendingOrder=" + ascendingOrder);
                },
                orderByStatus: function(ascendingOrder) {
                    return $http.get("/categories/orderbystatus/?ascendingOrder=" + ascendingOrder);
                },
                searchByCategoryName: function(categoryName) {
                    return $http.get("/categories/SearchByCategoryName/?categoryName=" + categoryName);
                },
                getCategoriesCount: function() {
                    return $http.get("/categories/getCategoriesCount");
                },
                getCategoriesOnPage: function(page,size) {
                    return $http.get("/categories/getCategoriesOnPage/?page=" + page + "&size=" + size);
                }
            }
        }
    ]);