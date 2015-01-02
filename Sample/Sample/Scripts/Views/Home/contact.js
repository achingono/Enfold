/// <reference path="../../jquery-1.10.2.js" />
/// <reference path="../default.js" />

(function (app, $) {
    /// <summary>Defines methods that apply to user interface components</summary>
    /// <param name="app" type="PlainObject">The root namespace</param>
    /// <param name="$" type="Object">The jQuery object</param>

    // define settings for this view
    app.settings.contact = {
        selector: "address",
        borderWidth: '1px',
        borderStyle: 'solid',
    };

    // executed when the document is ready
    $(function () {
        // startup code goes here
        $(app.settings.contact.selector).each(function (index, element) {

            // set the background color of each item based on settings
            $(element).css({
                'border-color': app.settings.colors[index + 1],
                'border-width': app.settings.contact.borderWidth,
                'border-style': app.settings.contact.borderStyle,
                padding: '5px'
            });
        });
    });

}(window.application, jQuery));