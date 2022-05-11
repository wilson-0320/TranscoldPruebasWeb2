/* ===========================================================
 * trumbowyg.table.custom.js v2.0
 * Table plugin for Trumbowyg
 * http://alex-d.github.com/Trumbowyg
 * ===========================================================
 * Author : Sven Dunemann [dunemann@forelabs.eu]
 */

(function ($) {
    'use strict';

    var defaultOptions = {
        rows: 8,
        columns: 8,
        styler: 'table'
    };

    $.extend(true, $.trumbowyg, {
        langs: {
            // jshint camelcase:false
            en: {
                table: 'Insert table',
                tableAddRow: 'Add row',
                tableAddRowAbove: 'Add row above',
                tableAddColumnLeft: 'Add column to the left',
                tableAddColumn: 'Add column to the right',
                tableDeleteRow: 'Delete row',
                tableDeleteColumn: 'Delete column',
                tableDestroy: 'Delete table',
                error: 'Error'
            },
            
            es: {
                table: 'Insertar tabla',
                tableAddRow: 'Agregar fila',
                tableAddRowAbove: 'Agregar fila arriba',
                tableAddColumnLeft: 'Agregar columna a la izquierda',
                tableAddColumn: 'Agregar columna a la derecha',
                tableDeleteRow: 'Borrar fila',
                tableDeleteColumn: 'Borrar columna',
                tableDestroy: 'Borrar tabla',
                error: 'Error'
            }// jshint camelcase:true
        },

        plugins: {
            table: {
                init: function (t) {
                    t.o.plugins.table = $.extend(true, {}, defaultOptions, t.o.plugins.table || {});

                    var buildButtonDef = {
                        fn: function () {
                            t.saveRange();

                            var btnName = 'table';

                            var dropdownPrefix = t.o.prefix + 'dropdown',
                                dropdownOptions = { // the dropdown
                                    class: dropdownPrefix + '-' + btnName + ' ' + dropdownPrefix + ' ' + t.o.prefix + 'fixed-top'
                                };
                            dropdownOptions['data-' + dropdownPrefix] = btnName;
                            var $dropdown = $('<div/>', dropdownOptions);

                            if (t.$box.find('.' + dropdownPrefix + '-' + btnName).length === 0) {
                                t.$box.append($dropdown.hide());
                            } else {
                                $dropdown = t.$box.find('.' + dropdownPrefix + '-' + btnName);
                            }

                            // clear dropdown
                            $dropdown.html('');

                            // when active table show AddRow / AddColumn
                            if (t.$box.find('.' + t.o.prefix + 'table-button').hasClass(t.o.prefix + 'active-button')) {
                                $dropdown.append(t.buildSubBtn('tableAddRowAbove'));
                                $dropdown.append(t.buildSubBtn('tableAddRow'));
                                $dropdown.append(t.buildSubBtn('tableAddColumnLeft'));
                                $dropdown.append(t.buildSubBtn('tableAddColumn'));
                                $dropdown.append(t.buildSubBtn('tableDeleteRow'));
                                $dropdown.append(t.buildSubBtn('tableDeleteColumn'));
                                $dropdown.append(t.buildSubBtn('tableDestroy'));
                            } else {
                                var tableSelect = $('<table/>');
                                $('<tbody/>').appendTo(tableSelect);
                                for (var i = 0; i < t.o.plugins.table.rows; i += 1) {
                                    var row = $('<tr/>').appendTo(tableSelect);
                                    for (var j = 0; j < t.o.plugins.table.columns; j += 1) {
                                        $('<td/>').appendTo(row);
                                    }
                                }
                                tableSelect.find('td').on('mouseover', tableAnimate);
                                tableSelect.find('td').on('mousedown', tableBuild);

                                $dropdown.append(tableSelect);
                                $dropdown.append($('<div class="trumbowyg-table-size">1x1</div>'));
                            }

                            t.dropdown(btnName);
                        }
                    };

                    var tableAnimate = function(columnEvent) {
                        var column = $(columnEvent.target),
                            table = column.closest('table'),
                            colIndex = this.cellIndex,
                            rowIndex = this.parentNode.rowIndex;

                        // reset all columns
                        table.find('td').removeClass('active');

                        for (var i = 0; i <= rowIndex; i += 1) {
                            for (var j = 0; j <= colIndex; j += 1) {
                                table.find('tr:nth-of-type('+(i+1)+')').find('td:nth-of-type('+(j+1)+')').addClass('active');
                            }
                        }

                        // set label
                        table.next('.trumbowyg-table-size').html((colIndex+1) + 'x' + (rowIndex+1));
                    };

                    var tableBuild = function() {
                        t.saveRange();

                        var tabler = $('<table/>');
                        $('<tbody/>').appendTo(tabler);
                        if (t.o.plugins.table.styler) {
                            tabler.attr('class', 'table table-bordered');
                            //t.o.plugins.table.styler
                        }

                        var colIndex = this.cellIndex,
                            rowIndex = this.parentNode.rowIndex;

                        for (var i = 0; i <= rowIndex; i += 1) {
                            var row = $('<tr></tr>').appendTo(tabler);
                            for (var j = 0; j <= colIndex; j += 1) {
                                $('<td/>').appendTo(row);
                            }
                        }

                        t.range.deleteContents();
                        t.range.insertNode(tabler[0]);
                        t.$c.trigger('tbwchange');
                    };

                    var addRow = {
                        title: t.lang.tableAddRow,
                        text: t.lang.tableAddRow,
                        ico: 'row-below',

                        fn: function () {
                            t.saveRange();

                            var node = t.doc.getSelection().focusNode;
                            var focusedRow = $(node).closest('tr');
                            var table = $(node).closest('table');

                            if(table.length > 0) {
                                var row = $('<tr/>');
                                // add columns according to current columns count
                                for (var i = 0; i < table.find('tr')[0].childElementCount; i += 1) {
                                    $('<td/>').appendTo(row);
                                }
                                // add row to table
                                focusedRow.after(row);
                            }

                            t.syncCode();
                        }
                    };

                    var addRowAbove = {
                        title: t.lang.tableAddRowAbove,
                        text: t.lang.tableAddRowAbove,
                        ico: 'row-above',

                        fn: function () {
                            t.saveRange();

                            var node = t.doc.getSelection().focusNode;
                            var focusedRow = $(node).closest('tr');
                            var table = $(node).closest('table');

                            if(table.length > 0) {
                                var row = $('<tr/>');
                                // add columns according to current columns count
                                for (var i = 0; i < table.find('tr')[0].childElementCount; i += 1) {
                                    $('<td/>').appendTo(row);
                                }
                                // add row to table
                                focusedRow.before(row);
                            }

                            t.syncCode();
                        }
                    };

                    var addColumn = {
                        title: t.lang.tableAddColumn,
                        text: t.lang.tableAddColumn,
                        ico: 'col-right',

                        fn: function () {
                            t.saveRange();

                            var node = t.doc.getSelection().focusNode;
                            var focusedCol = $(node).closest('td');
                            var table = $(node).closest('table');
                            var focusedColIdx = focusedCol.index();

                            if(table.length > 0) {
                                $(table).find('tr').each(function() {
                                    $($(this).children()[focusedColIdx]).after('<td></td>');
                                });
                            }

                            t.syncCode();
                        }
                    };

                    var addColumnLeft = {
                        title: t.lang.tableAddColumnLeft,
                        text: t.lang.tableAddColumnLeft,
                        ico: 'col-left',

                        fn: function () {
                            t.saveRange();

                            var node = t.doc.getSelection().focusNode;
                            var focusedCol = $(node).closest('td');
                            var table = $(node).closest('table');
                            var focusedColIdx = focusedCol.index();

                            if(table.length > 0) {
                                $(table).find('tr').each(function() {
                                    $($(this).children()[focusedColIdx]).before('<td></td>');
                                });
                            }

                            t.syncCode();
                        }
                    };

                    var destroy = {
                        title: t.lang.tableDestroy,
                        text: t.lang.tableDestroy,
                        ico: 'table-delete',

                        fn: function () {
                            t.saveRange();

                            var node = t.doc.getSelection().focusNode,
                                table = $(node).closest('table');

                            table.remove();

                            t.syncCode();
                        }
                    };

                    var deleteRow = {
                        title: t.lang.tableDeleteRow,
                        text: t.lang.tableDeleteRow,
                        ico: 'row-delete',

                        fn: function () {
                            t.saveRange();

                            var node = t.doc.getSelection().focusNode,
                                row = $(node).closest('tr');

                            row.remove();

                            t.syncCode();
                        }
                    };

                    var deleteColumn = {
                        title: t.lang.tableDeleteColumn,
                        text: t.lang.tableDeleteColumn,
                        ico: 'col-delete',

                        fn: function () {
                            t.saveRange();

                            var node = t.doc.getSelection().focusNode,
                                table = $(node).closest('table'),
                                td = $(node).closest('td'),
                                cellIndex = td.index();

                            $(table).find('tr').each(function() {
                                $(this).find('td:eq(' + cellIndex + ')').remove();
                            });

                            t.syncCode();
                        }
                    };

                    t.addBtnDef('table', buildButtonDef);
                    t.addBtnDef('tableAddRowAbove', addRowAbove);
                    t.addBtnDef('tableAddRow', addRow);
                    t.addBtnDef('tableAddColumnLeft', addColumnLeft);
                    t.addBtnDef('tableAddColumn', addColumn);
                    t.addBtnDef('tableDeleteRow', deleteRow);
                    t.addBtnDef('tableDeleteColumn', deleteColumn);
                    t.addBtnDef('tableDestroy', destroy);
                }
            }
        }
    });
})(jQuery);
