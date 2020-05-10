# SimpleBoggle
Boggle UI and Boggle solver implemented as Web API

Client Side
 - angular/cli v8.1.2
 - nodejs v12.16.3
 
Server Side
- dotnet core v3.1.201

## Steps for setup:
- Install Node.Js from https://nodejs.org/en/download/
- Install angular/cli `npm install --global @angular/cli@8.1.2`
- Install dotnet core from https://www.microsoft.com/net/download/core

## Steps to run projects:
- For server side run `dotnet watch run` on SimpleBoggle\ServerApp project
- For testing server side project run `dotnet test` on SimpleBoggle\ServerApp.Tests project
- For client side run `npm start` on SimpleBoggle\ClientApp project

## Features:
- Board of size 4 by 4 is generated randomly 
- User input validation. only alphabetical word with length more than 2 is allowed
- User submitted word is validated on server side using POST request. validation is done to check if the word is feasible on current board
- valid words along with scroes are displayed on table
- Boggle board can be solved automatically after time runs out. All possible words are displayed on table

## Notes:
Swagger UI to describe/test the web API functionality:

https://localhost:5001/swagger/index.html

dotnet project hosted on:

https://localhost:5001/

angular project hosted on:

http://127.0.0.1:4200

Dice configuration for Boggle taken from:

https://boardgames.stackexchange.com/questions/29264/boggle-what-is-the-dice-configuration-for-boggle-in-various-languages

English word list taken from:

http://wordlist.aspell.net/12dicts-readme/#2of12inf

