(function (Date) {
    // 对Date的扩展，将 Date 转化为指定格式的String  
    // 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符，   
    // 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)   
    // 例子：   
    // (new Date()).ToString("yyyy-MM-dd hh:mm:ss.fff") ==> 2006-07-02 08:09:04.423
    // (new Date()).ToString("yyyy-M-d h:m:s.fff")      ==> 2006-7-2 8:9:4.18
    Date.prototype.ToString = function (fmt) {
        if (!fmt) {
            fmt = "yyyy-MM-dd HH:mm:ss.fff";
        }
        var o = {
            "M+": this.getMonth() + 1,
            "d+": this.getDate(),
            "H+": this.getHours(),
            "m+": this.getMinutes(),
            "s+": this.getSeconds(),
            "f+": this.getMilliseconds()
        };

        if (/(y+)/.test(fmt)) {
            fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        }
        for (var k in o) {
            if (new RegExp("(" + k + ")").test(fmt)) {
                fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(String(o[k]).length)));
            }
        }
        return fmt;
    };

    Date.prototype.AddYears = function (value) {
        var year = this.getFullYear();
        year = year + value;
        this.setFullYear(year);
        return this;
    };

    Date.prototype.AddMonths = function (value) {
        value = Math.floor(value);
        var year = this.getFullYear();
        var month = this.getMonth();

        year = year + value / 12;
        month = (value % 12) + month;
        if (month > 12) {
            year = year + 1;
            month = month % 12;
        }
        this.setFullYear(year);
        this.setMonth(month);
        return this;
    };

    Date.prototype.AddDays = function (value) {
        var millisec = this.getTime();
        millisec = millisec + (value * 86400000);
        this.setTime(millisec);
        return this;
    };

    Date.prototype.AddHours = function (value) {
        var millisec = this.getTime();
        millisec = millisec + (value * 3600000);
        this.setTime(millisec);
        return this;
    };

    Date.prototype.AddMinutes = function (value) {
        var millisec = this.getTime();
        millisec = millisec + (value * 60000);
        this.setTime(millisec);
        return this;
    };

    Date.prototype.AddSeconds = function (value) {
        var millisec = this.getTime();
        millisec = millisec + (value * 1000);
        this.setTime(millisec);
        return this;
    };

    Date.prototype.AddMilliseconds = function (value) {
        var millisec = this.getTime();
        millisec = millisec + value;
        this.setTime(millisec);
        return this;
    };

})(window.Date);