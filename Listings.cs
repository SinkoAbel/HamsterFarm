using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorcsogFarm
{

    class Listings
    {
        /// <summary>
        /// A program lényegi leírása.
        /// </summary>
        public static void StartingMessage()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Hörcsög nyilvántartó: => Üss egy ENTER-t");
            Console.ResetColor();
            Console.WriteLine();
        }


        // Kreatívkodás: 2 féleképpen lehet használni!
        /// <summary>
        /// Listázza az adott hónapot.
        /// </summary>
        /// <param name="monthIndex"></param>
        public static void ListingYearMonth(byte monthIndex)
        {
            Console.WriteLine("Jelenlegi hónap: {0}", (Months)monthIndex);
            Console.WriteLine();
        }
        /// <summary>
        /// Listázza az adott évet és hónapot.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="monthIndex"></param>
        public static void ListingYearMonth(short year, byte monthIndex)
        {
            Console.WriteLine("Jelenlegi dátum: {0} {1}", year, (Months)monthIndex);
            Console.WriteLine();
        }


        /// <summary>
        /// Bekéri az új hörcsögök számát.
        /// </summary>
        public static void AskingNumbers()
        {
            Console.Write("Hány darab új hörcsög érkezett a hónapban: ");
        }

        /// <summary>
        /// Üzenet ha nincs új hörcsög.
        /// </summary>
        public static void NoneMessage()
        {
            Console.WriteLine("\nNem érkezett hörcsög a farmra.\n");
        }


        /// <summary>
        /// Instrukciók minden hónap végére
        /// </summary>
        public static void EndMonthInstructions()
        {
            StringBuilder instruction = new StringBuilder();

            instruction.Append("\n")
                       .Append("----------------------------------------\n")
                       .Append("A következő hónapra való ugráshoz nyomjon meg egy tetszőleges gombot.\n")
                       .Append("Kilépéshez az Escape billentyűt nyomja meg.\n")
                       .Append("----------------------------------------");

            Console.WriteLine(instruction);

        }

        /// <summary>
        /// Búcsúzó üzenet
        /// </summary>
        public static void ExitMessage()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Köszönjük, hogy a programot használta!\nViszont látásra!");
            Console.ResetColor();
        }


        private static byte HighestWeightIndex(List<float> weightHamster)
        {
            byte fattesHamsterIndex = 0;
            float max = weightHamster[0];

            for (byte i = 0; i < weightHamster.Count; i++)
            {
                if (weightHamster[i] > max)
                {
                    max = weightHamster[i];
                    fattesHamsterIndex = i;
                }
            }

            return fattesHamsterIndex;
        }

        /// <summary>
        /// Listázza a legnagyobb súlyú tengeri malacot. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        public static void DisplayMostObese(List<string> name, List<float> weight)
        {
            Console.WriteLine();
            Console.WriteLine("A legkövérebb hörcsög: {0} - {1}kg", name[HighestWeightIndex(weight)], weight[HighestWeightIndex(weight)].ToString("0.00"));
            Console.WriteLine();
        }

    }
}
