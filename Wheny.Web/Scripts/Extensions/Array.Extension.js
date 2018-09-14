//对数组的扩展
(function (Array) {
    //按条件返回
    Array.prototype.Where = function (clause) {
        //The clause was passed in as a Method that return a Boolean
        var newArray = [];
        for (var i = 0; i < this.length; i++) {
            if (clause.apply(this[i], [this[i], i])) {
                newArray[newArray.length] = this[i];
            }
        }
        return newArray;
    };

    Array.prototype.Single = function (clause) {
        for (var i = 0; i < this.length; i++) {
            if (clause.apply(this[i], [this[i], i])) {
                return this[i];
            }
        }
        return null;
    }

    //取出部分字段
    Array.prototype.Select = function (clause) {
        var newArray = [];
        for (var i = 0; i < this.length; i++) {
            item = clause.apply(this[i], [this[i]]);
            if (item) {
                newArray[newArray.length] = item;
            }
        }
        return newArray;
    };

    //排序
    Array.prototype.OrderBy = function (clause) {
        this.sort(function (a, b) {
            var x = clause.apply(a, [a]);
            var y = clause.apply(b, [b]);
            return ((x < y) ? -1 : ((x > y) ? 1 : 0));
        })
    };

    //移除所有匹配项
    Array.prototype.Delete = function (clause) {
        for (var i = 0; i < this.length; i++) {
            if (clause.apply(this[i], [this[i]])) {
                this.splice(i, 1);
                i--;
            }
        }
    };

    //是否存在
    Array.prototype.Exists = function (clause) {
        for (var i = 0; i < this.length; i++) {
            if (clause.apply(this[i], [this[i]])) {
                return true;
            }
        }
        return false;
    };

})(window.Array);
