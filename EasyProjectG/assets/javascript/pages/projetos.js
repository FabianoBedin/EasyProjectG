$(function () {
   
    lista.listaPessoas();

});
var data;

lista = {

    listaPessoas: function () {

        var source = $("#templateProjetoItem").html();
        var template = Handlebars.compile(source);

        var sourceFirst = $("#templateProjetoItemFirst").html();
        var templateFirst = Handlebars.compile(source);

        //Busca lista de projetos
        
        BuscaAjax("teste");

        function BuscaAjax(str) {
            $.ajax({
                url: "/projetos/listaProjeto",
                type: "get",
                dataType: "json",
                async: false,

                success: function (data1) {
                    /* aqui coloca o OBJ dentro da variavel publica*/
                    data = data1;
                }

            });
        }

        var projetoId = data[0].projetoId;

        $("#templateProjeto").append(template(data));

        $("#projetoNome").html('<h1 class="page-title"><i class="far fa-building text-muted mr-2"></i>' + data[0].projetoNome + '</h1>' +
            '<p class="text-muted">' + data[0].projetoObjetivo  + '</p>');

        $("#projetoResumo").html('<div class="d-flex justify-content-between align-items-center">' +
            '<h2 id="projeto-billing-pessoa-tab" class="card-title"> Endere&ccedilo </h2><button type = "button" class="btn btn-sm btn-icon btn-secondary edit" data-toggle="modal"><i class="fa fa-pencil-alt" onclick="editProjeto(' + data[0].projetoId + ');return false"></i> <span class="sr-only">Edit</span></button >'+
        '</div>'+
            '<address> ' + data[0].projetoObjetivo  +'</address>')

        table = $('#lstPessoas').DataTable({
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
                    "url": "/pessoas/listaTime/" + projetoId,
                    "type": "GET",
                    "dataType": "json",
                    "dataSrc": ""
                },
                deferRender: true,
                order: [1, 'asc'],
              columns: [{
                  data: 'pessoaNome',
                  className: 'align-middle'
              }, {
                  data: 'entidadeSigla',
                  className: 'align-middle'
              }, {
                  data: 'funcaoDescricao',
                  className: 'align-middle'
              }, {
                  data: 'projetoPessoaCustoHora',
                  className: 'align-middle'
              }, {
                  data: 'projetoPessoaQtdeHoraSemanal',
                  className: 'align-middle'
              }, {
                  data: 'projetoPessoaQtdeSemana',
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
                        targets: 7,
                        render: function render(data, type, row, meta) {
                            return '<button type="button" class="btn btn-sm btn-icon btn-secondary edit" data-toggle="modal" data-id=' + row.pessoaId + '><i class= "fa fa-pencil-alt" onclick="editPessoa(' + row.pessoaId + ');return false"></i > <span class="sr-only">Edit</span></button>' +
                                '<button type="button" class="btn btn-sm btn-icon btn-secondary delete" data-toggle="modal" data-id=' + row.pessoaId + '><i class="far fa-trash-alt" onclick="deletePessoa(' + row.pessoaId + ');return false"></i> <span class="sr-only">Remove</span></button>'
                        }
                    }]
            });

        table2 = $('#lstAnexos').DataTable({
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
                "url": "/projetos/listaAnexos/" + projetoId,
                "type": "GET",
                "dataType": "json",
                "dataSrc": ""
            },
            deferRender: true,
            order: [1, 'asc'],
            columns: [{
                data: 'anexoNome',
                className: 'align-middle'
            }, {
                data: 'anexoTipo',
                className: 'align-middle'
            }, {
                data: 'anexoTamanho',
                className: 'align-middle'
            }, {
                data: 'anexoDataAlteracao',
                    className: 'align-middle',
                    render: function (data, type, row) {
                        if (type === "sort" || type === "type") {
                            return data;
                        }
                        return moment(data).format("MM-DD-YYYY HH:mm");
                    }
            }, {
                data: 'anexoDataCriacao',
                    className: 'align-middle',
                    render: function (data, type, row) {
                        if (type === "sort" || type === "type") {
                            return data;
                        }
                        return moment(data).format("MM-DD-YYYY HH:mm");
                    }
            }, {
                data: 'actions',
                className: 'align-middle text-right',
                orderable: false,
                searchable: false
            }],
            columnDefs: [
                {
                    targets: 0,
                    render: function render(data, type, row, meta) {
                        return "<a href=\"/_AnexosProjetos/" + projetoId + "/".concat(row.anexoNome, "\" class=\"tile tile-img mr-1\">\n            <img class=\"img-fluid\" src=\"/_AnexosProjetos/" + projetoId + "/").concat(row.anexoNome, "\" alt=\"Card image cap\">\n          </a>\n          <a href=\"/_AnexosProjetos/" + projetoId + "/").concat(row.anexoNome, "\" download>").concat(row.anexoNome, "</a>");
                    }
                },
                {
                    targets: 5,
                    render: function render(data, type, row, meta) {
                        return '<button type="button" class="btn btn-sm btn-icon btn-secondary edit" data-toggle="modal" data-id=' + row.pessoaId + '><i class= "fa fa-pencil-alt" onclick="editPessoa(' + row.pessoaId + ');return false"></i > <span class="sr-only">Edit</span></button>' +
                            '<button type="button" class="btn btn-sm btn-icon btn-secondary delete" data-toggle="modal" data-id=' + row.pessoaId + '><i class="far fa-trash-alt" onclick="deletePessoa(' + row.pessoaId + ');return false"></i> <span class="sr-only">Remove</span></button>'
                    }
                }]
        });

        table3 = $('#lstAnexosGD').DataTable({
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
                "url": "/GoogleDrive/listaAnexosGD/" + projetoId,
                "type": "GET",
                "dataType": "json",
                "dataSrc": ""
            },
            deferRender: true,
            order: [1, 'asc'],
            columns: [ {
                data: 'Name',
                className: 'align-middle'
            }, {
                data: 'Size',
                className: 'align-middle'
            }, {
                data: 'Version',
                className: 'align-middle'
            }, {
                data: 'CreatedTime',
                className: 'align-middle',
                    format: 'DD/MM/YYYY hh:mm A',
                    fieldInfo: 'Verbose date format'
            }, {
                data: 'actions',
                className: 'align-middle text-right',
                orderable: false,
                searchable: false
            }],
            columnDefs: [
                 {
                    targets: 3,
                    render: function (data, type, row) {
                        if (type === "sort" || type === "type") {
                            return data;
                        }
                        return moment(data).format("MM-DD-YYYY HH:mm");
                    }
                },
                {
                    targets: 4,
                    render: function render(data, type, row, meta) {
                        return '<button onclick="window.location=\'https://drive.google.com/file/d/' + row.Id + '\/view?usp=sharing\'"; class="btn btn-sm btn-icon btn-secondary" data-key=' + row.Id + '><i class= "fa fa-pencil-alt"></i > <span class="sr-only">Edit</span></button>' +
                            '<button type="button" id="DownGD" value="Download" class="btn btn-sm btn-icon btn-secondary" data-key=' + row.Id + '><i class= "fa fa-file-download"></i > <span class="sr-only">Edit</span></button>' +
                            '<button type="button" id="DelGD" value="Delete" class="btn btn-sm btn-icon btn-secondary delete"><i class="far fa-trash-alt" ></i> <span class="sr-only">Remove</span></button>'
                    }
                }]
        });
    }

}

function selecionaProjeto(id) {

    var projetoId = data[id].projetoId;

    $("#projetoNome").html('<h1 class="page-title"><i class="far fa-building text-muted mr-2"></i>' + data[id].projetoNome + '</h1>' +
        '<p class="text-muted"> Data início: ' + data[id].projetoDataIni + ', data fim: ' + data[id].projetoDataFim + '</p>');

    $("#projetoResumo").html('<div class="d-flex justify-content-between align-items-center">' +
        '<h2 id="projeto-billing-pessoa-tab" class="card-title"> Objetivo </h2><button type = "button" class="btn btn-sm btn-icon btn-secondary edit" data-toggle="modal"><i class="fa fa-pencil-alt" onclick="editProjeto(' + data[id].projetoId + ');return false"></i> <span class="sr-only">Edit</span></button >' +
        '</div>' +
        '<address> ' + data[id].projetoObjetivo + '</address>')

    $("#projetoAnexo").html('<div class="d-flex justify-content-between align-items-center">' +
        '<button type = "button" class="btn btn-sm btn-icon btn-secondary" data-toggle="modal"><i class="fa fa-file-upload" onclick="UploadAnexos(' + data[id].projetoId + ');return false"></i> <span class="sr-only"> Upload Arquivos</span></button >' +
        '</div>')

    $("#projetoGDrive").html('<div class="d-flex justify-content-between align-items-center">' +
        '<button type = "button" class="btn btn-sm btn-icon btn-secondary" data-toggle="modal"><i class="fa fa-file-upload" onclick="UploadGDAnexos(' + data[id].projetoId + ');return false"></i> <span class="sr-only"> Upload Arquivos</span></button >' +
        '</div>')

    table.destroy();
    table2.destroy();
    table3.destroy();

    table = $('#lstPessoas').DataTable({
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
            "url": "/pessoas/listaTime/" + projetoId,
            "type": "GET",
            "dataType": "json",
            "dataSrc": ""
        },
        deferRender: true,
        order: [1, 'asc'],
        columns: [{
            data: 'pessoaNome',
            className: 'align-middle'
        }, {
            data: 'entidadeSigla',
            className: 'align-middle'
        }, {
            data: 'funcaoDescricao',
            className: 'align-middle'
        }, {
                data: 'projetoPessoaCustoHora',
            className: 'align-middle'
            }, {
                data: 'projetoPessoaQtdeHoraSemanal',
                className: 'align-middle'
            }, {
                data: 'projetoPessoaQtdeSemana',
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

    table2 = $('#lstAnexos').DataTable({
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
            "url": "/projetos/listaAnexos/" + projetoId,
            "type": "GET",
            "dataType": "json",
            "dataSrc": ""
        },
        deferRender: true,
        order: [1, 'asc'],
        columns: [{
            data: 'anexoNome',
            className: 'align-middle'
        }, {
            data: 'anexoTipo',
            className: 'align-middle'
        }, {
            data: 'anexoTamanho',
            className: 'align-middle'
        }, {
            data: 'anexoDataAlteracao',
                className: 'align-middle',
                render: function (data, type, row) {
                    if (type === "sort" || type === "type") {
                        return data;
                    }
                    return moment(data).format("MM-DD-YYYY HH:mm");
                }
        }, {
            data: 'anexoDataCriacao',
                className: 'align-middle',
                render: function (data, type, row) {
                    if (type === "sort" || type === "type") {
                        return data;
                    }
                    return moment(data).format("MM-DD-YYYY HH:mm");
                }
        }, {
            data: 'actions',
            className: 'align-middle text-right',
            orderable: false,
            searchable: false
        }],
        columnDefs: [
            {
                targets: 0,
                render: function render(data, type, row, meta) {
                    return "<a href=\"/_AnexosProjetos/" + projetoId + "/".concat(row.anexoNome, "\" class=\"tile tile-img mr-1\">\n<img class=\"img-fluid\" src=\"/_AnexosProjetos/" + projetoId + "/").concat(row.anexoNome, "\" alt=\"Card image cap\">\n</a>\n<a href=\"/_AnexosProjetos/" + projetoId + "/").concat(row.anexoNome, "\" download>").concat(row.anexoNome, "</a>");
                }
            },
            {
                targets: 5,
                render: function render(data, type, row, meta) {
                    return '<button type="button" class="btn btn-sm btn-icon btn-secondary edit" data-toggle="modal" data-id=' + row.pessoaId + '><i class= "fa fa-pencil-alt" onclick="editPessoa(' + row.pessoaId + ');return false"></i > <span class="sr-only">Edit</span></button>' +
                        '<button type="button" class="btn btn-sm btn-icon btn-secondary delete" data-toggle="modal" data-id=' + row.pessoaId + '><i class="far fa-trash-alt" onclick="deletePessoa(' + row.pessoaId + ');return false"></i> <span class="sr-only">Remove</span></button>'
                }
            }]
    });

    table3 = $('#lstAnexosGD').DataTable({
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
            "url": "/GoogleDrive/listaAnexosGD/" + projetoId,
            "type": "GET",
            "dataType": "json",
            "dataSrc": ""
        },
        deferRender: true,
        order: [1, 'asc'],
        columns: [ {
            data: 'Name',
            className: 'align-middle'
        }, {
            data: 'Size',
            className: 'align-middle'
        }, {
            data: 'Version',
            className: 'align-middle'
        }, {
            data: 'CreatedTime',
            className: 'align-middle'
        }, {
            data: 'actions',
            className: 'align-middle text-right',
            orderable: false,
            searchable: false
        }],
        columnDefs: [
            {
                targets: 3,
                render: function (data, type, row) {
                    if (type === "sort" || type === "type") {
                        return data;
                    }
                    return moment(data).format("MM-DD-YYYY HH:mm");
                }
            },
            {
                targets: 4,
                render: function render(data, type, row, meta) {
                    return '<button onclick="window.location=\'https://drive.google.com/file/d/'+ row.Id + '\/view?usp=sharing\'"; class="btn btn-sm btn-icon btn-secondary" data-key=' + row.Id + '><i class= "fa fa-pencil-alt"></i > <span class="sr-only">Edit</span></button>' +
                        '<button type="button" id="DownGD" value="Download" class="btn btn-sm btn-icon btn-secondary" data-key=' + row.Id + '><i class= "fa fa-file-download"></i > <span class="sr-only">Edit</span></button>' +
                           '<button type="button" id="DelGD" value="Delete" class="btn btn-sm btn-icon btn-secondary delete"><i class="far fa-trash-alt" ></i> <span class="sr-only">Remove</span></button>'
                }
            }]
    });
}

function UploadAnexos(id) {
    $("#anexoNewModal").load("/projetos/UploadAnexos?id=" + id, function () {
        $("#anexoNewModal").modal();
    })
}

function UploadGDAnexos(id) {
    $("#anexoNewModal").load("/projetos/UploadAnexosGD?id=" + id, function () {
        $("#anexoNewModal").modal();
    })
}

function editprojeto(id) {
    $("#projetoNewModal").load("/projetos/Edit?id=" + id, function () {
        $("#projetoNewModal").modal();
    })
 }

function deleteprojeto(id) {
    $("#projetoNewModal").load("Delete?id=" + id, function () {
        $("#projetoNewModal").modal();
    })
}

function createProjeto() {
        $("#projetoNewModal").load("/projetos/Create", function () {
            $("#projetoNewModal").modal();
        })
}

function editPessoa(id) {
    $("#projetopessoaEditModal").load("/pessoas/Edit?id=" + id, function () {
        $("#projetopessoaEditModal").modal();
        })
}

function deletePessoa(id) {
    $("#projetopessoaEditModal").load("/pessoas/Delete?id=" + id, function () {
        $("#projetopessoaEditModal").modal();
        })
}

function createPessoa() {
    $("#projetopessoaEditModal").load("/pessoas/Create", function () {
        $("#projetopessoaEditModal").modal();
        })
}

$(document).on('click', '#DownGD', function () {
        debugger;
    var fileId = $(this).attr("data-key");
    window.location.href = '/GoogleDrive/DownloadFile/' + fileId;
});

$(document).on('click', '#DelGD', function () {
    debugger;
    var data = table3.row($(this).parents('tr')).data();
    $.post('/GoogleDrive/DeleteFile/', data)
    //table3.row($(this).parents('tr')).delete();

    table3.row($(this).parents('tr')).remove().draw(false);

});