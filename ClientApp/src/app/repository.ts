import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Board } from './board.model';
import { UserWord } from './userWord.model';

const boardUrl = "/api/board";
const submittedWordUrl = "/api/word"

@Injectable()
export class Repository {

  boardSize:number = 4;
  boardArray:string[] = [];

  //array of array representing dices in board
  cellArrary = [
                  [],
                  [],
                  [],
                  []
               ];

  wordVerified:boolean=undefined;
  verifiedWordsMap:Map<string,number>= new Map();

  constructor(private http:HttpClient){
    this.getBoard();
  }

  getBoard(){
    this.http.get<Board>(`${boardUrl}`).subscribe(board => {
      if(board!=null)
      {
        this.boardArray = board.generatedBoard;

        for (let index = 0; index < this.boardArray.length; index++) {
            let cellValue = this.boardArray[index];
            let row = Math.floor( index/this.boardSize);
            let col = index % this.boardSize;

            this.cellArrary[row][col] = cellValue;
        }
      }
      console.table(this.cellArrary);
    });
    console.log(`Sent GET request at:${boardUrl}`);
  }

  checkWord(boardArray:string[], submittedWord:string){
    let wordData = new UserWord();
    wordData = {generatedBoard:boardArray, wordValue:submittedWord};

    this.wordVerified=undefined;
    this.http.post<boolean>(submittedWordUrl,wordData).subscribe(
      result => {
        this.wordVerified=result;

        if(result && !this.verifiedWordsMap.has(submittedWord))
          this.verifiedWordsMap.set(submittedWord,submittedWord.length);

        console.log(`Word:${submittedWord} Result:${this.wordVerified}`);
      }
    );
    console.log(`Sent POST request at:${submittedWordUrl}`);
  }
}
