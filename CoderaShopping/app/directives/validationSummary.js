"use strict";
app.directive("validationSummary",
    function() {
        return {
            restrict: "E",
            scope: {
                errors: "=errors"
            },
            templateUrl: "/app/directives/validationSummary.html"


        }
    });
