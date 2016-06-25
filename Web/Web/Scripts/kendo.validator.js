function kendoValidate(formSelector) {
    $(formSelector).kendoValidator();
        
    $(formSelector + " .field-validation-error").each(function (index, element) {
        var $element = $(element);
        var message = $element.text();
        var forInput = $element.data("valmsgFor");
        var template = kendo.template("<span class='k-widget k-tooltip k-tooltip-validation k-invalid-msg field-validation-error' data-for='#= forInput #' data-val-msg-for='#= forInput #' id='#= forInput #_validationMessage' role='alert'><span class='k-icon k-warning'> </span> #= Message #</span>");
        var html = template({ Message: message, forInput: forInput });
        $element.replaceWith(html);
    });
}