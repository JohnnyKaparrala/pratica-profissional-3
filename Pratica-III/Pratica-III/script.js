$(document).ready(function () {
    $('.tooltipped').tooltip();
    $('.dropdown-trigger').dropdown();
    $('.datepicker').datepicker({
        i18n: {
            months: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
            monthsShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
            weekdays: ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"],
            weekdaysShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Quin', 'Sex', 'Sab'],
            weekdaysAbbrev: ["D", "S", "T", "Q", "Q", "S", "S"],
            cancel:'Cancelar',
            clear:'Limpar',
            done:'Ok'
        },
        format: 'yyyy-dd-mm',
        yearRange: 100
    });
    $('select').formSelect();
});