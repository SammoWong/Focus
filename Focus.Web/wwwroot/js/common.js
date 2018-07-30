function bindJsTree(treeName, url, checkbox, loadedfunction) {
    var control = $('#' + treeName)
    control.data('jstree', false);//清空数据，必须

    var isCheck = arguments[2] || false; //设置checkbox默认值为false
    if (isCheck) {
        //复选框树的初始化
        _.get(url, function (data) {
            control.jstree({
                'plugins': ['types', 'dnd', "checkbox"], //出现选择框
                'checkbox': { cascade: "", three_state: false }, //不级联
                'core': {
                    'data': data.data,
                    "themes": {
                        "responsive": false
                    }
                },
                'types': {
                    'default': {
                        'icon': 'fa fa-folder'
                    },
                    'html': {
                        'icon': 'fa fa-file-code-o'
                    },
                    'svg': {
                        'icon': 'fa fa-file-picture-o'
                    },
                    'css': {
                        'icon': 'fa fa-file-code-o'
                    },
                    'img': {
                        'icon': 'fa fa-file-image-o'
                    },
                    'js': {
                        'icon': 'fa fa-file-text-o'
                    }
                }
            }).bind('loaded.jstree', loadedfunction);
        });
    }
    else {
        //普通树列表的初始化
        _.get(url, function (data) {
            control.jstree({
                'core': {
                    'data': data.data,
                    "themes": {
                        "responsive": false
                    }
                },
                'plugins': ['types', 'dnd'],
                'types': {
                    'default': {
                        'icon': 'fa fa-folder'
                    },
                    'html': {
                        'icon': 'fa fa-file-code-o'
                    },
                    'svg': {
                        'icon': 'fa fa-file-picture-o'
                    },
                    'css': {
                        'icon': 'fa fa-file-code-o'
                    },
                    'img': {
                        'icon': 'fa fa-file-image-o'
                    },
                    'js': {
                        'icon': 'fa fa-file-text-o'
                    }
                }
            }).bind('loaded.jstree', loadedfunction);
        });
    }
}

/**
 * 绑定简易的表格内容，用于简单展示
 * @param {any} data
 */
function bindSimpleBootstrapTable(data) {
    if (data.code != 0) {
        toastr.error(data.message);
        return;
    }
    $('#bootstrapTable').bootstrapTable('destroy').bootstrapTable({
        data: data.data.length == 0 ? [] : data.data,
        search: true,
        pagination: true,
        pageNumber: 1,
        pageSize: 10,   
        pageList: [10, 20, 50],
        showRefresh: true,
        showToggle: true,
        showColumns: true,
        iconSize: 'outline',
        icons: {
            refresh: 'glyphicon-repeat',
            toggle: 'glyphicon-list-alt',
            columns: 'glyphicon-list'
        }
    });
}