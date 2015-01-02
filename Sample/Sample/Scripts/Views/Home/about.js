/// <reference path="../../jquery-1.10.2.js" />
/// <reference path="../default.js" />

(function (app, $) {
    /// <summary>Defines methods that apply to user interface components</summary>
    /// <param name="app" type="PlainObject">The root namespace</param>
    /// <param name="$" type="Object">The jQuery object</param>

    // define settings for this view
    app.settings.about = {
        selector: "h2,h3",
    };

    // executed when the document is ready
    $(function () {
        // startup code goes here
        $(app.settings.about.selector).each(function (index, element) {

            // set the color of each item based on settings
            $(element).css({ color: app.settings.colors[index] });
        });
    });

}(window.application, jQuery));