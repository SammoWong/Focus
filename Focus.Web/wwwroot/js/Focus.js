; (function () {
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
        return obj && _toString.call(value) === "[object Object]";
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
     * 去除字符串左右空格
     * @param {any} value
     */
    var trim = function (value) {
        if (!isString(value)) {
            return value;
        }
        return value.replace(/(^\s*)|(\s*$)/g, '');
    };

    /**
     * 去除字符串中的空格
     * @param {any} value
     */
    var clearSpace = function (value) {
        if (!isString(value)) {
            return value;
        }
        return value.replace(/[ ]/g, '');
    }

    /**
     * 判断字符串是否包含中文
     * @param {any} value
     */
    var existCN = function (value) {
        if (!isString(value)) {
            return value;
        }
        return /.*[\u4e00-\u9fa5]+.*$/.test(value);
    }

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
        trim: trim,
        clearSpace: clearSpace,
        existCN: existCN,
    };

    GLOBAL._ = _;

    if (typeof module === "object" && typeof module.exports === "object") {
        module.exports = _;
    }
})();