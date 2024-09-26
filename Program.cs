using System;

namespace _9_25_hw3_decks_and_cards {
    public enum Rank {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }


    public enum Suit {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }


    public class Card {
        private Rank rank;
        private Suit suit;

        // Properties
        public Rank Rank { get { return rank; } }
        public Suit Suit { get { return suit; } }

        // Constructor
        public Card(Rank r, Suit s) { rank = r; suit = s; }

        // Overrides
        public override string ToString() {
            return $"{rank} of {suit}";
        }

    };
    

    public class Deck {
        private List<Card> cards;

        // Methods
        public Card takeFromTopDeck() {
            if (cards.Count == 0) { // If deck is empty
                return null;
            }
            
            cards.Remove(cards[cards.Count - 1]);
            return cards[cards.Count - 1];
        }
        public void printDeck() {
            for (int i = 0; i < cards.Count; i++) {
                Console.WriteLine($"{cards[i].Rank} of {cards[i].Suit}");
            }
        }

        // Constructor
        public Deck() {
            cards = new List<Card>();
            Card temp;

            for (int i = 0; i < 4; i++) { // 4 suits
                for (int j = 1; j <= 13; j++) { // 14 ranks
                    temp = new Card((Rank)j, (Suit)i);
                    cards.Add(temp);
                }
            }
        }

    };


    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            Deck deck = new Deck();

            deck.printDeck();
            
            Card card = deck.takeFromTopDeck();

            Console.WriteLine("\nAfter take from top deck:\n");
            deck.printDeck();
            
            //Console.WriteLine(card);
        }
    }
}