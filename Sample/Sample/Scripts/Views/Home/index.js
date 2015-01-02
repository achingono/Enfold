/// <reference path="../../jquery-1.10.2.js" />
/// <reference path="../default.js" />

(function (app, $) {
    /// <summary>Defines methods that apply to user interface components</summary>
    /// <param name="app" type="PlainObject">The root namespace</param>
    /// <param name="$" type="Object">The jQuery object</param>

    // define settings for this view
    app.settings.home = {
        selector: ".row > .col-md-4"
    };

    // executed when the document is ready
    $(function () {
        // startup code goes here
        $(app.settings.home.selector).each(function (index, element) {

            // set the background color of each item based on settings
            $(element).css({ 'background-color': app.settings.colors[index] });
        });
    });

}(window.application, jQuery));