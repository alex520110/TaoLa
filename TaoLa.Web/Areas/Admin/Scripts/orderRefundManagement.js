
$(function () {
    var status = GetQueryString("status");
    var li = $("li[value='" + status + "']");
    if (li.length > 0) {
        typeChoose('5')
    } else {
        typeChoose('')
    }

    //订单表格

    function typeChoose(val) {
        $('.nav li').each(function () {
            if ($(this).val() == val) {
                $(this).addClass('active').siblings().removeClass('active');
            }
        });
        //组合显示字段
        try {
            showtype = parseInt(showtype, 10);
        } catch (ex) {
            showtype = 0;
        }
        datacols = [[
                { field: "OrderId", title: '订单号', width: 100 },
                    { field: "ShopName", title: "店铺", width: 120, align: "left" },
                    {
                        field: "ProductName", title: "商品", width: 280, align: "left",
                        formatter: function (value, row, index) {
                            var html = ""
                            if (row.RefundMode == 1) {
                                html = "订单所有商品";
                            } else {
                                html = '<img style="margin-left:15px;" width="40" height="40" src="' + row.ThumbnailsUrl + '"/>' + '<span class="overflow-ellipsis" style="width:200px"><a title="' + value + '" href="/product/detail/' + row.ProductId + '" target="_blank">' + value + '</a></span>';
                            }
                            return html;
                        }
                    },
                    { field: "UserName", title: "买家", width: 80, align: "left" },
                    { field: "ApplyDate", title: "申请日期", width: 70, align: "left" },
                    {
                        field: "Amount", title: "退款", width: 90, align: "left",
                        formatter: function (value, row, index) {
                            var html = "<span class='ftx-04'>" + '￥' + value + "</span>";
                            return html;
                        }
                    }]];
        switch (showtype) {
            case 0:
            case 3:
                datacols[0].push({ field: "ReturnQuantity", title: "退货", width: 50, align: "left" });
                break;
        }

        datacols[0] = datacols[0].concat([
            { field: "AuditStatus", title: "处理状态", width: 100, align: "left" },
            {
                field: "operation", operation: true, title: "操作", width: 100,
                formatter: function (value, row, index) {
                    var html = ["<span class=\"btn-a\">"];
                    html.push("<input type=\"hidden\" name=\"rowdata\" id=\"rowdata-" + row.RefundId + "\" value='" + jQuery.toJSON(row) + "'>");
                    if (row.AuditStatus == "商家通过审核" || row.AuditStatus == "待平台确认" || row.AuditStatus == "退款中") {
                        html.push("<a class=\"good-check\" onclick=\"OpenConfirmRefund('" + row.RefundId + "')\">确认退款</a>");
                    } else {
                        html.push("<a class=\"good-check\" onclick=\"OpenRefundReason('" + row.RefundId + "')\">查看原因</a>");
                    }
                    html.push("</span>");
                    return html.join("");
                }
            }
        ]);

        $("#list").hiMallDatagrid({
            url: './list?showtype=' + showtype,
            nowrap: true,
            rownumbers: true,
            NoDataMsg: '没有找到符合条件的数据',
            border: false,
            fit: true,
            fitColumns: true,
            pagination: true,
            idField: "RefundId",
            pageSize: 15,
            pagePosition: 'bottom',
            pageNumber: 1,
            queryParams: { auditStatus: val },
            columns: datacols
        });
    }

    $('#searchButton').click(function (e) {
        searchClose(e);
        var startDate = $("#inputStartDate").val();
        var endDate = $("#inputEndDate").val();
        var orderId = $.trim($('#txtOrderId').val());
        var shopName = $.trim($('#txtShopName').val());
        var productName = $.trim($('#txtProductName').val());
        var userName = $.trim($('#txtUserName').val());
        $("#list").hiMallDatagrid('reload', { startDate: startDate, endDate: endDate, orderId: orderId, shopName: shopName, productName: productName, userName: userName });
    })


    $('.nav li').click(function (e) {
        searchClose(e);
        $(this).addClass('active').siblings().removeClass('active');
        if ($(this).attr('type') == 'statusTab') {//状态分类
            $('#txtOrderId').val('');
            $('#txtShopName').val('');
            $('#txtUserName').val('');
            $("#txtProducdName").val('');
            $("#list").hiMallDatagrid('reload', { auditStatus: $(this).attr('value') || null });
        }
    });
});

function OpenConfirmRefund(refundId) {
    var dobj = $("#rowdata-" + refundId);
    var data = jQuery.parseJSON(dobj.val());
    $.dialog({
        title: '确认退款',
        width: 500,
        lock: true,
        id: 'goodCheck',
        content: ['<div class="dialog-form">',
            '<div class="form-group">',
                '<label class="label-inline fl">原因</label>',
                '<p class="help-top">' + data.Reason.replace(/>/g, '&gt;').replace(/</g, '&lt;') + '</p>',
            '</div>',
             '<div class="form-group">',
                '<label class="label-inline fl">联系人</label>',
                '<p class="help-top">' + data.ContactPerson.replace(/>/g, '&gt;').replace(/</g, '&lt;') + '</p>',
           ' </div>',
            '<div class="form-group">',
                '<label class="label-inline fl">联系方式</label>',
                '<p class="help-top">' + data.ContactCellPhone + '</p>',
           ' </div>',
            '<div class="form-group">',
                '<label class="label-inline fl">退款金额</label>',
                '<p class="only-text"><span class="cor-red">' + data.Amount + '</span></p>',
           ' </div>',
            '<div class="form-group">',
                '<label class="label-inline fl">退款方式</label>',
                '<p class="help-top">' + data.RefundPayType + '</p>',
           ' </div>',

		   '<div class="form-group">',
		   		'<label class="label-inline fl">退款备注</label>',
                '<textarea id="txtRefundRemark" class="form-control" cols="40" rows="2">' + data.ManagerRemark.replace(/>/g, '&gt;').replace(/</g, '&lt;') + '</textarea>\
                <span class="field-validation-error" id="orderRefundCotentTip"></span> ',
            '</div>',
        '</div>'].join(''),
        padding: '10px',
        init: function () { $("#txtRefundRemark").focus(); },
        button: [
        {
            name: data.RefundPayStatus == 0 ? '完成支付' : '确认退款',
            callback: function () {
                var replycontent = $("#txtRefundRemark").val();
                if (replycontent.length > 200) {
                    $("#orderRefundCotentTip").text("回复内容在200个字符以内");
                    $("#txtRefundRemark").css({ border: '1px solid #f60' });
                    return false;
                }
                ConfirmRefund(refundId, $('#txtRefundRemark').val());
            },
            focus: true
        }]
    });
}

function OpenRefundReason(refundId) {
    var dobj = $("#rowdata-" + refundId);
    var data = jQuery.parseJSON(dobj.val());

    dlgcontent = ['<div class="dialog-form">',
            '<div class="form-group">',
                '<label class="label-inline fl">原因</label>',
                '<p class="help-top">' + data.Reason.replace(/>/g, '&gt;').replace(/</g, '&lt;') + '</p>',
            '</div>'];

    dlgcontent = dlgcontent.concat(['<div class="form-group">',
                '<label class="label-inline fl">联系人</label>',
                '<p class="help-top">' + data.ContactPerson.replace(/>/g, '&gt;').replace(/</g, '&lt;') + '</p>',
           ' </div>',
            '<div class="form-group">',
                '<label class="label-inline fl">联系方式</label>',
                '<p class="help-top">' + data.ContactCellPhone + '</p>',
           ' </div>',
            '<div class="form-group">',
                '<label class="label-inline fl">退款金额</label>',
                '<p class="only-text"><span class="cor-red">' + data.Amount + '</span></p>',
           ' </div>',
            '<div class="form-group">',
                '<label class="label-inline fl">退款方式</label>',
                '<p class="help-top">' + data.RefundPayType + '</p>',
           ' </div>']);
    if (data.SellerRemark) {
        dlgcontent = dlgcontent.concat([
                '<div class="form-group">',
                    '<label class="label-inline fl">商家处理</label>',
                    '<p class="help-top">' + data.SellerRemark.replace(/>/g, '&gt;').replace(/</g, '&lt;') + '</p>',
               ' </div>']);
    }
    if (data.ManagerRemark) {
        dlgcontent = dlgcontent.concat([
                '<div class="form-group">',
                    '<label class="label-inline fl">平台备注</label>',
                    '<p class="help-top">' + data.ManagerRemark.replace(/>/g, '&gt;').replace(/</g, '&lt;') + '</p>',
               ' </div>']);
    }
    dlgcontent = dlgcontent.concat(['</div>']);

    $.dialog({
        title: '查看原因',
        lock: true,
        id: 'goodCheck',
        width: '400px',
        content: dlgcontent.join(''),
        padding: '20px 10px'
    });
}


function ConfirmRefund(refundId, managerRemark) {
    var loading = showLoading();
    $.post('./ConfirmRefund', { refundId: refundId, managerRemark: managerRemark }, function (result) {
        loading.close();
        if (result.success) {
            if (result.status == 2) {
                jumpurl = result.msg;
                //var urlform = $(BuildGetForm('refundpay_form', jumpurl, '_blank'));
                //urlform.submit();
                //urlform.remove();
                window.open(jumpurl);
                $.dialog({
                    title: '登录平台完成退款',
                    lock: true,
                    content: '<p>请您在新打开的支付平台页面进行退款，退款完成前请不要关闭该窗口</p>',
                    padding: '30px 20px',
                    button: [
                    {
                        name: '已完成退款',
                        callback: function () {
                            var pageNo = $("#list").hiMallDatagrid('options').pageNumber;
                            $("#list").hiMallDatagrid('reload', { pageNumber: pageNo });
                        }
                    },
                    {
                        name: '支付遇到问题',
                        callback: function () { }
                    }]
                });
            } else {
                $.dialog.succeedTips("操作成功！");
                var pageNo = $("#list").hiMallDatagrid('options').pageNumber;
                $("#list").hiMallDatagrid('reload', { pageNumber: pageNo });
            }
        }
        else {
            $.dialog.errorTips("操作失败");
        }
    });
}

function BuildGetForm(fm, url, target) {
    var e = null, el = [];
    if (!fm || !url)
        return e;
    target = target || '_blank';
    e = document.getElementById(fm);
    if (!e) {
        e = document.createElement('Form');
        e.Id = fm;
        document.body.appendChild(e);
    }
    alert(url);
    e.method = 'get';
    e.target = target;
    e.style.display = 'none';
    e.action = url;
    return e;
};

function BuildPostForm(fm, url, target) {
    var e = null, el = [];
    if (!fm || !url)
        return e;
    target = target || '_blank';
    e = document.getElementById(fm);
    if (!e) {
        e = document.createElement('Form');
        e.Id = fm;
        document.body.appendChild(e);
    }

    e.method = 'post';
    e.target = target;
    e.style.display = 'none';
    e.enctype = 'application/x-www-form-urlencoded';

    var idx = url.indexOf('?');
    var para = [], op = [];
    if (idx > 0) {
        para = url.substring(idx + 1, url.length).split('&');
        url = url.substr(0, idx);//截取URL
        var keypair = [];
        for (var p = 0 ; p < para.length; p++) {
            idx = para[p].indexOf('=');
            if (idx > 0) {
                el.push('<input type="hidden" name="' + para[p].substr(0, idx) + '" id="frm' + para[p].substr(0, idx) + '" value="' + para[p].substring(idx + 1, para[p].length) + '" />');
            }
        }
    }

    e.innerHTML = el.join('');
    e.action = url;
    return e;
};