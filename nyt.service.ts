import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class NytService {
  private baseUrl = 'https://localhost:7084/api/article';

  constructor(private http: HttpClient) {}

  loadData(apiKey: string) {
    return this.http.post(`${this.baseUrl}/load`, { apiKey: apiKey }, {
      headers: { 'Content-Type': 'application/json' },
    });
  }

}