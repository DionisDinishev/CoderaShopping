app.factory("orderProductsService",
    [
        "$http", function($http) {
            return{
                getAll: function() {
                    return $http.get("/orderProducts/GetAllOrders");
                },
                getById: function(id) {
                    return $http.get("/orderProducts/getbyid/" + id);
                },
                saveOrder: function (orderProduct) {
                    return $http.post("/orderproducts/add/", orderProduct);
                },
                updateOrder: function(order) {
                    return $http.post("/orderProducts/update/", order);
                },
                deleteOrder: function (order) {
                    return $http.post("/orderProducts/delete/", order);
                },
                generateGUID:function() {
                    return $http.get("/orderProducts/generateGuid");
                },
                searchOrderByUserName: function (userName) {
                    debugger;
                    return $http.get("/orderProducts/SearchOrderByUserName?userName=" + userName);
                },
                getOrdersCount: function() {
                    return $http.get("/orderProducts/getOrdersCount");
                },
                getOrdersOnPage: function(page, size) {
                    return $http.get("/orderProducts/getOrdersOnPage/?page=" + page + "&size=" + size);
                }
            }
        }
    ]);