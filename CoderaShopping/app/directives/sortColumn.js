"use strict";

app.directive("sortColumn",function() {

    return {
        restrict: "E",
        scope: {
            sortOrder: "=",
            click: "&",
            asc: "=",
            name:"="
        },
        templateUrl:"/app/directives/sortColumn.html"

    }

})