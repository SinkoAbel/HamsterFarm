using System;
using System.Collections.Generic;
using System.Linq;

namespace HorcsogFarm
{
    class Program
    {
        static void Main(string[] args)
        {


            // ######################### HELYENKÉNT KÍSÉRLETEZŐ JELLEGŰ A PROGRAMOM :) ######################### 

            ConsoleKey c;

            List<string> namesHamster = new List<string>();
            List<float> weightHamster = new List<float>();
            byte monthIndex = 0;
            short year = 2021;
            byte arrivedHamsters = 0;
            const float monthlyWeightGain = 1.02f;
            Random rand = new Random();

            
            do
            {

                Console.Clear();

                Listings.StartingMessage();

                // 1. feladat
                if (monthIndex > 11)
                {
                    year++;
                    monthIndex = 0;
                }
                Listings.ListingYearMonth(year, monthIndex);
                monthIndex++;


                // 2.feladat:
                do
                    Listings.AskingNumbers();
                while (!byte.TryParse(Console.ReadLine(), out arrivedHamsters));

                if(arrivedHamsters > 0)
                    NewHamsterDetails(namesHamster, weightHamster, arrivedHamsters);
                else
                    Listings.NoneMessage();



                if (namesHamster.Count > 0)
                {
                    // 3.feladat
                    // Minden hörcsög súlya 2%-al növekszik (+1 szerencsés hörcsög akinek 4%-al)
                    byte randomHamsterIndex = (byte)rand.Next(0, namesHamster.Count);
                    MonthlyWeightIncrease(namesHamster, weightHamster, randomHamsterIndex);

                    // 4.feladat
                    Listings.DisplayMostObese(namesHamster, weightHamster);

                    // 5.feladat
                    HamsterLottery(namesHamster, randomHamsterIndex);
                }

                Listings.EndMonthInstructions();

                c = Console.ReadKey(true).Key;


            } while (c != ConsoleKey.Escape);

            Listings.ExitMessage();

            ////////////// PROGRAM VÉGE //////////////




            ////////////////////////////  Procedurális  ////////////////////////////
            ///(Lehetett volna class-ba rendezni...)

            static float ujTestsuly(float testsuly, float szazalek)
            {
                return testsuly * szazalek;      
            }

            static void HamsterLottery(List<string> name, byte HamsterIndex)
            {
                Console.WriteLine("#### Hörcsöglottó ####");
                Console.WriteLine("Az e-havi nyertes: {0}! Gratulálunk, jó étvágyat!", name[HamsterIndex]);
            }

            
            static void NewHamsterDetails(List<string> namesHamster, List<float> weightHamster, byte arrivedHamsters)
            { 
                byte tempHamsterWeight;
                for (byte i = 0; i < arrivedHamsters; i++)
                {
                    Console.Write("Adja meg a hörcsög nevét: ");
                    namesHamster.Add(Console.ReadLine());

                    do
                        Console.Write("Adja meg a hörcsög jelenlegi súlyát: ");
                    while (!byte.TryParse(Console.ReadLine(), out tempHamsterWeight));

                    weightHamster.Add(tempHamsterWeight);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }


            static void MonthlyWeightIncrease(List<string> namesHamster, List<float> weightHamster, byte randomHamsterIndex)
            {
                for (byte i = 0; i < namesHamster.Count; i++)
                {

                    weightHamster[i] = ujTestsuly(weightHamster[i], monthlyWeightGain);

                    //hörcsöglottóhoz
                    if (i == randomHamsterIndex)
                    {
                        weightHamster[i] = weightHamster[i] * monthlyWeightGain;
                    }
                    //

                    Console.WriteLine("Hörcsög nev: {0}, új súlya a hónapban: {1}kg", namesHamster[i], weightHamster[i].ToString("0.00"));
                }
            }


        }
    }
}
