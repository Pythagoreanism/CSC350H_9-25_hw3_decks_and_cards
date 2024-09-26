using System;

namespace _9_25_hw3_decks_and_cards {
    /// <summary>
    /// Enumeration of ranks from Ace (1) to King (13)
    /// </summary>
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


    /// <summary>
    /// Enumeration of suits: Clubs (0), Diamonds (1), Hearts (2), and Spades (3)
    /// </summary>
    public enum Suit {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    /// <summary>
    /// Card class, can only be assigned through an instance of the Deck class
    /// </summary>
    public class Card {
        private Rank rank;
        private Suit suit;

        // Properties
        public Rank Rank { get { return rank; } }
        public Suit Suit { get { return suit; } }

        // Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="r">The rank of the card</param>
        /// <param name="s">The suit of the card</param>
        public Card(Rank r, Suit s) { rank = r; suit = s; }

        // Overrides
        public override string ToString() {
            return $"{rank} of {suit}";
        }

    };
    

    public class Deck {
        private List<Card> cards;

        // Methods

        /// <summary>
        /// Takes a card from the top deck
        /// </summary>
        /// <returns>The last card of the deck</returns>
        public Card takeFromTopDeck() {
            if (cards.Count == 0) { // If deck is empty
                return null;
            }
            
            cards.Remove(cards[cards.Count - 1]);
            return cards[cards.Count - 1];
        }
        /// <summary>
        /// Prints the cards in the deck
        /// </summary>
        public void printDeck() {
            for (int i = 0; i < cards.Count; i++) {
                Console.WriteLine($"{cards[i].Rank} of {cards[i].Suit}");
            }
        }
        /// <summary>
        /// Shuffles the cards in the deck
        /// </summary>
        public void shuffle() {

            if (cards.Count == 0) {
                Console.WriteLine("Deck is empty!");
            }
            else {
                Random rand = new Random();
                int i = 0, j = 0;
                Card temp;

                while (i < cards.Count - 1) {
                    j = rand.Next(i, cards.Count);
                    temp = cards[i];
                    cards[i] = cards[j];
                    cards[j] = temp;

                    i++;
                }
            }
        }
        /// <summary>
        /// Cuts a certain amount of cards on the deck and places them at the bottom of the deck
        /// </summary>
        /// <param name="cutFrom">The number of cards to be cut from the top of the deck</param>
        public void cut(int cutFrom) {
            if (cutFrom > cards.Count || cutFrom < 1) {
                Console.WriteLine("Error: Invalid index! " + 
                                  $"Try between 1 - {cards.Count - 1}");
            }
            else {
                List<Card> miniDeck = new List<Card>();

                for (int i = cards.Count - cutFrom; i < cards.Count; i++) {
                    miniDeck.Add(cards[i]);
                }

                cards.RemoveRange(cards.Count - cutFrom, cutFrom);
                miniDeck.AddRange(cards);
                cards = miniDeck; // Assign new values to original member
            }
        }

        // Constructor

        /// <summary>
        /// Default constructor: Initializes a deck with 52 cards
        /// </summary>
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
            
            deck.shuffle();

            Console.WriteLine("\nAfter shuffle:\n");

            deck.printDeck();

            deck.cut(2);

            Console.WriteLine("\nAfter cut 2 cards from top\n");

            deck.printDeck();
        }
    }
}