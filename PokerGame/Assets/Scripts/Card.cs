using System;
using UnityEngine;

public enum Suit
{
    Club,
    Spade,
    Diamond,
    Heart
}

public enum Value
{
    Two = 2,
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
    King,
    Ace
}

[Serializable]
public class Card
{
    public Card(Suit suit, Value value)
    {
        CardSuit = suit;
        CardValue = value;
    }
    
    [field: SerializeField] public Suit CardSuit { get; set; }
    [field: SerializeField] public Value CardValue { get; set; }
}
