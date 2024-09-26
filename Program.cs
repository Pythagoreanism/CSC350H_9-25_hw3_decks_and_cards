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
        
    };


    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }
    }
}