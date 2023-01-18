﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#table-principal').DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {         //tradução da tabela com Jquery
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": " _START_ até _END_ de _TOTAL_ ",
            "sInfoEmpty": " 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total )",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ registros por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
});


$('.close-alert').click(function () {
    $('.alert').hide('hide');
});
