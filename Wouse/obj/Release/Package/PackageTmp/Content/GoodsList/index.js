
var btnAct = {};
var search = {};
var SearchUser = {};


var winObj = null;
var openType = '';
var chooseData = {};
var layer, table;
var reload;

layui.use(function () {
    table = layui.table;
    layer = layui.layer;




    table.render({
        elem: '#demo',
        cols: [
            [ 
                {
                    field: 'ID',
                    title: 'ID',
                    width: 80,
                    sort: true
                }, {
                    field: 'GoodName',
                    title: '商品名称',
                    width: 120
                }, {
                    field: 'UnitPrice',
                    title: '成本价',
                    minWidth: 120,
                    sort: true
                }, {
                    field: 'Price',
                    title: '出售价',
                    minWidth: 120,
                    sort: true
                },{
                    field: 'DistributionFee',
                    title: '配送费',
                    width: 80
                }, {
                    field: 'profit',
                    title: '利润',
                    width: 80
                },{
                    field: 'CreateTime',
                    title: '日期',
                    width: 80
                }, {
                    field: "",
                    title: "",
                    width: 170,
                    templet: '#btn'
                }
            ]
        ],
        data: [],
        even: true,
        page: true, //是否显示分页
        limit: 10 //每页默认显示的数量
    });

    function open() {
        winObj = layer.open({
            type: 2,
            area: ['800px', '450px'],
            fixed: false, //不固定
            maxmin: true,
            content: 'http://localhost:57256/Home/GoodsDetail'
        });
    }

    search = function () {
        var searchCondition = $('#searchCondition').val();
        $.ajax({
            url: "/Home/GetGoodsList",
            data: {
                keyWord: searchCondition
            },
            success: function (res) {
                var data = JSON.parse(res);
                // 获取到 data
                table.reload('demo', {
                    data: data
                }, true)
            }
        });
    }



    reload = function () {
        // 此处调用查询接口
        $.ajax({
            url: "/Home/GetGoodsList",
            data: {
                keyWord: ""
            },
            success: function (res) {
                var data = JSON.parse(res);
                console.log(data);
                // 获取到 data
                table.reload('demo', {
                    data: data
                }, true)
            }
        });
    }

    btnAct = function (type, id) {
        openType = type;
        if (type == 'del') {
            layer.confirm('真的删除行么', function (index) {
                $.ajax({
                    url: "/Home/DelGoods",
                    data: {
                        ID: id
                    },
                    success: function (res) {
                        // 调用删除接口
                        reload();
                        layer.close(index);
                    }
                });
            });
            return
        }
        
        if (type == "SearchUser") {
            winObj = layer.open({
                type: 2,
                area: ['800px', '450px'],
                fixed: false, //不固定
                maxmin: true,
                content: 'http://localhost:44388/Home/UserList'
            });
        }
        if (type == "suanfa") {
            $.ajax({
                url: "/Home/suanfa",
                data: {
                    ID: id
                },
                success: function (res) {
                    var data = JSON.parse(res);
                    chooseData = data;
                }
            });
        }

        if (id) {
            // 此处调用 查询单条记录
            // $.ajax();
            // demo 写死
            //openType = type;
            $.ajax({
                url: "/Home/GetSingleGood",
                data: {
                    ID: id
                },
                success: function (res) {
                    var data = JSON.parse(res);
                    chooseData = data;
                }
            });
        } else {
            chooseData = {};
        }
        open();
    }
    reload();

});