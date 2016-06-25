var validationMessageTmpl = kendo.template('<div class="k-widget k-tooltip k-tooltip-validation k-invalid-msg field-validation-error" style="margin: 0.5em; display: block; " data-for="#=field#" data-valmsg-for="#=field#" id="#=field#_validationMessage"><span class="k-icon k-warning"> </span>#=message#<div class="k-callout k-callout-n"></div></div>');

function showGridError(args, gridId) {
    if (args.errors) {
        var grid = $("#" + gridId).data("kendoGrid");
        grid.one("dataBinding", function (e) {
            e.preventDefault(); // cancel grid rebind if error occurs

            var messageContainter = $("#message");

            for (var error in args.errors) {
                if (grid.editable != undefined) {
                    showMessage(grid.editable.element, error, args.errors[error].errors);
                } else {
                    messageContainter.removeAttr('class');
                    messageContainter.addClass("warning");
                    messageContainter.text(args.errors[error].errors);

                    messageContainter.hide();
                    messageContainter.show("slow");
                }
            }
        });
    }
}

function showMessage(container, name, errors) {
    //add the validation message to the form
    container.find("[data-valmsg-for=" + name + "],[data-val-msg-for=" + name + "]").replaceWith(validationMessageTmpl({ field: name, message: errors[0] }));
}