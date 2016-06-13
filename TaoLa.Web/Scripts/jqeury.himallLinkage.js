//多级联动

(function ($) {
    var container;

    function getData(url,level,key) {
        var data;
        $.ajax({
            url: url,
            async: false,
            data: { level: level, key: key },
            type: "post",
            dataType: "json",
            success: function (returnData) {
                data = returnData;
            }
        });
        return data;
    }

    var selectors = [];

    var selectedItems = [];

    function clear(startIndex) {
        for (var i = startIndex; i < selectors.length; i++) {
            if (selectors[i]) {
                selectors[i].remove();
                selectors[i] = null;
            }
        }
    }

    function drawSelect(level, key) {
        var newLevel = level + 1;
        var selector = selectors[newLevel];
        if (key == $.fn.TaoLaLinkage.options.defaultItemsValue[level])
            clear(newLevel);
        if (!selector) {
            selector = $('<select class="' + $.fn.TaoLaLinkage.options.styleClass + '"></select>');
            selectors[newLevel] = selector;
            selector.appendTo(container);
        }
        else {
            clear(newLevel + 1);
        }

        selector.empty();
        var data = getData($.fn.TaoLaLinkage.options.url, level, key);
        if (data.length > 0) {
            if ($.fn.TaoLaLinkage.options.enableDefaultItem) {
                var text = '<option ';
                if ($.fn.TaoLaLinkage.options.defaultItemsValue[newLevel])
                    text += ' value="' + $.fn.TaoLaLinkage.options.defaultItemsValue[newLevel] + '"';
                text += '>' + $.fn.TaoLaLinkage.options.defaultItemsText[newLevel] + '</option>';
                selector.append(text);
            }
            $.each(data, function (i, item) {
                selector.append('<option value="' + (item.key ? item.key : item.Key) + '">' + (item.value ? item.value : item.Value) + '</option>');
            });

            selector.unbind('change').change(function (item) {
                selectedItems[newLevel] = $(this).val();
                if (newLevel < $.fn.TaoLaLinkage.options.level - 1)
                    drawSelect(newLevel, $(this).val());
                if ($.fn.TaoLaLinkage.options.onChange)
                    $.fn.TaoLaLinkage.options.onChange(newLevel, $(this).val(), $(this).text());
            });
        }
        else
            clear(newLevel);
    }


    function setDefaultItem() {
        if ($.fn.TaoLaLinkage.options.enableDefaultItem) {
            if (!$.isArray($.fn.TaoLaLinkage.options.defaultItemsValue)) {
                var arr = [];
                var defaultVallue = $.fn.TaoLaLinkage.options.defaultItemsValue;
                if (defaultVallue == null)
                    defaultVallue = '';
                var i = $.fn.TaoLaLinkage.options.level;
                while (i--) arr.push(defaultVallue);
                $.fn.TaoLaLinkage.options.defaultItemsValue = arr;
            }
            else if ($.fn.TaoLaLinkage.options.defaultItemsValue.length < $.fn.TaoLaLinkage.options.level) {
                var less = $.fn.TaoLaLinkage.options.level - $.fn.TaoLaLinkage.options.defaultItemsValue.length;
                while (less--)
                    $.fn.TaoLaLinkage.options.defaultItemsValue.push('');
            }

            if (!$.isArray($.fn.TaoLaLinkage.options.defaultItemsText)) {
                var arr = [];
                var defaultText = $.fn.TaoLaLinkage.options.defaultItemsText;
                if (defaultText == null)
                    defaultText = '请选择';
                var i = $.fn.TaoLaLinkage.options.level;
                while (i--) arr.push(defaultText);
                $.fn.TaoLaLinkage.options.defaultItemsText = arr;
            }
            else {
                var itemLength = $.fn.TaoLaLinkage.options.defaultItemsText.length;
                if (itemLength < $.fn.TaoLaLinkage.options.level) {
                    var less = $.fn.TaoLaLinkage.options.level - itemLength;
                    while (less--)
                        $.fn.TaoLaLinkage.options.defaultItemsText.push('请选择');
                }
            }
        }
    }

    $.fn.TaoLaLinkage = function (options, params) {
        /// <param name="params" type="object">$.fn.TaoLaLinkage.options</param>

        if (typeof options == "string") {
            return $.fn.TaoLaLinkage.methods[options](this, params);
        }

        container = $(this);
        $.fn.TaoLaLinkage.options = $.extend({}, $.fn.TaoLaLinkage.options, options);
        setDefaultItem();
        drawSelect(-1);
        return $;
    }

    $.fn.TaoLaLinkage.options = {
        level: 1,//级数
        url: null,//调用地址
        selectorWidth: 120,//select框宽度
        styleClass: '',//select框样式
        enableDefaultItem: false,//是否显示默认项（即未选中时的项）
        defaultItemsText: [],//默认文本，可以是数组，也可以是统一的值
        defaultItemsValue: [],//默认值，可以是数组，也可以是统一的值
        onChange:null//select 的change事件
    };


    $.fn.TaoLaLinkage.methods = {
        value: function (jquery,level) {
            return selectedItems[level];
        }
    }

})(jQuery);