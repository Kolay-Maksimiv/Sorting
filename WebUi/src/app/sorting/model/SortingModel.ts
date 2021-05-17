export class SortingModel {
    public  combSortArray?: CombSortArray;
    public quickSortingArray?:  ArrayQuickSorting;
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
    public executionTime?: string;
}

