$(document).ready(function () {
    $('.tooltipped').tooltip();
    $('.dropdown-trigger').dropdown();/*
    $('.datepicker').datepicker({
        
    });*/
    $('select').formSelect();
    $('i.btn-large').click(function (e) {$(this).children()[0].click() });
});