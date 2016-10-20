$(document).ready(function () {
    var avatar = $('#data_avatar').data('value');
    console.log("Main -> avatar = " + avatar);
    renderAvatar("userAvatar", avatar);
});