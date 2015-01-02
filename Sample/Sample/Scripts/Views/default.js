/// <reference path="../jquery-1.10.2.js" />
/// <reference path="../knockout-3.0.0.debug.js" />

window.application = (function (app) {
    /// <summary>Defines methods that apply to user interface components</summary>
    /// <param name="app" type="PlainObject">The root namespace</param>
    /// <param name="$" type="Object">The jQuery object</param>
    /// <param name="ko" type="Object">The knockout binding engine</param>

    // if the global application object is NOT already initialized,
    // initialize it
    return app || {
        settings: {
            colors: ["#5cb85c", "#5bc0de", "#f0ad4e"]
        },
    };

}(window.application));