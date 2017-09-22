define([
    // dojo
    "dojo",
    "dojo/_base/array",
    "dojo/_base/declare",
    "dojo/_base/event",
    "dojo/_base/lang",
    "dojo/on",
    "dojo/when",

    // Dijit
    "dijit/form/Select",
    "dijit/_TemplatedMixin",
    "dijit/_Widget",

    // EPi
    //"epi",        
    //"epi/shell/widget/dialog/Dialog",
    //"epi-cms/widget/_HasChildDialogMixin",
    "epi/dependency",
    "epi/shell/widget/_ValueRequiredMixin",
    "epi/RequireModule!App",

    // Resources
    "dojo/text!./templates/GalleryViewTemplate.html"],
    function (
        //dojo
        dojo,
        array,
        declare,
        event,
        lang,
        on,
        when,
        //Dijit
        Select,
        _TemplatedMixin,
        _Widget,
        //epi
        //epi,        
        //Dialog,
        //_HasChildDialogMixin,
        dependency,
        _ValueRequiredMixin,
        appModule,
        //Resource
        template
    ) {
        return declare("highnet.editors.galleryViewTemplate", [_Widget, _TemplatedMixin, _ValueRequiredMixin], {
            // summary:
            //      Widget that wraps a SelectionEditor in a dialog.
            // tags:
            //      public
            actualValue: null,
            value: null,
            select: null,
            uiHint:null,
            templateString: template,
            postMixInProperties: function () {
                this.inherited(arguments);
                this.actualValue = this.value;
            },
            postCreate: function () {
                //debugger;
                this.inherited(arguments);
                if (this.select == null) {
                    this._initSelection();
                }                

            },

            _initSelection: function () {
                this.select = new Select({ name: "ddlChooseProperty" }, this.ddlChooseProperty);
                this.select.set("options", array.map(this.selections, function (item) {
                    return {
                        label: item.text,
                        value: item.value,
                        selected: (item.value == this.value) || (!item.value && !this.value)
                    };
                }, this.select));
                this.select.startup();
                this.connect(this.select, "onChange", this._onChangeTemplateLayout);               
            },

            _setValueAttr: function (value) {
                this._setValue(value);
            },

            _setValue: function (value) {
                if (value != undefined && value.length > 0) {
                    if (this.select == null) {
                        this._initSelection();
                    }
                    if (this.select) {
                        this.select.setAttribute("value", value);

                    }

                    var registry = dependency.resolve("epi.storeregistry");
                    when(registry.get("highnet.galleryViewTemplate").query({
                        templateId: value,
                        uiHint: this.uiHint

                    }), lang.hitch(this, function (response) {
                        dojo.html.set(this.divPreviewTemplateLayout, response);
                    }));

                    dojo.style(this.divPreviewTemplateLayout, "display", "block");
                } else {
                    dojo.style(this.divPreviewTemplateLayout, "display", "none");
                }

                //Trigger automatically saving
                this.value = value;
                this._set("value", value);
                if (this.validate()) {
                    this.onChange(value);
                }
            },
            onChange: function (value) {

            },
            _onChangeTemplateLayout: function (value) {

                this._setValue(value);
            },


            isValid: function () {
                // summary:
                //    Check if widget's value is valid.
                // tags:
                //    protected, override

                return !this.required || this.value.length > 0;
            },
        });
    });
