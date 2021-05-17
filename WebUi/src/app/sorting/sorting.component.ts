import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';
import { ArrayQuickSorting, CombSortArray, dataCombSorts, dataQuickSortings, SortingModel } from './model/SortingModel';
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
  public _combSortStep?: number;
  public _quickSortingArray?: ArrayQuickSorting[];
  public _quickSortingStep?: number;
  public _quickSortingTime?: number;
  public _dataQuickSortings?: dataQuickSortings[];
  public _dataCombSorts?: any[];




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
    private router: Router) { }


  ngOnInit(): void {
    this.getRandomNumbers();
  }

  getRandomNumbers() {
    this.sharedService.GetSorting().subscribe((respData: SortingModel) =>  { 
      this._sortingModel = respData;
      this._combSortArray = respData.combSortArray?.value?.arrayCombSort;

      this._combSortStep = respData.combSortArray?.value?.combSortStep;
      this._quickSortingArray = respData.quickSortingArray?.value?.arrayQuickSorting;
      this._quickSortingStep = respData.quickSortingArray?.value?.quickSortingStep;
      this._dataQuickSortings = respData.dataQuickSortings;
      this._dataCombSorts = respData.dataSoring?.data;
      console.log(this._dataCombSorts );
      // console.log(this._quickSortingArray);
    });
  }
}