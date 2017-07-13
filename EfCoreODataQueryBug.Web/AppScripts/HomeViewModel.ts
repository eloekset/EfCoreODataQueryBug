module EfCoreODataQueryBug {
    export class HomeViewModel {
        public customerGridOptions: DevExpress.ui.dxDataGridOptions;

        constructor(public options: HomeViewModelOptions) {
            function combineUrl(url1, url2) {
                if (url1 !== undefined && url2 !== undefined && url1.length > 0 && url2.length > 0) {
                    if (url1.charAt(url1.length - 1) === "/" && url2.charAt(0) === "/") {
                        return url1.substr(0, url1.length - 1) + url2;
                    }
                    else if (url1.charAt(url1.length - 1) === "/") {
                        return url1 + url2;
                    }
                    else {
                        return url1 + "/" + url2;
                    }
                }
                else if (url1 !== undefined && url1.length > 0) {
                    return url1;
                }
                return url2;
            }
            this.customerGridOptions = {
                dataSource: new DevExpress.data.DataSource({
                    store: new DevExpress.data.ODataStore({
                        url: combineUrl(this.options.baseUri, 'odata/Customers'),
                        key: 'customerId',
                        version: 4
                    }),
                    paginate: true,
                    pageSize: 5
                }),
                filterRow: {
                    visible: true
                },
                columns: [
                    { dataField: 'customerId', dataType: 'numeric', width: 120 },
                    { dataField: 'name', sortIndex: 0, sortOrder: 'asc' },
                    { dataField: 'customerSince', dataType: 'date', format: 'shortDate', width: 150 },
                    { dataField: 'isActive', dataType: 'boolean', width: 80 }
                ]
            }
        }
        
    }
}