using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace midtest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman Game"); //เริ่มโปรเเกรม
            Console.WriteLine("-----------------------");
            Console.WriteLine("1.Play game");  //ตัวเลือกให้เลือก1.Play gameกับ2.Exit
            Console.WriteLine("2.Exit");
            int selectMenu; //กำหนดให้ผู้เล่นเลือกselectMenu 1 หรือ 2 
            Console.Write("Please Select Menu : ");
            selectMenu = int.Parse(Console.ReadLine()); 
            if (selectMenu == 1)  //ถ้า1คือเข้าเล่นเกมHangman 
            {
                Console.WriteLine("Play Game Hangman");   //หน้าต่างเเสดงPlay Game Hangman
                Console.WriteLine("------------------------");
                Console.WriteLine("Incorrect Score: 0");  //หน้าต่างเเสดง Incorrect Score: 0 (เริ่มต้นตัวที่ผิด)
                Console.WriteLine("-----");


                Random random = new Random();

                string[] word = { "Tennis", "Football", "Badminton" };  //กำหนดศัพท์ที่ใส่ตัวอักษรไปเเล้วจะถูก

                string wordGuessWord = word[random.Next(0, word.Length)];
                string wordGuessWordUppercase = wordGuessWord.ToUpper();

                StringBuilder displayToPlayer = new StringBuilder(wordGuessWord.Length);
                for (int i = 0; i < wordGuessWord.Length; i++)
                    displayToPlayer.Append('_'); //เว้นว่างเวลายังไม่ถึงตัวอักษรที่ผู้เล่นใส่เเล้วถูก

                List<char> correctGuesses = new List<char>();
                List<char> incorrectGuesses = new List<char>();

                int score = 0;   //ตัวที่ผิดจะเริ่มจาก0เเล้วบวกเพิ่มทีละ1
                int lives = 6;  //กำหนดให้ผู้เล่นใส่ตัวอักษรได้ไม่เกิน6ครั้ง
                bool win = false;  //ค่าความจริงให้ชนะ
                int letters = 0;  //ค่าเริ่มต้นให้lettersเป็น0

                string input;
                char guess;
                 
                while (!win && lives > 0)  //ทำซ้ำถ้าตัวอักษรไม่ถูก ถ้าไม่ถูกต้องก็จะเเสดงหน้าต่างของบรรทัดที่51ขึ้นมา
                {
                    Console.Write("Input letter alphabet: ");  //หน้าต่างเเสดงหลังจากที่ถูกตัวอักษรที่ผู้เล่นใส่ลงไปเเล้วไม่ถูกเเละให้ใส่ตัวอักษรตัวใหม่

                    input = Console.ReadLine().ToUpper(); //รับค่าผู้ใช้เปลี่ยนตัวอักษรตัวเล็กที่เก็บไว้ในตัวแปร char ให้เป็นอักษรตัวใหญ่
                    guess = input[0];

                    /*ตัวที่เดากำหนดไว้ให้ผิดได้ไม่เกิน6ตัว หากเกินจะจบโปรเเกรม Game Over
                    เป็นตัวกำหนดไว้ ถ้าไม่มี เวลาใส่ตัวอักษรผิดๆไปก็จะไม่มีจำกัด
                    ก็คือโปรเเกรมจะทำงานไปเรื่อยๆ*/
                    if (wordGuessWordUppercase.Contains(guess))   
                    {
                        correctGuesses.Add(guess);

                        for (int i = 0; i < wordGuessWord.Length; i++)
                        {
                            if (wordGuessWordUppercase[i] == guess)
                            {
                                displayToPlayer[i] = wordGuessWord[i];
                                letters++;
                            }
                        }

                        if (letters == wordGuessWord.Length)  //เวลาตัวอักษรถูกต้อง
                        {
                            win = true; 
                        }
                        else { }
                    }
                    else //เวลาใส่ตัวอักษรผิดก็จะมาเข้าเงื่อนไขนี้ เเล้วบวกขึ้นทีละ1
                    {
                        Console.WriteLine("Incorrect Score: {0}", score += 1); //เวลาใส่ตัวอักษรผิดก็จะขึ้นIncorrect Scoreโดยบวกเพิ่มขึ้นทีละ1 เริ่มจาก0
                        lives--; //กำหนดไม่ให้ผิดได้เกิน6ตัว
                    }
                    Console.WriteLine(displayToPlayer.ToString()); //บรรทัดที่ให้พิมพ์ตัวอักษร
                }

                if (win) //ถ้าชนะก็เเสดงคำว่า You win!! เเละจบโปรเเกรม
                {
                    Console.WriteLine("You win!!");
                }
                else //หากไม่ตรงเงื่อนไขก็เเสดงคำว่า Game Over เเละจบโปรเเกรม
                {
                    Console.Write("Game Over");
                }
            }
            else { }  //ถ้าผู้เล่นเลือก2 คือ จบการทำงาน++++

            Console.ReadLine();
        }
    }
}
