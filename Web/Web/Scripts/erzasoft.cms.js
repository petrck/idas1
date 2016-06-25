$(function () {
    var cmsModel = new kendo.observable({
        newOrganizationItem: {
            title: "",
            tooltip: "",
        },

        editOrganizationItem: {
            title: "",
            tooltip: ""
        },

        newLink: {
            title: "",
            tooltip: "",
            href: ""
        },

        editLink: {
            title: "",
            tooltip: "",
            href: ""
        },

        newRouteLink: {
            title: "",
            tooltip: "",
            route: ""
        },

        editRouteLink: {
            title: "",
            tooltip: "",
            route: ""
        },

        newPage: {
            Name: ""
        },

        editPageItem: {
            title: "",
            tooltip: ""
        },

        seoData: {
            
        },

        createOrganizationItem: function() {
            var validator = $("#erzasoft-cms-add-organization-item-validator").data("kendoValidator");
            if (!validator.validate()) {
                return;
            }

            var treeDestination = $("#erzasoft-cms-menu-tree").data("kendoTreeView");
            
            var newOrganizationItem = {
                Id: 0,
                Title: this.get("newOrganizationItem.title"),
                Tooltip: this.get("newOrganizationItem.tooltip"),
                Editable: true,
                Type: "organizationitem"
            }

            var select = treeDestination.select();
            if (select.length > 0) {
                treeDestination.append(newOrganizationItem, select);
            } else {
                treeDestination.append(newOrganizationItem);
            }
            

            this.set("newOrganizationItem.title", "");
            this.set("newOrganizationItem.tooltip", "");

            var window = $("#erzasoft-cms-add-organization-item-window").data("kendoWindow");
            window.close();
        },

        createLink: function() {
            var validator = $("#erzasoft-cms-add-link-validator").data("kendoValidator");
            if (!validator.validate()) {
                return;
            }

            var treeDestination = $("#erzasoft-cms-menu-tree").data("kendoTreeView");

            var newLink = {
                Id: 0,
                Title: this.get("newLink.title"),
                Tooltip: this.get("newLink.tooltip"),
                Href: this.get("newLink.href"),
                Editable: true,
                Type: "link"
            }

            var select = treeDestination.select();
            if (select.length > 0) {
                treeDestination.append(newLink, select);
            } else {
                treeDestination.append(newLink);
            }

            this.set("newLink.title", "");
            this.set("newLink.tooltip", "");
            this.set("newLink.href", "");

            var window = $("#erzasoft-cms-add-link-window").data("kendoWindow");
            window.close();
        },

        createRouteLink: function() {
            var validator = $("#erzasoft-cms-add-route-link-validator").data("kendoValidator");
            if (!validator.validate()) {
                return;
            }

            var treeDestination = $("#erzasoft-cms-menu-tree").data("kendoTreeView");

            var newRouteLink = {
                Id: 0,
                Title: this.get("newRouteLink.title"),
                Tooltip: this.get("newRouteLink.tooltip"),
                Route: this.get("newRouteLink.route"),
                Editable: true,
                Type: "routelink"
            }

            var select = treeDestination.select();
            if (select.length > 0) {
                treeDestination.append(newRouteLink, select);
            } else {
                treeDestination.append(newRouteLink);
            }

            this.set("newRouteLink.title", "");
            this.set("newRouteLink.tooltip", "");
            this.set("newRouteLink.route", "");

            var window = $("#erzasoft-cms-add-route-link-window").data("kendoWindow");
            window.close();
        },

        addPageClick: function () {
            this.set("newPage.Name", "");

            var window = $("#erzasoft-cms-add-page-window").data("kendoWindow");
            window.center();
            window.open();
        },

        addMenuItem: function (e) {
            var window = null;
            if (e.id === "addOrganizationItem" || e.id === "addOrganizationItem_overflow") {
                this.set("newOrganizationItem.title", "");
                this.set("newOrganizationItem.tooltip", "");

                window = $("#erzasoft-cms-add-organization-item-window").data("kendoWindow");
            } else if (e.id === "addLink" || e.id === "addLink_overflow") {
                this.set("newLink.title", "");
                this.set("newLink.tooltip", "");
                this.set("newLink.href", "");

                window = $("#erzasoft-cms-add-link-window").data("kendoWindow");
            } else if (e.id === "addRouteLink" || e.id === "addRouteLink_overflow") {
                this.set("newRouteLink.title", "");
                this.set("newRouteLink.tooltip", "");
                this.set("newRouteLink.route", "");

                window = $("#erzasoft-cms-add-route-link-window").data("kendoWindow");
            }

            if (window != null) {
                window.center();
                window.open();
            }
        },

        editMenuItem: function(item) {
            if (item.Type === "organizationitem") {
                this.set("editOrganizationItem.title", item.Title);
                this.set("editOrganizationItem.tooltip", item.Tooltip);

                var window = $("#erzasoft-cms-edit-organization-item-window").data("kendoWindow");
                window.center();
                window.open();
                return;
            }

            if (item.Type === "link") {
                this.set("editLink.title", item.Title);
                this.set("editLink.tooltip", item.Tooltip);
                this.set("editLink.href", item.Href);

                var window = $("#erzasoft-cms-edit-link-window").data("kendoWindow");
                window.center();
                window.open();
                return;
            }

            if (item.Type === "routelink") {
                this.set("editRouteLink.title", item.Title);
                this.set("editRouteLink.tooltip", item.Tooltip);
                this.set("editRouteLink.route", item.Route);

                var window = $("#erzasoft-cms-edit-route-link-window").data("kendoWindow");
                window.center();
                window.open();
                return;
            }

            if (item.Type === "page") {
                this.set("editPageItem.title", item.Title);
                this.set("editPageItem.tooltip", item.Tooltip);

                var window = $("#erzasoft-cms-edit-page-window").data("kendoWindow");
                window.center();
                window.open();
                return;
            }
        },

        editOrganizationItemSave: function () {
            var validator = $("#erzasoft-cms-edit-organization-item-validator").data("kendoValidator");
            if (!validator.validate()) {
                return;
            }

            var treeview = $("#erzasoft-cms-menu-tree").data("kendoTreeView");
            var item = treeview.select();
            var itemdata = treeview.dataItem(item);

            itemdata.set("Title", this.get("editOrganizationItem.title"));
            itemdata.set("Tooltip", this.get("editOrganizationItem.tooltip"));

            var window = $("#erzasoft-cms-edit-organization-item-window").data("kendoWindow");
            window.close();
        },

        editLinkSave: function() {
            var validator = $("#erzasoft-cms-edit-link-validator").data("kendoValidator");
            if (!validator.validate()) {
                return;
            }

            var treeview = $("#erzasoft-cms-menu-tree").data("kendoTreeView");
            var item = treeview.select();
            var itemdata = treeview.dataItem(item);

            itemdata.set("Title", this.get("editLink.title"));
            itemdata.set("Tooltip", this.get("editLink.tooltip"));
            itemdata.set("Href", this.get("editLink.href"));

            var window = $("#erzasoft-cms-edit-link-window").data("kendoWindow");
            window.close();
        },

        editRouteLinkSave: function() {
            var validator = $("#erzasoft-cms-edit-route-link-validator").data("kendoValidator");
            if (!validator.validate()) {
                return;
            }

            var treeview = $("#erzasoft-cms-menu-tree").data("kendoTreeView");
            var item = treeview.select();
            var itemdata = treeview.dataItem(item);

            itemdata.set("Title", this.get("editRouteLink.title"));
            itemdata.set("Tooltip", this.get("editRouteLink.tooltip"));
            itemdata.set("Route", this.get("editRouteLink.route"));

            var window = $("#erzasoft-cms-edit-route-link-window").data("kendoWindow");
            window.close();
        },

        editPageSave: function() {
            var validator = $("#erzasoft-cms-edit-page-validator").data("kendoValidator");
            if (!validator.validate()) {
                return;
            }

            var treeview = $("#erzasoft-cms-menu-tree").data("kendoTreeView");
            var item = treeview.select();
            var itemdata = treeview.dataItem(item);

            itemdata.set("Title", this.get("editPageItem.title"));
            itemdata.set("Tooltip", this.get("editPageItem.tooltip"));

            var window = $("#erzasoft-cms-edit-page-window").data("kendoWindow");
            window.close();
        },

        addPageSave: function () {
            var validator = $("#erzasoft-cms-add-page-validator").data("kendoValidator");
            if (!validator.validate()) {
                return;
            }

            var page = this.get("newPage").toJSON();

            $.ajax({
                type: "POST",
                url: window.cmscreatepageurl,
                contentType: "application/json; charset=utf-8",
                data: kendo.stringify(page),
                dataType: "json",
            }).done(function(data) {
                window.location = data.PageUrl;
            });
        },

        savePageContent: function () {
            var sendData = new Array();
            $(".erzasoft-cms-editable-content").each(function (indexed, element) {
                var $element = $(element);
                var contentData = {
                    Content: $element.data("kendoEditor").value(),
                    Key: $element.data("erzasoftCmsKey"),
                    SubKey: $element.data("erzasoftCmsSubKey")
                };

                sendData.push(contentData);
            });

            $.ajax({
                type: "POST",
                url: window.cmssavepagecontenturl,
                contentType: "application/json; charset=utf-8",
                data: kendo.stringify(sendData)
                //dataType: "json",
            }).done(function () {
                $("#cms-message").data("kendoNotification").show("Data úspěšně uložena.", "success");
            });

            this.saveSeoData();
        },

        closeCreateOrganizationItem: function () {
            var window = $("#erzasoft-cms-add-organization-item-window").data("kendoWindow");
            window.close();
        },

        closeEditOrganizationItem: function() {
            var window = $("#erzasoft-cms-edit-organization-item-window").data("kendoWindow");
            window.close();
        },

        closeCreateLink: function() {
            var window = $("#erzasoft-cms-add-link-window").data("kendoWindow");
            window.close();
        },

        closeEditLink: function() {
            var window = $("#erzasoft-cms-edit-link-window").data("kendoWindow");
            window.close();
        },

        closeCreateRouteLink: function() {
            var window = $("#erzasoft-cms-add-route-link-window").data("kendoWindow");
            window.close();
        },

        closeEditRouteLink: function() {
            var window = $("#erzasoft-cms-edit-route-link-window").data("kendoWindow");
            window.close();
        },

        closeAddPage: function() {
            var window = $("#erzasoft-cms-add-page-window").data("kendoWindow");
            window.close();
        },

        closeEditPage: function() {
            var window = $("#erzasoft-cms-edit-page-window").data("kendoWindow");
            window.close();
        },

        dropNewPage: function(e) {
            e.preventDefault();

            var treeSource = $("#erzasoft-cms-pages-tree").data("kendoTreeView");
            var treeDestination = $("#erzasoft-cms-menu-tree").data("kendoTreeView");

            var pageItem = treeSource.dataItem(e.sourceNode);

            var newPage = {
                Title: pageItem.Name,
                Tooltip: pageItem.Name,
                Id: 0,
                Editable: true,
                PageId: pageItem.Id,
                Type: "page"
            }

            if (e.dropPosition === "over") {
                treeDestination.append(newPage, $(e.destinationNode));
            } else if (e.dropPosition === "before") {
                treeDestination.insertBefore(newPage, $(e.destinationNode));
            } else if (e.dropPosition === "after") {
                treeDestination.insertAfter(newPage, $(e.destinationNode));
            }
        },

        menuDragStart: function(e) {
            var treeview = $("#erzasoft-cms-menu-tree").data("kendoTreeView");
            var itemdata = treeview.dataItem(e.sourceNode);
            if (itemdata.Editable === false) {
                e.preventDefault();
            }
        },

        saveMenu: function() {
            var treeData = this.get("menuDatasource").data();
            var treeDataJson = treeData.toJSON();

            $.ajax({
                type: "POST",
                url: window.cmstreesaveurl,
                contentType: "application/json; charset=utf-8",
                data: kendo.stringify(treeDataJson)
                //dataType: "json"
            }).done(function () {
                $("#cms-message").data("kendoNotification").show("Data úspěšně uložena.", "success");
            });
        },

        loadSeoData: function () {
            var that = this;

            $.ajax({
                type: "POST",
                url: window.loadSeoDataUrl,
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).done(function(data) {
                that.set("seoData", data);
            });
        },

        saveSeoData: function () {
            var data = this.get("seoData").toJSON();
            debugger;

            $.ajax({
                type: "POST",
                url: window.saveSeoDataUrl,
                contentType: "application/json; charset=utf-8",
                data: kendo.stringify(data)
                //dataType: "json"
            }).done(function () {
                $("#cms-message").data("kendoNotification").show("Data úspěšně uložena.", "success");
            });
        },

        menuDatasource: new kendo.data.HierarchicalDataSource({
            transport: {
                read: {
                    url: window.cmstreereadurl,
                    dataType: "json",
                    method: "POST"
                }
            },
            schema: {
                model: {
                    id: "Id",
                    hasChildren: "HasChildren"
                }
            }
        }),

        pagesDatasource: new kendo.data.HierarchicalDataSource({
            transport: {
                read: {
                    url: window.cmsreadpagesurl,
                    dataType: "json",
                    method: "POST"
                }
            },
            schema: {
                model: {
                    id: "Id"
                }
            }
        })
    });

    kendo.bind($("#erzasoft-cms-managment"), cmsModel);
    $("#cms-window").data("kendoWindow")
        .minimize()
        .pin();
    $("#cms-window").parent(".k-window").css("top", 0);
    cmsModel.loadSeoData();

    $("#erzasoft-cms-menu-tree").on("click", ".delele-menu-item", function (e) {
        e.preventDefault();
        var that = this;

        setTimeout(function() {
            if (confirm("Opravdu smazat?")) {
                var treeview = $("#erzasoft-cms-menu-tree").data("kendoTreeView");
                treeview.remove($(that).closest(".k-item"));
            }
        }, 1);
    });

    $("#erzasoft-cms-menu-tree").on("click", ".edit-menu-item", function(e) {
        e.preventDefault();

        var treeview = $("#erzasoft-cms-menu-tree").data("kendoTreeView");
        var data = treeview.dataItem($(this).closest(".k-item"));

        cmsModel.editMenuItem(data);
    });

    $("#erzasoft-cms-pages-tree").on("click", ".delele-page-item", function (e) {
        e.preventDefault();
        var that = this;

        if (confirm("Opravdu smazat?")) {
            var treeview = $("#erzasoft-cms-pages-tree").data("kendoTreeView");
            var pageData = treeview.dataItem($(that).closest(".k-item")).toJSON();

            $.ajax({
                type: "POST",
                url: window.cmsdeletepageurl,
                contentType: "application/json; charset=utf-8",
                data: kendo.stringify({ id: pageData.Id }),
                dataType: "json"
            }).done(function() {
                treeview.remove($(that).closest(".k-item"));
            });
        }
       
    });

    function onPaste(e) {
        e.html = $(e.html).text();
    }

    $(".erzasoft-cms-editable-content").kendoEditor({
        tools: [
            "insertImage",
            "insertFile",
            "bold",
            "italic",
            "underline",
            "justifyLeft",
            "justifyCenter",
            "justifyRight",
            "justifyFull",
             "insertUnorderedList",
                "insertOrderedList",
                "indent",
                "outdent",
                "createLink",
                "unlink",
                "createTable",
                "addRowAbove",
                "addRowBelow",
                "addColumnLeft",
                "addColumnRight",
                "deleteRow",
                "deleteColumn",
                "viewHtml",
                "formatting",
                "cleanFormatting",
                
        ],
        imageBrowser: {
            messages: {
                dropFilesHere: "Drop files here"
            },
            transport: {
                type: "imagebrowser-aspnetmvc",
                read: erzasoftKendoEditorRead,
                destroy: {
                    url: erzasoftKendoEditorDestroy,
                    type: "POST"
                },
                create: {
                    url: erzasoftKendoEditorCreate,
                    type: "POST"
                },
                thumbnailUrl: erzasoftKendoEditorThumbnail,
                uploadUrl: erzasoftKendoEditorUpload,
                imageUrl: erzasoftKendoEditorImage + "{0}"
            }
        },
        fileBrowser: {
            messages: {
                dropFilesHere: "Drop files here"
            },
            transport: {
                type: "filebrowser-aspnetmvc",
                read: erzasoftKendoFileEditorRead,
                destroy: {
                    url: erzasoftKendoFileEditorDestroy,
                    type: "POST"
                },
                create: {
                    url: erzasoftKendoFileEditorCreate,
                    type: "POST"
                },
                uploadUrl: erzasoftKendoFileEditorUpload,
                fileUrl: erzasoftKendoEditorFile + "{0}"
            }
        },
        paste: onPaste
    });
});