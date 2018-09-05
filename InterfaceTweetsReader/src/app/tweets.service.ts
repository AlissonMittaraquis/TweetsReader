import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TweetsService {

  tweetsURL = 'http://localhost:5000/api/tweets';

  constructor(private http: HttpClient ) { }

  listar() {
    
    return this.http.get<any[]>(`${this.tweetsURL}`);

  }
}
