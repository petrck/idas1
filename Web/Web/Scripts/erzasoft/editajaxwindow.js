function EditAjaxWindow(windowSelector, getUrl, gatdata) {
    var conditionWindow = $(windowSelector);
    var conditionWindowData = conditionWindow.data("kendoWindow");
    var clearSet = conditionWindow.data("clearSet");
    if (clearSet !== true) {
        conditionWindow.data("clearSet", true);
        conditionWindow.on("close", function () {
            conditionWindowData.content(" ");
        });
    }

    $.get(getUrl, gatdata)
        .done(function (data, textStatus, jqXHR) {
            var conditionWindow = $(windowSelector);
            var conditionWindowData = conditionWindow.data("kendoWindow");
            conditionWindowData.content(data);

            initializeForm(windowSelector);

            conditionWindowData.center().open();
        })
        .fail(function (data, status, textStatus) {
            alert(textStatus);
        });

    function initializeForm(windowSelector) {
        var conditionWindow = $(windowSelector);
        var conditionWindowData = conditionWindow.data("kendoWindow");
        $(".t-grid-update", conditionWindow).removeClass("ajaxWork");

        if ($(".closeWindowCommand", conditionWindow).length > 0) {
            conditionWindowData.close();
        }

        $(".t-grid-cancel", conditionWindow).on("click", function (event) {
            event.preventDefault();
            conditionWindowData.close();
        });

        $(".t-grid-update", conditionWindow).on("click", function (event) {
            event.preventDefault();
            $(event.target).addClass("ajaxWork");
            $("form", conditionWindow).trigger("submit");
        });

        $("[data-commandUrl]", conditionWindow).on("click", function (event) {
            event.preventDefault();
            var url = $(event.target).data("commandurl");
            $("form", conditionWindow).trigger("submit", url);
        });

        $.validator.unobtrusive.parse(windowSelector);
        var validator = $("form", conditionWindow).kendoValidator().data("kendoValidator");

        $("form", conditionWindow).on("submit", function (event, url) {
            event.preventDefault();
            var form = $(this);
            var validationInfo = form.data("unobtrusiveValidation");
            var valid = !validationInfo || !validationInfo.validate || validationInfo.validate();
            if (valid) {
                $(this).ajaxSubmit({
                    url: url,
                    success: function (data) {
                        conditionWindowData.content(data);
                        initializeForm(windowSelector);
                    },
                    error: function (data) {
                        alert("Chyba!");
                    }
                });
            }
        });
    }
}