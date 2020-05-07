import { Component } from '@angular/core';
import { Repository } from "./repository";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SimpleBoggle';

  constructor(private repo:Repository){

  }
  getBoard(){
    //this.repo.board;
    return JSON.stringify(this.repo.board);
  }
}
