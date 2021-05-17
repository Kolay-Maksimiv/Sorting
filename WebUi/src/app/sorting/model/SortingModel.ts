import { Data } from "@angular/router";

export class SortingModel {
    public combSortArray?: CombSortArray;
    public quickSortingArray?:  ArrayQuickSorting;
    public dataQuickSortings?: dataQuickSortings[];
    public dataCombSorts?: dataCombSorts[];
    public dataSoring?: LineChartResponce<LineChartViewMode>;

}

export class LineChartResponce<T> {
    public data?: T[];
    public total?: number;
}

export class LineChartViewMode {
    public name?: string;
    public nameValueViewMode?: NameValueViewMode;
}

export class NameValueViewMode {
    public value?: number;
    public name?: number;
}




export class dataQuickSortings {
    public quickSortingID?: number;
    public quickSortingTime?: number;
}
export class dataCombSorts {
    public combSortID?: number;
    public combSortTime?: number;
}
export class CombSortArray {
    public value?: Value;
}

export class ArrayQuickSorting {
    public value?: Value;
}
export class Value {
    public arrayCombSort?: any[];
    public arrayQuickSorting?: any[];
    public combSortStep?: number;
    public quickSortingStep?: number;
    
}



