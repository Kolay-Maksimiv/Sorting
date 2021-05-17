import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';
import { ArrayQuickSorting, CombSortArray, dataCombSorts, dataQuickSortings, Result, SortingModel } from './model/SortingModel';
import { Router } from '@angular/router';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BrowserModule } from '@angular/platform-browser';
@Component({
  selector: 'app-sorting',
  templateUrl: './sorting.component.html',
  styleUrls: ['./sorting.component.css']
})
export class SortingComponent implements OnInit {

  
  public _sortingModel?: SortingModel;
  public _combSortArray?: CombSortArray[];
  public _combSortArrayTime?: number;
  public _quickSortingArray?: ArrayQuickSorting[];
  public _quickSortingArrayTime?: number;
  public _quickSortingTime?: number;
  public _dataQuickSortings?: dataQuickSortings[];
  public _dataCombSorts?: dataCombSorts[];
  public _dataSoring?: Result[];



  multi?: any[];
  // options
  legend: boolean = true;
  showLabels: boolean = true;
  animations: boolean = true;
  xAxis: boolean = true;
  yAxis: boolean = true;
  showYAxisLabel: boolean = true;
  showXAxisLabel: boolean = true;
  xAxisLabel: string = 'Кількіть виконання';
  timeline: boolean = true;

  colorScheme = {
    domain: ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5']
  };



  constructor(private sharedService: SharedService, 
    private router: Router) { 
      Object.assign(this, { multi });
    }


  ngOnInit(): void {
    this.getRandomNumbers();
  }

  getRandomNumbers() {
    this.sharedService.GetSorting().subscribe((respData: SortingModel) =>  { 
      this._sortingModel = respData;
      this._combSortArray = respData.combSortArray?.value?.arrayCombSort;
      this._combSortArrayTime = respData.combSortArray?.value?.executionTime;
      this._quickSortingArray = respData.quickSortingArray?.value?.arrayQuickSorting;
      this._quickSortingArrayTime = respData.quickSortingArray?.value?.executionTime;
      this._dataQuickSortings = respData.dataQuickSortings;
      this._dataCombSorts = respData.dataCombSorts;
      this._dataSoring = respData.dataSoring?.Datas;
      console.log(  this._dataSoring);  
      // console.log(this._quickSortingArray);
    });
  }
}

export var multi = [
  {
    "name": "combSortArray",
    "series": [
      {
        "name": "1",
        "value": 0.05
      },
      {
        "name": "2",
        "value": 0.065
      },
      {
        "name": "3",
        "value": 0.54
      },
      {
        "name": "4",
        "value": 0.74
      },
      {
        "name": "5",
        "value": 0.12
      },
      {
        "name": "6",
        "value": 0.78
      },
      {
        "name": "7",
        "value": 0.12
      },
      {
        "name": "8",
        "value": 0.78
      },
      {
        "name": "9",
        "value": 0.32
      },
      {
        "name": "10",
        "value": 0.87
      },
      {
        "name": "12",
        "value": 0.3
      },
      {
        "name": "13",
        "value": 0.78
      },
      {
        "name": "14",
        "value": 0.23
      },
      {
        "name": "15",
        "value": 0.78
      },
      {
        "name": "16",
        "value": 0.121
      },
      {
        "name": "17",
        "value": 0.221
      },
      {
        "name": "18",
        "value": 0.331
      },
      {
        "name": "19",
        "value": 0.2
      }
    ]
  },

  {
    "name": "quickSorting",
    "series": [
      {
        "name": "1",
        "value": 0.21
      },
      {
        "name": "2",
        "value": 0.32
      },
      {
        "name": "3",
        "value": 0.21
      },
      {
        "name": "4",
        "value": 0.32
      },
      {
        "name": "5",
        "value": 0.21
      },
      {
        "name": "6",
        "value": 0.12
      },
      {
        "name": "7",
        "value": 0.21
      },
      {
        "name": "8",
        "value": 0.31
      },
      {
        "name": "9",
        "value": 0.32
      },
      {
        "name": "10",
        "value": 0.21
      },
      {
        "name": "12",
        "value": 0.32
      },
      {
        "name": "13",
        "value": 0.21
      },
      {
        "name": "14",
        "value": 0.32
      },
      {
        "name": "15",
        "value": 0.21
      },
      {
        "name": "16",
        "value": 0.12
      },
      {
        "name": "17",
        "value": 0.21
      },
      {
        "name": "18",
        "value": 0.31
      },
      {
        "name": "19",
        "value": 0.32
      }
    ]
  }
];
