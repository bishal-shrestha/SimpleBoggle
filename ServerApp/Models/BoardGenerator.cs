using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ServerApp.Models
{

    public class BoardGenerator
    {
        //dice configuration taken from
        //https://boardgames.stackexchange.com/questions/29264/boggle-what-is-the-dice-configuration-for-boggle-in-various-languages
        private List<string> diceConfig = new List<string>{
            "RIFOBX", //0
            "IFEHEY", //1
            "DENOWS", //2
            "UTOKND", //3
            "HMSRAO", //4
            "LUPETS", //5
            "ACITOA", //6
            "YLGKUE", //7
            "QBMJOA", //8
            "EHISPN", //9
            "VETIGN", //10
            "BALIYT", //11
            "EZAVND", //12
            "RALESC", //13
            "UWILRG", //14
            "PACEMD" //15
        };
        public BoardGenerator()
        {

        }

        public string[] GenerateBoard()
        {
            Random random = new Random();
            List<string> newBoard = new List<string>();
            diceConfig.ForEach(
                d=>newBoard.Add(d.Substring(random.Next(5),1))
                );
            return newBoard.ToArray();
        }

        public void ValidWords()
        {

        }

    }
}