using System;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [field: SerializeField] public List<Card> Cards { get; set; } = new List<Card>();

    private List<Card> originalDeck;
    
    private void Awake()
    {
        originalDeck = BuildDeck();
        Cards = originalDeck;
    }

    private List<Card> BuildDeck()
    {
        List<Card> tempDeck = new List<Card>();
        int index = 0;

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Value value in Enum.GetValues(typeof(Value)))
            {
                tempDeck.Add(new Card(suit, value));
            }
        }

        return tempDeck;
    }
}
