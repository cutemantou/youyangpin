import { api as ajax } from 'services'

import { mapGetters, mapActions } from 'vuex'

export default {
    data () {
        return {
            searchForm: {
                pageIndex: 1,
                itemsPerPage: 32,
                pageList: [],
                total: 0,
                goodsName: '',
                verticalFieldCode: '',
                activityType: '',
                lowSales: '',
                highSales: '',
                lowDailyPrice: '',
                highDailyPrice: '',
                lowCommissionRatio: '',
                highCommissionRatio: '',
                sortField: '',
                sort: ''
            },
            sortValue: 0
        }
    },
    watch: {
        '$route'() {
            if (this.$route.query.keywords) {
                this.searchForm.goodsName = this.$route.query.keywords;
                this.searchForm.pageIndex = 1;
                this.goodsSearch()
            }
            else {
                this.searchForm.goodsName = '';
                this.searchForm.pageIndex = 1;
                this.goodsSearch()
            }
        }
    },
    created() {
        if (this.$route.query.keywords) {
            this.searchForm.goodsName = this.$route.query.keywords
        }
        this.goodsSearch();
        this.getStatistics()
    },
    computed: {
        ...mapGetters([
            'statistics'
        ])
    },
    methods: {
        ...mapActions([
            'setStatistics'
        ]),
        goodsSearch() {
            ajax.goodSearch(this.searchForm).then((result) => {
                console.log(result);
                this.pageList = result.Goods;
                this.total = result.RecordCount
            })
        },
        getStatistics() {
            ajax.getStatistics().then((result) => {
                this.setStatistics(result)
            })
        },
        handleSizeChange(val) {
            this.searchForm.itemsPerPage = val;
            this.goodSearch()
            console.log(`每页 ${val} 条`);
        },
        handleCurrentChange(val) {
            this.searchForm.pageIndex = val
            this.goodsSearch()
            console.log(`当前页: ${val}`);
        },
        clickSort(val,name) {
            this.sortValue = val;
            this.searchForm.sort = name;
            this.goodsSearch();
        },
        clickField(name) {
            this.searchForm.sort = name;
            this.goodsSearch();
        },

    }
}