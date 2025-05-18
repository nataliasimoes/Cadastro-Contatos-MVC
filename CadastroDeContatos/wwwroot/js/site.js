// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    // Verifica se a tabela existe na página
    if ($('#table-contatos').length) {
        // Inicializa o DataTable apenas uma vez com todas as configurações
        $('#table-contatos').DataTable({
            language: {
                "decimal": ",",
                "thousands": ".",
                "processing": "Processando...",
                "lengthMenu": "_MENU_ Registros por página",
                "zeroRecords": "Nenhum registro encontrado",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ registros",
                "infoEmpty": "Mostrando 0 a 0 de 0 registros",
                "infoFiltered": "(filtrado de _MAX_ registros no total)",
                "search": "Pesquisar: ",
                "paginate": {
                    "first": "Primeiro",
                    "last": "Último",
                    "next": "Próximo",
                    "previous": "Anterior"
                },
                "aria": {
                    "sortAscending": ": ativar para ordenar coluna em ordem crescente",
                    "sortDescending": ": ativar para ordenar coluna em ordem decrescente"
                }
            },
            layout: {
                bottomEnd: {
                    paging: {
                        firstLast: false
                    }
                }
            },
            info: false,
            columnDefs: [
                {
                    target: 3, 
                    orderable: false 
                },
                {
                    target: 4,
                    orderable: false
                }
            ]
        });
    }
});