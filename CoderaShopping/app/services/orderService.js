app.factory("orderService",
    [
        "$http", function($http) {
            return{
                getAll: function() {
                    return $http.get("/orders/getall");
                },
                getById: function(id) {
                    return $http.get("/orders/getbyid/" + id);
                },
                saveOrder: function(order) {
                    return $http.post("/orders/add/", order);
                },
                updateOrder: function(order) {
                    return $http.post("/orders/update/", order);
                },
                deleteOrder: function (order) {
                    return $http.post("/orders/delete/", order);
                },
                getOrdersOnPage:function(page, items) {
                    return $http.get("/orders/getorderonpage/?" + "page=" + page + "&" + "items=" + items);
                },
                countOrders:function() {
                    return $http.get("/orders/count");
                }
        }
        }
    ]);