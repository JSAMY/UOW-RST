
$(document).ready(function () {
    var errorMessage = "Invalid input";
    $.validator.addMethod("alpha", function (value, element) {
        return this.optional(element) || value == value.match(/^[a-zA-Z\s]+$/);
    });

});