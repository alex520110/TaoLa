$(function () {
    query();
    $("#searchBtn").click(function () { query(); });
    AutoComplete();
})
$(function () {
    $("#inputStartDateLogin,#inputStartDate").datetimepicker({
        language: 'zh-CN',
        format: 'yyyy-mm-dd',
        autoclose: true,
        weekStart: 1,
        minView: 2
    });
    $("#inputEndDateLogin,#inputEndDate").datetimepicker({
        language: 'zh-CN',
        format: 'yyyy-mm-dd',
        autoclose: true,
        weekStart: 1,
        minView: 2
    });
    $("#inputStartDateLogin").click(function () {
        $('#inputEndDateLogin').datetimepicker('show');
    });
    $("#inputStartDate").click(function () {
        $('#inputEndDate').datetimepicker('show');
    });
    $("#inputEndDateLogin").click(function () {
        $('#inputStartDateLogin').datetimepicker('show');
    });
    $("#inputEndDate").click(function () {
        $('#inputStartDate').datetimepicker('show');
    });
    $("#inputStartDate").on('changeDate', function () {
        if ($("#inputEndDate").val()) {
            if ($("#inputStartDate").val() > $("#inputEndDate").val()) {
                $("#inputEndDate").val($("#inputStartDate").val());
            }
        }
        $("#inputEndDate").datetimepicker('setStartDate', $("#inputStartDate").val());
    });
    $("#inputStartDateLogin").on('changeDate', function () {
        if ($("#inputEndDateLogin").val()) {
            if ($("#inputStartDateLogin").val() > $("#inputEndDateLogin").val()) {
                $("#inputEndDateLogin").val($("#inputStartDateLogin").val());
            }
        }

        $("#inputEndDateLogin").datetimepicker('setStartDate', $("#inputStartDateLogin").val());
    });
    $('#btnAdvanceSearch').click(function () {
        $('#divAdvanceSearch').toggle();

        if($(this).hasClass('glyphicon-chevron-down')){
            $(this).removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-up")
        }else{
            $(this).addClass("glyphicon-chevron-down").removeClass("glyphicon-chevron-up")
        }
    });
});
function Delete(id) {
    $.dialog.confirm('确定删除该用户吗？', function () {
        var loading = showLoading();
        $.post("./Delete", { id: id }, function (data) { $.dialog.tips(data.msg); query(); loading.close();});
    });
}
function Lock(id) {
    $.dialog.confirm('确定冻结该用户吗？', function () {
        var loading = showLoading();
        $.post("./Lock", { id: id }, function (data) { $.dialog.tips(data.msg); query(); loading.close(); });
    });
}
function UnLock(id) {
    $.dialog.confirm('确定重新激活该用户吗？', function () {
        var loading = showLoading();
        $.post("./UnLock", { id: id }, function (data) { $.dialog.tips(data.msg); query(); loading.close(); });
    });
}

function BatchLock() {
    var selectedRows = $("#list").TaoLaDatagrid("getSelections");
 

    if (selectedRows.length == 0) {
        $.dialog.tips("你没有选择任何选项！");
    }
    else {
        var selectids=new Array();
        for (var i = 0; i < selectedRows.length; i++) {
            selectids.push(selectedRows[i].Id);
        }
        $.dialog.confirm('确定冻结选择的用户吗？', function () {
            var loading = showLoading();
            $.post("./BatchLock", { ids: selectids.join(',') }, function (data) { $.dialog.tips(data.msg); query(); loading.close(); });
        });
    }
}

function BatchDelete() {
    var selectedRows = $("#list").TaoLaDatagrid("getSelections");
    var selectids = new Array();

    for (var i = 0; i < selectedRows.length; i++) {
        selectids.push(selectedRows[i].Id);
    }
    if (selectedRows.length == 0) {
        $.dialog.tips("你没有选择任何选项！");
    }
    else {
        $.dialog.confirm('确定删除选择的用户吗？', function () {
            var loading = showLoading();
            $.post("./BatchDelete", { ids: selectids.join(',') }, function (data) { $.dialog.tips(data.msg); query(); loading.close(); });
        });
    }
}

function query() {
    var rtstart, rtend, ltstart, ltend,isseller,isfocus,labelid;
    if ($('#divAdvanceSearch').css('display') != 'none') {
        rtstart = $("#inputStartDate").val();
        rtend = $("#inputEndDate").val();
        ltstart = $("#inputStartDateLogin").val();
        ltend = $("#inputEndDateLogin").val();
        if ($('#sellerYes').get(0).checked || $('#sellerNo').get(0).checked) {
            isseller = $('#sellerYes').get(0).checked;
        }
        if ($('#focusYes').get(0).checked || $('#focusNo').get(0).checked) {
            isfocus = $('#focusYes').get(0).checked;
        }
    }
    if ($('#labelSelect').val() > 0) {
        labelid = $('#labelSelect').val();
    }
    $("#list").TaoLaDatagrid({
        url: './list',
        nowrap: false,
        rownumbers: true,
        NoDataMsg: '没有找到符合条件的数据',
        border: false,
        fit: true,
        fitColumns: true,
        pagination: true,
        idField: "Id",
        pageSize: 10,
        pageNumber: 1,
        queryParams: { keyWords: $("#autoTextBox").val(),labelid:labelid,isSeller:isseller,isFocus:isfocus,regtimeStart:rtstart,regtimeEnd:rtend,logintimeStart:ltstart,logintimeEnd:ltend },
        toolbar: /*"#goods-datagrid-toolbar",*/'',
        operationButtons:"#batchOperate",
        columns:
        [[
            { checkbox: true, width: 39 },
            { field: "Id", hidden: true },
            { field: "UserName", title: '会员名' },
            { field: "Nick", title: '微信昵称' },
            {  field: "StrLastLoginDate", title: '最后登录日期'  },
            { field: "CellPhone", title: '手机' },
            { field: "StrCreateDate", title: '创建日期' },
            {
                field: "Disabled", title: '状态',
                formatter: function (value, row, index) {
                    var html = "";
                    if (row.Disabled)
                        html += '冻结';
                    else
                        html += '正常';
                    return html;
                }
            },
        {
            field: "operation", operation: true, title: "操作",
            formatter: function (value, row, index) {
                var id = row.Id.toString();
                var html = ["<span class=\"btn-a\">"];
                html.push("<a onclick=\"AddLabel('" + id + "');\">编辑标签</a>");
                html.push("<a onclick=\"Show('" + id + "');\">查看</a>");
                html.push("<a onclick=\"ChangePassWord('" + id + "');\">修改密码</a>");
                //if (row.Disabled)
                //    html.push("<a onclick=\"UnLock('" + id + "');\">解冻</a>");
                //    else
                //    html.push("<a onclick=\"Lock('" + id + "');\">冻结</a>");
                //html.push("<a onclick=\"Delete('" + id + "');\">删除</a>");

                html.push("</span>");
                return html.join("");
            }
        }
        ]]
    });
}

function AddLabel(memberid)
{
    if ($('input[name=check_Label]').length == 0)
    {
        $.dialog.alert('没有可添加的标签，请到标签管理添加！');
        return;
    }
    $.ajax({
        type: 'post',
        url: 'GetMemberLabel',
        data: { id: memberid },
        success: function (data) {
            $('input[name=check_Label]').each(function (i, checkbox) {
                $(checkbox).get(0).checked = false;
            });
            $.each(data.Data, function (i, item) {
                $('#check_' + item.LabelId).get(0).checked = true;
            });
            $.dialog({
                title: '会员标签',
                lock: true,
                id: 'SetLabel',
                width: '600px',
                content: document.getElementById("divSetLabel"),
                padding:0,
                okVal: '确定',
                ok: function () {
                    var ids = [];
                    $('input[name=check_Label]').each(function (i, checkbox) {
                        if ($(checkbox).get(0).checked )
                        {
                            ids.push($(checkbox).attr('datavalue'));
                        }
                    });
                    var loading = showLoading();
                    $.post('SetMemberLabel', { id: memberid, labelids: ids.join(',') }, function (result) {
                        if (result.Success)
                        {
                            query();
                            $.dialog.tips('设置成功！');
                        }
                        loading.close();
                    });
                }
            });
        }
    });
    
}

function batchAddLabels() {
    var selecteds = $("#list").TaoLaDatagrid('getSelections');
    var ids = [];
    $.each(selecteds, function () {
        ids.push(this.Id);
    });
    if (ids.length == 0) {
        $.dialog.tips('请选择会员！');
        return;
    }
    $('input[name=check_Label]').each(function (i, checkbox) {
        $(checkbox).get(0).checked = false;
    });

    $.dialog({
        title: '会员标签',
        lock: true,
        id: 'SetLabel',
        width: '400px',
        content: document.getElementById("divSetLabel"),
        padding: '20px 10px',
        okVal: '确定',
        ok: function () {
            var labelids = [];
            $('input[name=check_Label]').each(function (i, checkbox) {
                if ($(checkbox).get(0).checked) {
                    labelids.push($(checkbox).attr('datavalue'));
                }
            });
            var loading = showLoading();
            $.post('SetMembersLabel', { ids: ids.join(','), labelids: labelids.join(',') }, function (result) {
                if (result.Success) {
                    query();
                    $.dialog.tips('设置成功！');
                }
                loading.close();
            });
        }
    });
}
function ChangePassWord(id)
{
    $.dialog({
        title: '修改密码',
        lock: true,
        id: 'ChangePwd',
        width: '400px',
        content: document.getElementById("dialogform"),
        padding: '20px 10px',
        okVal: '确定',
        init: function () { $("#password").focus();},
        ok: function () {
            var passwpord = $("#password").val();
            if (passwpord.length < 6) {
                $.dialog.errorTips("密码长度至少是6位！");
                return false;
            }
            var loading = showLoading();
            $.post("./ChangePassWord", { id: id, password: passwpord }, function (data) { $.dialog.tips(data.msg); $("#password").val(""); loading.close(); });
        }
    });

}

function AutoComplete() {
    //autocomplete
    $('#autoTextBox').autocomplete({
        source: function (query, process) {
            var matchCount = this.options.items;//返回结果集最大数量
            $.post("./getMembers", { "keyWords": $('#autoTextBox').val()}, function (respData) {
                return process(respData);
            });
        },
        formatItem: function (item) {
            return item.value;
        },
        setValue: function (item) {
            return { 'data-value': item.value, 'real-value': item.key };
        }
    });
}