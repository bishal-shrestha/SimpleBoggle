import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Board } from './board.model';

const boardUrl = "/api/board";

@Injectable()
export class Repository {

  board:Board;
  constructor(private http:HttpClient){
    this.getBoard();
  }

  getBoard(){
    this.http.get<Board>(`${boardUrl}`).subscribe(b => this.board=b);
  }
}
