
function SelectMenu(id) {
    $(".sidebar-menu li").removeClass("active");
    $("#" + id).addClass("active");
}
