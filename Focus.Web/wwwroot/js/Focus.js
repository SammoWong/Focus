(function () {
    "use strict";
    var root = this,
        store,
        doc;
    var Focus = {};

    if (typeof module !== 'undefined' && module.exports) {
        module.exports = Focus;
    } else {
        root.Focus = Focus;
        doc = root.document;
        if ((typeof Storage) !== 'undefined') {
            store = root.localStorage;
        }
    }

    //判断是否为数组
    Focus.isArray = function (obj) {
        return Object.prototype.toString.call(obj) === '[object Array]';
    };

    //判断是否为函数
    Focus.isFunction = function (func) {
        return Object.prototype.toString.call(func) === '[object Array]';
    }

    //判断是否为对象
    Focus.isObject = function (obj) {
        return Object.prototype.toString.call(obj) === '[object Object]';
    };

    //判断是否为字符串
    Focus.isString = function (obj) {
        return Object.prototype.toString.call(obj) === '[object String]';
    };

    //判断是否为数值
    Focus.isNumber = function (obj) {
        return Object.prototype.toString.call(obj) === '[object Number]';
    };


    //判断是否为布尔值
    Focus.isBoolean = function (obj) {
        return Object.prototype.toString.call(obj) === '[object Boolean]';
    };


    //判断是否为Date类型
    Focus.isDate = function (obj) {
        return Object.prototype.toString.call(obj) === '[object Date]';
    };


    //判断是否为null、undefined或者空
    Focus.isNull = function (value) {
        return value === '' || value === undefined || value === null ? true : false;
    };

    //判断是否为URL
    Focus.isURL = function (text) {
        var reg = /[a-zA-z]+:\/\/[^\s]/;
        return reg.test(text);
    };

    //过滤字符串中的空格
    Focus.clearSpace = function (text) {
        return text.replace(/[ ]/g, "");
    };

    //判断字符串中是否包含中文
    Focus.existCN = function (text) {
        var reg = /.*[\u4e00-\u9fa5]+.*$/;
        return reg.test(text);
    };


}.call(this));