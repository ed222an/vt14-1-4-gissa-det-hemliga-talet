"use strict";

var Page = {

    init: function (e) {

        // Sätter fokus på textfältet när sidan laddar.
        document.getElementById("InputTextBox").focus();
        $("InputTextBox").select();
    }
}

window.onload = Page.init;