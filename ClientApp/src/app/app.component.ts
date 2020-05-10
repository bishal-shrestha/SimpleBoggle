import { Component } from '@angular/core';
import { Repository } from "./repository";
import { Board } from './board.model';
import { NgForm } from '@angular/forms';
import { timer } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  //verified:boolean=false;

  submittedWord:string;
  formSubmitted:boolean=false;

  timerSource = timer(0, 1000);
  duration:number = 60 * 3;   //3 min
  timeLeft:number = 0;
  timeRunOut:boolean =false;

  //totalScore:number=0;
  editing:boolean=true;


  constructor(public repo:Repository){
    let subscribe = this.timerSource.subscribe(val => {
      //console.log(val);
      this.timeLeft = this.duration - val;
      if(this.timeLeft <=0)
      {
        subscribe.unsubscribe();
        this.timeRunOut=true;
      }
    });
  }

  isLastWordVerified(){
    return this.repo.wordVerified;
  }

  getVerifiedWords(){
    return Array.from(this.repo.verifiedWordsMap);
  }

  getCellArray(i:number){
    return this.repo.cellArrary[i];
  }

  getCellElementValue(x:number,y:number){
    return this.repo.cellArrary[x][y];
  }

  getTotalScore():number{
    let totalScore = 0;
    for(let [key,value] of this.repo.verifiedWordsMap)
    {
      totalScore+=value;
    }
    return totalScore;
  }

  setEditing(){
    this.editing = true;
  }

  submitForm(form: NgForm) {
    this.formSubmitted = true;
    this.editing = false;
    if (form.valid) {
        console.log(`submitting:${this.submittedWord}`);
        this.repo.checkWord(this.repo.boardArray,this.submittedWord);

        form.reset();
        this.formSubmitted = false;
    }
  }
}
