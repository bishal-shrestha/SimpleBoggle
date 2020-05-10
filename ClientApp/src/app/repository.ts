import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Board } from './board.model';
import { UserWord } from './userWord.model';

const boardUrl = "/api/board";
const submittedWordUrl = "/api/word";
const solverUrl = "/api/solver";

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

  wordVerified:boolean=true;
  isBoardSolved:boolean = false;
  verifiedWordsMap:Map<string,number>= new Map();
  solvedWordsMap:Map<string,number> = new Map();

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

  solveBoard(boardArray:string[]){
    let board = new Board();
    board = {generatedBoard:boardArray};

    this.http.post<string[]>(`${solverUrl}`,board).subscribe(wordList => {
      this.isBoardSolved = true;
      for(let i=0;i<wordList.length;i++)
      {
        let word= wordList[i];
      if(!this.solvedWordsMap.has(word))
      this.solvedWordsMap.set(word,word.length);
      }
    }
    );
    console.log(`Sent POST request at:${solverUrl}`);
  }
}
