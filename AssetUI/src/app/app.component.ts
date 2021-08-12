import { Component, OnInit } from '@angular/core';
import { IAssetData } from './interfaces/Iassert-data';
import { AssetAPIService } from './services/asset-api.service';

const MOCK_DATA: IAssetData[] = [
  {
    AssetId: '123',
    file_name: 'test',
    mime_type: 'csv',
    created_by: 'user',
    email: 'example@email.com',
    country: 'I',
    description: ''
  }
];

@Component({
  selector: 'my-app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  dataSource: IAssetData[] = [];

  showForm: boolean = false;

  isUpdate: boolean = false;

  updatingData: IAssetData;

  constructor(private apiService: AssetAPIService) {
    this.dataSource = MOCK_DATA;
  }

  ngOnInit() {
    this.getAllData();
  }

  getAllData() {
    this.apiService.getAllData().subscribe(res => {
      this.dataSource = res;
    });
  }

  handleCloseForm(event) {
    this.showForm = event;
    this.isUpdate = event;
    this.getAllData();
  }

  update(data: IAssetData) {
    this.isUpdate = true;
    this.showForm = true;
    this.updatingData = data;
  }

  delete(assetId) {
    if (
      confirm('Are you sure you want to delete this thing from the database?')
    ) {
      this.apiService.delete(assetId).subscribe(res => {
        this.getAllData();
      });
      console.log('Deleted');
    } else {
      console.log('Cancelled');
    }
  }
}
