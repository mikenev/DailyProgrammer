using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _216e
{
    public class Card
    {
        public int suit { get; set; }
        public int value { get; set; }

        public string Name() {
            return value.ToString() + '.' + suit.ToString();
        }
    }

    public class Deck
    {
        List<Card> deck;
        Random random;

        public Deck()
        {
            random = new Random();
            deck = new List<Card>();

            for(int i = 0; i < 4; i++) {
                for (int j = 1; j < 13; j++)
                {
                    Card c = new Card(){ suit = i, value = j };
                    deck.Add(c);
                }
            }

            this.Shuffle();
        }

        public void Shuffle()
        {
            List<Card> newDeck = new List<Card>();

            while(deck.Count > 0)
            {
                int next = random.Next(0, deck.Count);
                newDeck.Add(deck[next]);
                deck.RemoveAt(next);
            }

            deck = newDeck;
        }

        public Card NextCard()
        {
            Card c = deck[0];
            deck.RemoveAt(0);
            return c;
        }
    }

    public class Player
    {
        public string name { get; set; }
        public List<Card> hand { get; set; }

        public Player(string name)
        {
            this.name = name;
            this.hand = new List<Card>();
        }

        public void ShowHand()
        {
            string myCards = string.Join(",", 
                (from h in hand
                    select h.Name()));

            Console.WriteLine(this.name + ":" + myCards);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            Console.Write("How many players (2-8) ? ");
            int numPlayers = int.Parse(Console.ReadLine());

            List<Player> players = new List<Player>();
            players.Add(new Player("Your Hand"));

            for (int i = 1; i < numPlayers; i++)
            {
                players.Add(new Player("CPU " + i.ToString() + " Hand"));
            }

            for (int i = 0; i < numPlayers; i++)
            {
                players[i].hand.Add(deck.NextCard());
                players[i].hand.Add(deck.NextCard());
                players[i].ShowHand();
            }

            Console.WriteLine();

            // Flop
            deck.NextCard();
            Player flop = new Player("Flop");
            flop.hand.Add(deck.NextCard());
            flop.hand.Add(deck.NextCard());
            flop.hand.Add(deck.NextCard());
            flop.ShowHand();

            deck.NextCard();
            Player turn = new Player("Turn");
            turn.hand.Add(deck.NextCard());
            turn.ShowHand();

            deck.NextCard();
            Player river = new Player("River");
            river.hand.Add(deck.NextCard());
            river.ShowHand();

            Console.ReadLine();
        }
    }
}
