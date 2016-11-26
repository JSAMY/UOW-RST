
$(document).ready(function () {
    
    $.validator.addMethod("alpha", function (value, element) {
        var alpha = /^[a-zA-Z\s-, ]+$/;
        return this.optional(element) || value == value.match(/^[a-zA-Z\s]+$/);
    }, function (params, element) {
        return 'Invalid input'
    });

});