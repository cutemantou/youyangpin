import {
    api as ajax,
} from 'services';

import Clipboard from 'clipboard';

const clipboard = new Clipboard('.copyBtn');
export default {
    data() {
        return {
            menus: [{
                title: '我的订单',
                key: '1',
                path: '/order',
            }, {
                title: '申请记录',
                key: '2',
                path: '/applyrecord',
            }, {
                title: '运费提现',
                key: '3',
                path: '/freight',
            }, {
                title: '个人信息',
                key: '4',
                path: '/user',
            }, {
                title: '修改密码',
                key: '5',
                path: '/modifypwd',
            }],
            status: [{
                name: '所有订单',
                key: 'order0',
            }, {
                name: '待发货',
                key: 'order1',
            }, {
                name: '已发货',
                key: 'order2',
            }, {
                name: '已到货',
                key: 'order3',
            }, {
                name: '待退货',
                key: 'order4',
            }, {
                name: '已退货',
                key: 'order5',
            }, {
                name: '待退费',
                key: 'order6',
            }, {
                name: '已完成',
                key: 'order7',
            }, {
                name: '异常订单',
                key: 'order8',
            }],
            searchCondition: {},
            pageIndex: 1,
            itemsPerPage: 10,
            total: 0,
            currentStatu: '',
            pageList: [],
            asideIndex: '1',
            textarea: '',
            activeName: 'order0',
            dialogVisible1: false,
            dialogVisible2: false,
            dialogVisible3: false,
            dialogVisible4: false,
            dialogVisible5: false,
            dialogVisible6: false,
            dialogVisible7: false,
            activeIndex: '2',
            form: {
                date: '',
            },
            form3: {
                logisticName: '',
                logisticNo: '',
                postage: '',
            },
            form4: {
                description: '',
                star: 0,
            },
            good: {},
            order: {},
            orderId: null,
            options: [{
                value: '顺丰速运',
                label: '顺丰速运',
            }, {
                value: '百世快递',
                label: '百世快递',
            }, {
                value: '中通快递',
                label: '中通快递',
            }, {
                value: '申通快递',
                label: '申通快递',
            }, {
                value: '圆通速递',
                label: '圆通速递',
            }, {
                value: '韵达速递',
                label: '韵达速递',
            }, {
                value: '邮政快递包裹',
                label: '邮政快递包裹',
            }, {
                value: 'EMS',
                label: 'EMS',
            }, {
                value: '天天快递',
                label: '天天快递',
            }, {
                value: '全峰快递',
                label: '全峰快递',
            }, {
                value: '国通快递',
                label: '国通快递',
            }, {
                value: '优速快递',
                label: '优速快递',
            }, {
                value: '德邦',
                label: '德邦',
            }, {
                value: '快捷快递',
                label: '快捷快递',
            }, {
                value: '宅急送',
                label: '宅急送',
            }, {
                value: '汇通快递',
                label: '汇通快递',
            }],
            value: '',
            rule1: {
                date: [{
                    required: true,
                    message: '请选择日期',
                    trigger: 'change',
                }],
            },
            rule3: {
                logisticName: [{
                    required: true,
                    message: '请选择物流公司',
                    trigger: 'change',
                }],
                logisticNo: [{
                    required: true,
                    message: '请输入物流编号',
                    trigger: 'blur',
                }],
                postage: [{
                    required: true,
                    message: '请输入邮费',
                    trigger: 'blur',
                }],
            },
            pickerOptions0: {
                disabledDate(time) {
                    return time.getTime() < Date.now() - 8.64e7;
                },
            },
        };
    },
    created() {
        clipboard.on('success', () => {
            this.$message({
                type: 'success',
                message: '复制成功',
            });
        });
        clipboard.on('error', (e) => {
            //  不支持复制
            this.$message({
                type: 'error',
                message: '该浏览器不支持自动复制',
            });
        });
        this.currentStatu = this.status[0].name === '所有订单' ? '' : this.status[0].name;
        this.getPagedOrder();
    },
    methods: {
        handleClick(tab, event) {
            this.pageIndex = 1;
            this.currentStatu = (tab.label === '所有订单' ? '' : tab.label);
            this.getPagedOrder();
        },
        getPagedOrder(orderStatus, broadcastSchedulingStatus, goodsNameOrExpressNumber) {
            ajax.getPagedOrder(orderStatus || this.currentStatu, broadcastSchedulingStatus || '', goodsNameOrExpressNumber || '', this.pageIndex, this.itemsPerPage).then((result) => {
                this.pageList = result.Orders;
                this.total = result.RecordCount;
            });
        },
        handleSizeChange(val) {
            this.itemsPerPage = val;
            this.getPagedOrder();
        },
        handleCurrentChange(val) {
            this.pageIndex = val;
            this.getPagedOrder();
        },
        handleSelect(key, keyPath) {
            this.$router.push(this.menus[key - 1].path);
        },
        //  排期
        showDialog2(order) {
            this.orderId = order.OrderID;
            this.form.date = order.BroadcastScheduling;
            this.dialogVisible2 = true;
        },
        setBroadcastScheduling() {
            this.$refs.form.validate((valid) => {
                if (valid) {
                    ajax.setBroadcastScheduling(this.orderId, this.form)
                        .then((result) => {
                            this.$message({
                                type: 'success',
                                message: '保存成功',
                            });
                            this.dialogVisible2 = false;
                            this.getPagedOrder();
                        });
                    return true;
                }

                return false;
            });
        },
        //  评价
        showDialog4(order) {
            this.orderId = order.OrderID;
            this.dialogVisible4 = true;
            this.form4.description = order.StudioHosToMerchant;
            this.form4.star = order.StudioHosGiveMerchantStars;
        },
        setAssessment() {
            ajax.setAssessment(this.orderId, this.form4)
                .then((result) => {
                    this.$message({
                        type: 'success',
                        message: '保存成功',
                    });
                    this.dialogVisible4 = false;
                    this.getPagedOrder();
                });
        },
        //  申请定向
        showDialog1(order) {
            this.orderId = order.OrderID;
            this.dialogVisible1 = true;
            this.good = order.Goods[0];
        },
        //  卖点介绍
        showDialog5(good) {
            this.dialogVisible5 = true;
            this.good = good;
        },
        //  查看物流信息
        showDialog6(order) {
            this.dialogVisible6 = true;
            this.order = order;
        },
        //  查看异常原因
        showDialog7(order) {
            this.dialogVisible7 = true;
            this.order = order;
        },
        requestDirectionalPlan() {
            ajax.requestDirectionalPlan(this.orderId)
                .then((result) => {
                    this.$message({
                        type: 'success',
                        message: '操作成功',
                    });
                    this.dialogVisible1 = false;
                    this.getPagedOrder();
                });
        },
        //  填写物流信息
        showDialog3(order) {
            this.orderId = order.OrderID;
            this.form3 = {
                logisticName: order.TuiHuoLogisticName,
                logisticNo: order.TuiHuoLogisticNo,
                postage: order.TuiHuoPostage,
            };
            this.dialogVisible3 = true;
        },
        setLogisticsInfo() {
            this.$refs.form3.validate((valid) => {
                if (valid) {
                    ajax.setLogisticsInfo(this.orderId, this.form3)
                        .then((result) => {
                            this.$message({
                                type: 'success',
                                message: '保存成功',
                            });
                            this.dialogVisible3 = false;
                            this.getPagedOrder();
                        });
                    return true;
                }
                return false;
            });
        },
        search() {
            this.getPagedOrder(
                this.searchCondition.OrderStatus === '全部' ? '' : this.searchCondition.OrderStatus,
                this.searchCondition.BroadcastSchedulingStatus === '全部' ? '' : this.searchCondition.BroadcastSchedulingStatus,
                this.searchCondition.GoodsNameOrExpressNumber
            );
        },
        formatDate(date, type) {
            return this.util.formatDate(date, type);
        },
        cutString(str, len) {
            return this.util.cutString(str, len);
        },
    },
};