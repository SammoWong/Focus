﻿; (function () {
    "use strict";
    var GLOBAL = typeof global == "object" ? global : window;

    //原型方法
    var _toString = Object.prototype.toString;


    /**
     * 判断是否为函数
     * @param {any} value
     */
    function isFunction(value) {
        return _toString.call(value) === "[object Function]";
    }

    /**
     * 判断是否为对象
     * @param {any} value
     */
    function isObject(value) {
        return value && _toString.call(value) === "[object Object]";
    }

    /**
     * 判断是否为数组
     * @param {any} value
     */
    function isArray(value) {
        return _toString.call(value) === "[object Array]";
    }

    /**
     * 判断是否为字符串
     * @param {any} value
     */
    function isString(value) {
        return _toString.call(value) === "[object String]"
    }

    /**
     * 判断是否为数字
     * @param {any} value
     */
    var isNumber = function (value) {
        return _toString.call(value) === '[object Number]';
    };

    /**
     * 判断是否为布尔值
     * @param {any} value
     */
    var isBoolean = function (value) {
        return _toString.call(value) === '[object Boolean]';
    };

    /**
     * 判断是否为空
     * @param {any} value
     */
    var isNull = function (value) {
        return _toString.call(value) === '[object Null]';
    };

    /**
     * 判断是否为undefined
     * @param {any} value
     */
    var isUndefined = function (value) {
        return _toString.call(value) === '[object Undefined]';
    };

    /**
     * 判断是否为Date类型
     * @param {any} value
     */
    var isDate = function (value) {
        return _toString.call(value) === '[object Date]'
    };

    /**
     * 如果value不包含任何值，返回true
     * 对于字符串和数组对象，如果length属性为0，则返回true
     * 对于空对象也返回true
     * @param {any} value
     */
    var isEmpty = function (value) {
        var flag = true;
        if (isNumber(value)) {
            flag = true;
        }
        if (isNull(value) || isUndefined(value)) {
            flag = true;
        }
        if (isBoolean(value) || isDate(value) || isFunction(value)) {
            flag = false;
        }
        if (isArray(value) || isString(value)) {
            flag = value.length > 0 ? false : true;
        }
        if (isObject(value)) {
            for (var key in value) {
                if (value.hasOwnProperty(key)) {
                    flag = false;
                }
            }
        }
        return flag;
    }

    /**
     * 去除字符串左右空格
     * @param {string} value
     */
    var trim = function (value) {
        if (!isString(value)) {
            return value;
        }
        return value.replace(/(^\s*)|(\s*$)/g, '');
    };

    /**
     * 去除字符串中的空格
     * @param {string} value
     */
    var clearSpace = function (value) {
        if (!isString(value)) {
            return value;
        }
        return value.replace(/[ ]/g, '');
    };

    /**
     * 判断字符串是否包含中文
     * @param {string} value
     */
    var existCN = function (value) {
        if (!isString(value)) {
            return value;
        }
        return /.*[\u4e00-\u9fa5]+.*$/.test(value);
    };

    /**
     * 获取当前日期（年月日）
     * type:CN中文格式
     * @param {any} type
     */
    var getDate = function (type) {
        var time = new Date(),
            year = time.getFullYear(),
            m = time.getMonth() + 1,
            month = m < 10 ? ('0' + m) : m,
            d = time.getDate(),
            day = d < 10 ? ('0' + d) : d,
            dateText = '';

        if (type === 'CN') {
            return dateText += year + '年' + month + '月' + day + '日';
        } else {
            return dateText += year + '-' + month + '-' + day;
        }
    };

    /**
     * 获取当前时间（时分秒）
     * type:CN中文格式
     * @param {any} type
     */
    var getTime = function (type) {
        var time = new Date(),
            hours = time.getHours(),
            m = time.getMinutes(),
            minutes = m < 10 ? ('0' + m) : m,
            s = time.getSeconds(),
            seconds = s < 10 ? ('0' + s) : s,
            dateText = '';

        if (type === 'CN') {
            return dateText += hours + '时' + minutes + '分' + seconds + '秒';
        } else {
            return dateText += hours + ':' + minutes + ':' + seconds;
        }
    };


    /**
     * 根据日期获取当前星期，为空则获取当前时间星期
     * @param {any} date
     */
    var getWeek = function (date) {
        date = date || (getDate());
        var digitText = toCnDigit(new Date(date).getDay());
        digitText == '零' ? digitText = '天' : digitText = digitText;
        return '星期' + digitText;
    };

    /**
     * 阿拉伯数字转中文数字
     * @param {any} text
     */
    var toCnDigit = function (value) {
        var charArr = ['零', '一', '二', '三', '四', '五', '六', '七', '八', '九', '十'],
            num = isNumber(value) ? value.toString() : '',
            numArr = num.split(''),
            len = numArr.length,
            result = '';

        for (var i = 0; i < len; i++) {
            result += charArr[parseInt(numArr[i])];
        }
        return result;
    };

    /**
     * GET请求
     * @param {any} url
     * @param {any} data
     * @param {any} success
     * @param {any} options
     */
    var get = function (url, data, success, options) {
        var defaults = {
            url: '',
            method: "GET",
            data: {},
            async: true,
            headers: { 'Authorization': "Bearer " + access_token },
            dataType: 'json',
            beforeSend: function () {
                showLoading();
            },
            complete: function () {
                hideLoading();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                // 状态码
                console.log(XMLHttpRequest.status);
                // 状态
                console.log(XMLHttpRequest.readyState);
                // 错误信息   
                console.log(textStatus);

                toastr.error(XMLHttpRequest.responseJSON.message);
            }
        };
        if (isFunction(data)) {
            defaults.url = url;
            defaults.success = data;
            $.extend(defaults, success);
        } else if (isObject(success)) {
            defaults.url = url;
            defaults.success = data;
            $.extend(defaults, success);
        } else {
            defaults.url = url;
            defaults.data = data;
            defaults.success = success;
        }

        if (options)
            $.extend(defaults, options);

        $.ajax(defaults);
    };

    /**
     * POST请求
     * @param {any} url
     * @param {any} data
     * @param {any} success
     * @param {any} options
     */
    var post = function (url, data, success, options) {
        var defaults = {
            url: '',
            method: "POST",
            data: {},
            async: true,
            headers: { 'Authorization': "Bearer " + access_token },
            dataType: 'json',
            beforeSend: function () {
                showLoading();
            },
            complete: function () {
                hideLoading();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                // 状态码
                console.log(XMLHttpRequest.status);
                // 状态
                console.log(XMLHttpRequest.readyState);
                // 错误信息   
                console.log(textStatus);

                toastr.error(XMLHttpRequest.responseJSON.message);
            }
        };
        if (isFunction(data)) {
            defaults.url = url;
            defaults.success = data;
            $.extend(defaults, success);
        } else if (isObject(success)) {
            defaults.url = url;
            defaults.success = data;
            $.extend(defaults, success);
        } else {
            defaults.url = url;
            defaults.data = data;
            defaults.success = success;
        }

        if (options)
            $.extend(defaults, options);

        $.ajax(defaults);
    };

    ///**
    // * GET请求
    // * @param {any} url
    // * @param {any} data
    // * @param {any} success
    // */
    //var get = function (url, data, success, async) {
    //    var conf;
    //    if (isFunction(data)) {
    //        conf = { url: url, method: 'get', success: data, async: async, dataType: 'json' };
    //    } else {
    //        conf = { url: url, method: 'get', data: data, success: success, async: async, dataType: 'json' };
    //    }
    //    conf.headers = { 'Authorization': "Bearer " + access_token };
    //    conf.beforeSend = function () {
    //        showLoading();
    //    };
    //    conf.complete = function () {
    //        hideLoading();
    //    }
    //    $.ajax(conf);
    //};

    ///**
    // * POST请求
    // * @param {any} url
    // * @param {any} data
    // * @param {any} success
    // */
    //var post = function (url, data, success, async) {
    //    var conf;
    //    if (isFunction(data)) {
    //        conf = { url: url, method: 'post', success: data, async: async, dataType: 'json' };
    //    } else {
    //        conf = { url: url, method: 'post', data: data, success: success, async: async, dataType: 'json' };
    //    }
    //    conf.headers = { 'Authorization': "Bearer " + access_token };
    //    conf.beforeSend = function () {
    //        showLoading();
    //    };
    //    conf.complete = function () {
    //        hideLoading();
    //    }
    //    $.ajax(conf);
    //};

    /**
     * 设置cookie
     * @param {string} key
     * @param {string} value
     * @param {number} time
     */
    var _setCookie = function (key, value, time) {
        var now = new Date();
        var expires = new Date(now.getTime() + time * 1000);
        document.cookie = key + '=' + value + ';' + 'expires=' + expires.toUTCString();
    };

    /**
     * 读取cookie
     * @param {string} key
     */
    var _getCookie = function (key) {
        var name = key + "=";
        var cookies = document.cookie.split(';');
        for (var i = 0; i < cookies.length; i++) {
            var c = cookies[i].trim();
            if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
        }
        return "";
    };

    /**
     * 根据key移除cookie
     * @param {string} key
     */
    var _removeCookie = function (key) {
        _setCookie(key, '', -1);
    }

    /**
     * 清除所有cookie
     * */
    var _clearCookie = function () {
        var cookies = document.cookie ? document.cookie.split(';') : [];
        for (var i = 0; i < cookies.length; i++) {
            var key = cookies[i].split('=');
            _removeCookie(key[0]);
        }
    }

    var Cookie = {
        set: _setCookie,
        get: _getCookie,
        remove: _removeCookie,
        clear: _clearCookie,
    };

    /**
     * 设置localStorage本地缓存
     * @param {any} key
     * @param {any} value
     */
    var _setLocalStorage = function (key, value) {
        localStorage.setItem(key, value);
    };

    /**
     * 获取localStorage本地缓存
     * @param {any} key
     */
    var _getLocalStorage = function (key) {
        return localStorage.getItem(key);
    };

    /**
     * 删除localStorage本地缓存
     * @param {any} key
     */
    var _removeLocalStorage = function (key) {
        localStorage.removeItem(key);
        return _getLocalStorage(key) === null ? true : false;
    };

    /**
     * 清空localStorage本地缓存
     * */
    var _clearLocalStorage = function () {
        localStorage.clear();
        return true;
    }

    var Storage = {
        setLocalStorage: _setLocalStorage,
        getLocalStorage: _getLocalStorage,
        removeLocalStorage: _removeLocalStorage,
        clearLocalStorage: _clearLocalStorage
    };

    var View = {
        /**
         * 获取可用宽高
         * */
        getSize: function () {
            return { width: document.body.clientWidth, height: document.body.clientHeight };
        },
        /**
         * 获取可用宽度
         * */
        getWidth: function () {
            return document.body.clientWidth;
        },
        /**
         * 获取可用高度
         * */
        getHeight: function () {
            return document.body.clientHeight;
        }
    };

    var _ = {
        isFunction: isFunction,
        isObject: isObject,
        isArray: isArray,
        isString: isString,
        isNumber: isNumber,
        isBoolean: isBoolean,
        isNull: isNull,
        isUndefined: isUndefined,
        isDate: isDate,
        isEmpty: isEmpty,
        trim: trim,
        clearSpace: clearSpace,
        existCN: existCN,
        getDate: getDate,
        getTime: getTime,
        getWeek: getWeek,
        toCnDigit: toCnDigit,
        get: get,
        post: post,
        Cookie: Cookie,
        Storage: Storage,
        View: View,
    };

    GLOBAL._ = _;

    if (typeof module === "object" && typeof module.exports === "object") {
        module.exports = _;
    }
})();