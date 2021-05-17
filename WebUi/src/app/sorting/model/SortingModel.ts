import { Data } from "@angular/router";

export class SortingModel {
    public combSortArray?: CombSortArray;
    public quickSortingArray?:  ArrayQuickSorting;
    public dataQuickSortings?: dataQuickSortings[];
    public dataCombSorts?: dataCombSorts[];
    public dataSoring?: Result;

}

export class Result {
    public Datas?: Datas[];
    public Total?: number;
}
export class Datas {

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
    public executionTime?: number;
}



