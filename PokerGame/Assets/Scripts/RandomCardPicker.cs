using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCardPicker : MonoBehaviour
{
    [SerializeField]private Deck deck;
    [SerializeField]private PlayerStates playerStates;
    [SerializeField]private GameEvent changeCards;

    private List<Card> playerCards = new List<Card>();
    private List<Card> exchangeCards = new List<Card>();

    private void Start()
    {
        GetExchangeCards();
        GetFiveCardsDeck();
    }

    private void GetFiveCardsDeck()
    {
        for (int i = 0; i < 5; i++)
        {
            int cardPosition = Random.Range(0, deck.Cards.Count);
            playerCards.Add(deck.Cards[cardPosition]);
            deck.Cards.RemoveAt(cardPosition);
        }

        playerStates.CurrentPlayerDeck = playerCards;
        changeCards.Raise();
    }

    private void GetExchangeCards()
    {
        for (int i = 0; i < 3; i++)
        {
            int cardPosition = Random.Range(0, deck.Cards.Count);
            exchangeCards.Add(deck.Cards[cardPosition]);
            deck.Cards.RemoveAt(cardPosition);
        }        
    }
}
