﻿var clickCount = 0;
function renderPaginationIcon() {
    $(".sr-only").text('');
}
function renderjQueryComponents() {
    $("#accordion").accordion();
    $(".jquery-btn button").button();
    $(".jquery-btn button").click(function () {
        console.log('Clicked');
        $('.click-count')[0].innerText = ++clickCount;
    });
}