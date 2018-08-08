$.fn.clientSidePagination = function (options) {
    var defaults = {
        method: 'GET',//请求方式（*）  
        dataField: "data",//这是返回的json数组的key.默认是"rows".这里前后端约定好就行
        pagination: true,//是否显示分页
        sidePagination: "client", //分页方式：client客户端分页，server服务端分页（*）
        pageNumber: 1,//初始化加载第一页，默认第一页
        pageSize: 10,//每页记录数
        pageList: [10, 20, 50],//可供选择的每页的行数
        sortable: true, //是否启用排序
        sortOrder: "asc",//排序方式
        search: true,//是否显示表格搜索
        showColumns: true,//是否显示所有的列（选择显示的列）
        showRefresh: true,//是否显示刷新按钮
        showToggle: true,//是否显示详细视图和列表视图的切换按钮
        minimumCountColumns: 2,//最少允许的列数
        clickToSelect: true,//是否启用点击选中行
        iconSize: 'outline',
        icons: {
            refresh: 'glyphicon-repeat',
            toggle: 'glyphicon-list-alt',
            columns: 'glyphicon-list'
        },
        queryParams: function (params) {//自定义参数，这里的参数是传给后台的，我这是是分页用的
            return {//这里的params是table提供的
                //skip: params.offset,//从数据库第几条记录开始
                //take: params.limit//找多少条
            };
        },
        ajaxOptions: {
            headers: { "Authorization": "Bearer " + access_token }
        },
        responseHandler: function (result) {
            if (result.code != 0) {
                toastr.error(result.message);
                return false;
            }
            //如果没有错误则返回数据，渲染表格
            return {
                //total: result.data.total, //总页数,前面的key必须为"total"
                data: result.data //行数据，前面的key要与之前设置的dataField的值一致.
            };
        }
    };
    options = $.extend(defaults, options);
    return $(this).bootstrapTable('destroy').bootstrapTable(options);
}

$.fn.serverSidePagination = function (options) {
    var defaults = {
        method: 'GET',//请求方式（*）  
        dataField: "data",//这是返回的json数组的key.默认是"rows".这里前后端约定好就行
        pagination: true,//是否显示分页
        sidePagination: "server", //分页方式：client客户端分页，server服务端分页（*）
        pageNumber: 1,//初始化加载第一页，默认第一页
        pageSize: 10,//每页记录数
        pageList: [10, 20, 50],//可供选择的每页的行数
        sortable: true, //是否启用排序
        sortOrder: "asc",//排序方式
        showColumns: true,//是否显示所有的列（选择显示的列）
        showRefresh: true,//是否显示刷新按钮
        showToggle: true,//是否显示详细视图和列表视图的切换按钮
        minimumCountColumns: 2,//最少允许的列数
        clickToSelect: true,//是否启用点击选中行
        iconSize: 'outline',
        icons: {
            refresh: 'glyphicon-repeat',
            toggle: 'glyphicon-list-alt',
            columns: 'glyphicon-list'
        },
        queryParams: function (params) {//自定义参数，这里的参数是传给后台的，我这是是分页用的
            return {//这里的params是table提供的
                start: params.offset,//从数据库第几条记录开始
                take: params.limit//找多少条
            };
        },
        ajaxOptions: {
            headers: { "Authorization": "Bearer " + access_token }
        },
        responseHandler: function (result) {
            if (result.code != 0) {
                toastr.error(result.message);
                return false;
            }
            //如果没有错误则返回数据，渲染表格
            return {
                total: result.data.total, //总页数,前面的key必须为"total"
                data: result.data.rows //行数据，前面的key要与之前设置的dataField的值一致.
            };
        }
    };
    options = $.extend(defaults, options);
    return $(this).bootstrapTable('destroy').bootstrapTable(options);
}