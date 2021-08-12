import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAssetData } from '../interfaces/Iassert-data';

@Injectable()
export class AssetAPIService {
  // node-sgykbw--8000.local.webcontainer.io
  constructor(private http: HttpClient) {}

  getAllData(): Observable<IAssetData[]> {
    return this.http.get<IAssetData[]>(
      'http://localhost:62677/api/asset/AllAsset',
      { responseType: 'json' }
    );
  }

  getData(assetId: string): Observable<IAssetData> {
    return this.http.get<IAssetData>(
      'http://localhost:62677/api/asset/FindAsset?id=' + assetId,
      { responseType: 'json' }
    );
  }

  saveNewData(data): Observable<any> {
    return this.http.post<any>(
      'http://localhost:62677/api/asset/SaveAsset',
      data,
      { responseType: 'json' }
    );
  }

  updateData(data): Observable<any> {
    return this.http.put<any>(
      'http://localhost:62677/api/asset/UpdateAsset',
      data,
      { responseType: 'json' }
    );
  }

  delete(assetId: string): Observable<any> {
    return this.http.delete<any>(
      'http://localhost:62677/api/asset/Delete?id=' + assetId,
      { responseType: 'json' }
    );
  }
}
