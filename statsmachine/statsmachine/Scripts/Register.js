// REGISTRATION PAGE FUNCTIONS
$(document).ready(function () {
    var selectedfaction = $('#avatarchoice option:selected').text().toLowerCase();
    setAvatarChoice(selectedfaction);
});

$('#avatarchoice').change(function () {
    var selectedfaction = $('#avatarchoice option:selected').text().toLowerCase();
    setAvatarChoice(selectedfaction);
});

function setAvatarChoice(selectedfaction) {
    var imgpath = "/Content/Images/" + selectedfaction + ".png";
    $('#avatar').html("<img src='" + imgpath + "' />");
};