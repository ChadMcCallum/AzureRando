using System;
using System.IO;
using System.Linq;

namespace Rando.Console
{
    public class Program
    {
        static Random random = new Random();

        //initially done as a console app so I can test it
        static void Main(string[] args)
        {
            System.Console.WriteLine(GenerateRando("."));
            System.Console.WriteLine(GenerateRando("."));
            System.Console.WriteLine(GenerateRando("."));
            System.Console.WriteLine(GenerateRando("."));
            System.Console.WriteLine(GenerateRando("."));
            System.Console.Read();
        }

        public static string GenerateRando(string rootPath)
        {
            string[] whiteCards;
            string[] blackCards;
            //these cards are taken from the Cards Against Humanity website,
            //http://www.cardsagainsthumanity.com/wcards.txt
            //http://www.cardsagainsthumanity.com/bcards1.txt
            //http://www.cardsagainsthumanity.com/bcards2.txt
            //http://www.cardsagainsthumanity.com/bcards3.txt

            //there's probably a better way of doing this rather than reading the entire text file in every time, but whatever.
            using (var reader = new StreamReader(rootPath + "/cards/white.txt"))
            {
                var cardInput = reader.ReadToEnd();
                whiteCards = cardInput.Split('>');
            }
            using (var reader = new StreamReader(rootPath + "/cards/black.txt"))
            {
                var cardInput = reader.ReadToEnd();
                blackCards = cardInput.Split('>');
            }
            //randomly select a black card to use
            var originalBlackCard = blackCards[random.Next(0, blackCards.Length)];
            var blackCard = originalBlackCard;
            //determine how many white cards we need to fill the black card
            var numOfWhiteCards = blackCard.Sum(c => c == '_' ? 1 : 0);
            //if the black card doesn't have an underscore in it, odds are we just need to select a white card to go after it.
            //select one white card and append its text to the end
            if (numOfWhiteCards == 0)
            {
                numOfWhiteCards = 1;
                blackCard += " _";
            }
            //for each white card, find an underscore in the text of hte black card and replace it with the white card's text
            for (var i = 0; i < numOfWhiteCards; i++)
            {
                var whiteCard = whiteCards[random.Next(0, whiteCards.Length)].ToLower();
                var index = blackCard.IndexOf('_');
                blackCard = blackCard.Substring(0, index) + (blackCard.Length < index ? "" : blackCard.Substring(index + 1));
                blackCard = blackCard.Insert(index, whiteCard);
            }
            return blackCard;
        }
    }
}
