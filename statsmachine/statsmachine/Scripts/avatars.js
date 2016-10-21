// GENERIC AVATAR DISPLAY FUNCTIONS

function renderUserAvatar() {
    // STUB - get user's stored avatar string and display that image. 
}

// This has been replaced by Viewbag and/or Session variables and a helper function to get the image path. 
// Probably won't need this anymore. 
function renderAvatar(divTarget, avatar) {
    var imgpath = "/Content/Images/" + avatar + ".png";
    $('#' + divTarget).html("<img src='" + imgpath + "' />");
}