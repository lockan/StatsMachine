// GENERIC AVATAR DISPLAY FUNCTIONS

function renderUserAvatar() {
    // STUB - get user's stored avatar string and display that image. 
}

function renderAvatar(divTarget, avatar) {
    var imgpath = "/Content/Images/" + avatar + ".png";
    $('#' + divTarget).html("<img src='" + imgpath + "' />");
}