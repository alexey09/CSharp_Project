using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_1
{
    public class ChessPlayersRus
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public int Rating { get; set; }

        public override string ToString()
        {
            return $"Name: {Name + " " + Surname}, Country: {Country}, rating in: {Rating}";
        }
        public static ChessPlayersRus ParseFideCsvLine(string line)
        {
            string[] parts = line.Split(';');
            var NamePart = parts[2].Split(',');
            var Name = NamePart[0].Trim(); //parts[3].Split(',')[0].Trim();
            var Surname = parts[2].Trim();
            var Country = parts[4];
            var Rating = int.Parse(parts[5]);
            return new ChessPlayersRus()
            {
                Name = Name,
                Surname = Surname,
                Country = Country,
                Rating = Rating

            //Name = parts[2].Split(',')[0].Trim(),
            //Surname = parts[1].Split(',')[1].Trim(),
            //Country = parts[4],
            //BirthYear = int.Parse(parts[7])

            };
        }
    }
}
