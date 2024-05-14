import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProductNoData } from '../shared/Models/ProductNoData';
import { ICategory } from '../shared/Models/Category';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) {}
  getProductNoData(categoryId?, search?, sort?) {
    return this.http.get<IProductNoData[]>(
      this.baseUrl +
        `/Products/getAllProductWithNoData?categoryId=${categoryId}&search=${search}&sort=${sort}`
    );
  }

  getCategory() {
    return this.http.get<ICategory[]>(
      this.baseUrl + '/Categories/getAllCategoryWithNoData'
    );
  }
  getProductById(id) {
    return this.http.get<IProductNoData>(
      this.baseUrl + `/Products/getProductByIdWithNoData/:id?id=${id}`
    );
  }
}
