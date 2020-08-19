$(function () {
   
    lista.load_lista();

});

var data;
lista = {

    load_lista: function () {

        var source = $("#templateEntidadeItem").html();
        var template = Handlebars.compile(source);

        var sourceFirst = $("#templateEntidadeItemFirst").html();
        var templateFirst = Handlebars.compile(source);

        //Busca lista de entidades
        
        BuscaAjax("teste");

        function BuscaAjax(str) {
            $.ajax({
                url: "/entidades/listaEntidade",
                type: "get",
                dataType: "json",
                async: false,

                success: function (data1) {
                    /* aqui coloca o OBJ dentro da variavel publica*/
                    data = data1;
                }

            });
        }

        $("#templateEntidade").append(template(data));

        $("#entidadeNome").html('<h1 class="page-title"><i class="far fa-building text-muted mr-2"></i>' + data[0].entidadeSigla + '</h1>' +
                                '<p class="text-muted">' + data[0].entidadeRazaoSocial + ',' + data[0].entidadeCidade + '</p>');

        $("#entidadeEndereco").html('<div class="d-flex justify-content-between align-items-center">' +
            '<h2 id="entidade-billing-Pessoa-tab" class="card-title"> Endere&ccedilo </h2><button type = "button" class="btn btn-sm btn-icon btn-secondary edit" data-toggle="modal"><i class="fa fa-pencil-alt" onclick="editEntidade(' + data[0].entidadeId + ');return false"></i> <span class="sr-only">Edit</span></button >'+
        '</div>'+
            '<address> ' + data[0].entidadeLogradouro + ',' + data[0].entidadeBairro + '<br>' + data[0].entidadeCidade + ' ' + data[0].entidadeCEP + '<br>' + data[0].entidadePais + '</address>')

        $("#AdicionaPessoa").html('<a  href="" class="card-footer-item create" data-toggle="modal" onclick="createPessoa(' + data[0].entidadeId + ');return false"><i class="fa fa-plus-circle mr-1"></i> Adiciona Pessoas </a>');


          table = $('#lstPessoa').DataTable({
                dom: 'Brtip',
                buttons: ['copyHtml5', {
                    extend: 'print',
                    autoPrint: false
                }],
                language: {
                    paginate: {
                        previous: '<i class="fa fa-lg fa-angle-left"></i>',
                        next: '<i class="fa fa-lg fa-angle-right"></i>'
                    }
                },
                autoWidth: false,
                ajax: {
                    "url": "/pessoas/listaPessoa/" + data[0].entidadeId,
                    "type": "GET",
                    "dataType": "json",
                    "dataSrc": ""
                },
                deferRender: true,
                order: [1, 'asc'],
                columns: [{
                    data: 'pessoaFoto',
                    className: 'align-middle'
                }, {
                    data: 'pessoaNome',
                    className: 'align-middle'
                }, {
                    data: 'pessoaEmail',
                    className: 'align-middle'
                }, {
                    data: 'pessoaFone',
                    className: 'align-middle'
                }, {
                    data: 'pessoaEspecialidade',
                    className: 'align-middle'
                }, {
                    data: 'pessoaFormacao',
                    className: 'align-middle'
                }, {
                    data: 'actions',
                    className: 'align-middle text-right',
                    orderable: false,
                    searchable: false
                }],
                columnDefs: [
                    //{
                    //    targets: 0,
                    //    render: function render(data, type, row, meta) {
                    //        return "<a href=\"#".concat(row.tipoId, "\" class=\"tile tile-img mr-1\">\n            <img class=\"img-fluid\" src=\"assets/images/dummy/img-").concat(row.img, ".jpg\" alt=\"Card image cap\">\n          </a>\n          <a href=\"#").concat(row.tipoId, "\">").concat(row.tipoNome, "</a>");
                    //    }
                    //},
                    {
                        targets: 6,
                        render: function render(data, type, row, meta) {
                            return '<button type="button" class="btn btn-sm btn-icon btn-secondary edit" data-toggle="modal" data-id=' + row.pessoaId + '><i class= "fa fa-pencil-alt" onclick="editPessoa(' + row.pessoaId + ');return false"></i > <span class="sr-only">Edit</span></button>' +
                                '<button type="button" class="btn btn-sm btn-icon btn-secondary delete" data-toggle="modal" data-id=' + row.pessoaId + '><i class="far fa-trash-alt" onclick="deletePessoa(' + row.pessoaId + ');return false"></i> <span class="sr-only">Remove</span></button>'
                        }
                    }]
          });

        table2 = $('#lstProjeto').DataTable({
            dom: 'Brtip',
            buttons: ['copyHtml5', {
                extend: 'print',
                autoPrint: false
            }],
            language: {
                paginate: {
                    previous: '<i class="fa fa-lg fa-angle-left"></i>',
                    next: '<i class="fa fa-lg fa-angle-right"></i>'
                }
            },
            autoWidth: false,
            ajax: {
                "url": "/projetos/listaProjeto2/" + data[0].entidadeId,
                "type": "GET",
                "dataType": "json",
                "dataSrc": ""
            },
            deferRender: true,
            order: [1, 'asc'],
            columns: [{
                data: 'projetoNome',
                className: 'align-middle'
            }, {
                    data: 'projetoData',
                className: 'align-middle'
            }, {
                    data: 'projetoDataIni',
                className: 'align-middle'
            }, {
                    data: 'projetoDataFim',
                className: 'align-middle'
            }, {
                    data: 'projetoGestora',
                className: 'align-middle'
            }, {
                    data: 'projetoEntidades',
                className: 'align-middle'
            }, {
                data: 'actions',
                className: 'align-middle text-right',
                orderable: false,
                searchable: false
            }],
            columnDefs: [
                //{
                //    targets: 0,
                //    render: function render(data, type, row, meta) {
                //        return "<a href=\"#".concat(row.tipoId, "\" class=\"tile tile-img mr-1\">\n            <img class=\"img-fluid\" src=\"assets/images/dummy/img-").concat(row.img, ".jpg\" alt=\"Card image cap\">\n          </a>\n          <a href=\"#").concat(row.tipoId, "\">").concat(row.tipoNome, "</a>");
                //    }
                //},
                {
                    targets: 6,
                    render: function render(data, type, row, meta) {
                        return '<button type="button" class="btn btn-sm btn-icon btn-secondary edit" data-toggle="modal" data-id=' + row.pessoaId + '><i class= "fa fa-pencil-alt" onclick="editPessoa(' + row.pessoaId + ');return false"></i > <span class="sr-only">Edit</span></button>' +
                            '<button type="button" class="btn btn-sm btn-icon btn-secondary delete" data-toggle="modal" data-id=' + row.pessoaId + '><i class="far fa-trash-alt" onclick="deletePessoa(' + row.pessoaId + ');return false"></i> <span class="sr-only">Remove</span></button>'
                    }
                }]
        });


    }
}

function selecionaEntidade(id) {

    $("#entidadeNome").html('<h1 class="page-title"><i class="far fa-building text-muted mr-2"></i>' + data[id].entidadeSigla + '</h1>' +
        '<p class="text-muted">' + data[id].entidadeRazaoSocial + ',' + data[id].entidadeCidade + '</p>');

    $("#entidadeEndereco").html('<div class="d-flex justify-content-between align-items-center">' +
        '<h2 id="entidade-billing-Pessoa-tab" class="card-title"> Endere&ccedilo </h2><button type = "button" class="btn btn-sm btn-icon btn-secondary edit" data-toggle="modal"><i class="fa fa-pencil-alt" onclick="editEntidade(' + data[id].entidadeId + ');return false"></i> <span class="sr-only">Edit</span></button >' +
        '</div>' +
        '<address> ' + data[id].entidadeLogradouro + ',' + data[id].entidadeBairro + '<br>' + data[id].entidadeCidade + ' ' + data[id].entidadeCEP + '<br>' + data[id].entidadePais + '</address>')

    $("#AdicionaPessoa").html('<a  href="" class="card-footer-item create" data-toggle="modal" onclick="createPessoa(' + data[id].entidadeId + ');return false"><i class="fa fa-plus-circle mr-1"></i> Adiciona Pessoas </a>');

    table.destroy();
    table2.destroy();

    table = $('#lstPessoa').DataTable({
        dom: 'Brtip',
        buttons: ['copyHtml5', {
            extend: 'print',
            autoPrint: false
        }],
        language: {
            paginate: {
                previous: '<i class="fa fa-lg fa-angle-left"></i>',
                next: '<i class="fa fa-lg fa-angle-right"></i>'
            }
        },
        autoWidth: false,
        ajax: {
            "url": "/pessoas/listaPessoa/" + data[id].entidadeId,
            "type": "GET",
            "dataType": "json",
            "dataSrc": ""
        },
        deferRender: true,
        order: [1, 'asc'],
        columns: [{
            data: 'pessoaFoto',
            className: 'align-middle'
        }, {
            data: 'pessoaNome',
            className: 'align-middle'
        }, {
            data: 'pessoaEmail',
            className: 'align-middle'
        }, {
            data: 'pessoaFone',
            className: 'align-middle'
        }, {
            data: 'pessoaEspecialidade',
            className: 'align-middle'
        }, {
            data: 'pessoaFormacao',
            className: 'align-middle'
        }, {
            data: 'actions',
            className: 'align-middle text-right',
            orderable: false,
            searchable: false
        }],
        columnDefs: [
            //{
            //    targets: 0,
            //    render: function render(data, type, row, meta) {
            //        return "<a href=\"#".concat(row.tipoId, "\" class=\"tile tile-img mr-1\">\n            <img class=\"img-fluid\" src=\"assets/images/dummy/img-").concat(row.img, ".jpg\" alt=\"Card image cap\">\n          </a>\n          <a href=\"#").concat(row.tipoId, "\">").concat(row.tipoNome, "</a>");
            //    }
            //},
            {
                targets: 6,
                render: function render(data, type, row, meta) {
                    return '<button type="button" class="btn btn-sm btn-icon btn-secondary edit" data-toggle="modal" data-id=' + row.pessoaId + '><i class= "fa fa-pencil-alt" onclick="editPessoa(' + row.pessoaId + ');return false"></i > <span class="sr-only">Edit</span></button>' +
                        '<button type="button" class="btn btn-sm btn-icon btn-secondary delete" data-toggle="modal" data-id=' + row.pessoaId + '><i class="far fa-trash-alt" onclick="deletePessoa(' + row.pessoaId + ');return false"></i> <span class="sr-only">Remove</span></button>'
                }
            }]
    });

    table2 = $('#lstProjeto').DataTable({
        dom: 'Brtip',
        buttons: ['copyHtml5', {
            extend: 'print',
            autoPrint: false
        }],
        language: {
            paginate: {
                previous: '<i class="fa fa-lg fa-angle-left"></i>',
                next: '<i class="fa fa-lg fa-angle-right"></i>'
            }
        },
        autoWidth: false,
        ajax: {
            "url": "/projetos/listaProjeto2/" + data[id].entidadeId,
            "type": "GET",
            "dataType": "json",
            "dataSrc": ""
        },
        deferRender: true,
        order: [1, 'asc'],
        columns: [{
            data: 'projetoNome',
            className: 'align-middle'
        }, {
            data: 'projetoData',
            className: 'align-middle'
        }, {
            data: 'projetoDataIni',
            className: 'align-middle'
        }, {
            data: 'projetoDataFim',
            className: 'align-middle'
        }, {
            data: 'projetoGestora',
            className: 'align-middle'
        }, {
            data: 'projetoEntidades',
            className: 'align-middle'
        }, {
            data: 'actions',
            className: 'align-middle text-right',
            orderable: false,
            searchable: false
        }],
        columnDefs: [
            //{
            //    targets: 0,
            //    render: function render(data, type, row, meta) {
            //        return "<a href=\"#".concat(row.tipoId, "\" class=\"tile tile-img mr-1\">\n            <img class=\"img-fluid\" src=\"assets/images/dummy/img-").concat(row.img, ".jpg\" alt=\"Card image cap\">\n          </a>\n          <a href=\"#").concat(row.tipoId, "\">").concat(row.tipoNome, "</a>");
            //    }
            //},
            {
                targets: 6,
                render: function render(data, type, row, meta) {
                    return '<button type="button" class="btn btn-sm btn-icon btn-secondary edit" data-toggle="modal" data-id=' + row.pessoaId + '><i class= "fa fa-pencil-alt" onclick="editPessoa(' + row.pessoaId + ');return false"></i > <span class="sr-only">Edit</span></button>' +
                        '<button type="button" class="btn btn-sm btn-icon btn-secondary delete" data-toggle="modal" data-id=' + row.pessoaId + '><i class="far fa-trash-alt" onclick="deletePessoa(' + row.pessoaId + ');return false"></i> <span class="sr-only">Remove</span></button>'
                }
            }]
    });


}

function editEntidade(id) {
    $("#entidadeNewModal").load("/entidades/Edit?id=" + id, function () {
        $("#entidadeNewModal").modal();
    })
 }

function deleteEntidade(id) {
    $("#entidadeNewModal").load("Delete?id=" + id, function () {
        $("#entidadeNewModal").modal();
    })
}
function createEntidade() {
        $("#entidadeNewModal").load("/entidades/Create", function () {
            $("#entidadeNewModal").modal();
        })
}

function editPessoa(id) {
    $("#entidadePessoaEditModal").load("/pessoas/Edit?id=" + id, function () {
        $("#entidadePessoaEditModal").modal();
        })
}

function deletePessoa(id) {
    $("#entidadePessoaEditModal").load("/pessoas/Delete?id=" + id, function () {
        $("#entidadePessoaEditModal").modal();
        })
}

function createPessoa(id) {
    $("#entidadePessoaEditModal").load("/pessoas/Create?id=" + id, function () {
        $("#entidadePessoaEditModal").modal();
        })
}