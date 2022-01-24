$(document).ready(function () {
});
var GlobalFunc = function () {
    var userInfo = function () {
        var _temp = JSON.parse(decodeURIComponent(getCookie("UserInfo")));
        return JSON.parse(_temp);
    };
    var setCookie=function (key, value, expiry) {
        var expires = new Date();
        expires.setTime(expires.getTime() + (expiry * 24 * 60 * 60 * 1000));
        document.cookie = key + '=' + value + ';expires=' + expires.toUTCString();
    }

    var eraseCookie=function (key) {
        var keyValue = getCookie(key);
        setCookie(key, keyValue, '-1');
    }

    var getCookie=function (key) {
        const value = `; ${document.cookie}`;
        const parts = value.split(`; ${key}=`);
        if (parts.length === 2) return parts.pop().split(';').shift();
    }
    return {
        setCookie: function (key, value, expiry) {
            return setCookie(key, value, expiry);
        },
        eraseCookie: function (key) {
            return eraseCookie(key);
        },
        getCookie: function (key) {
            return getCookie(key);
        },
        userInfo: function () {
            return userInfo();
        }
    }
}();

