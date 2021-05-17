import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';
import { ArrayQuickSorting, CombSortArray, SortingModel } from './model/SortingModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sorting',
  templateUrl: './sorting.component.html',
  styleUrls: ['./sorting.component.css']
})
export class SortingComponent implements OnInit {

  constructor(private sharedService: SharedService, 
    private router: Router) { }
  
  public _sortingModel?: SortingModel;
  public _combSortArray?: CombSortArray[];
  public _combSortArrayTime?: string;
  public _quickSortingArray?: ArrayQuickSorting[];
  public _quickSortingArrayTime?: string;
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
      // console.log(this._combSortArray);
      // console.log(this._quickSortingArray);
      // console.log(respData);
    });
  }
}
