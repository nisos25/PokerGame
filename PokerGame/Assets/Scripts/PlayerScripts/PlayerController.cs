using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private GameEvent noMoreChanges;
	[SerializeField] private Dealer dealer;
	[SerializeField] private int exchangeCardsSize = 3;
	[field: SerializeField] public List<CardInfo> CurrentDeck { get; set; }

	public List<CardInfo> SelectedCards { get; set; } = new List<CardInfo>();
	public int NumberOfChanges { get; private set; }
	
	private void Awake()
	{
		NumberOfChanges = exchangeCardsSize;
	}

	public void SelectCard(CardInfo selectedCard)
	{
		if (SelectedCards.Contains(selectedCard))
		{
			selectedCard.Selected = false;
			SelectedCards.Remove(selectedCard);
			return;
		}

		if (SelectedCards.Count >= NumberOfChanges && SelectedCards.Count > 0)
		{
			SelectedCards[0].Selected = false;
			SelectedCards.RemoveAt(0);
		}

		selectedCard.Selected = true;
		SelectedCards.Add(selectedCard);
	}

	public void ExchangeCards()
	{
		int temp = NumberOfChanges;

		if (temp > 0)
		{
			if (temp - SelectedCards.Count <= 0)
			{
				noMoreChanges.Raise();
			}
		}

		for (int i = 0; i < CurrentDeck.Count; i++)
		{
			if (SelectedCards.Contains(CurrentDeck[i]))
			{
				GameObject card = CurrentDeck[i].gameObject;
				
				dealer.ExchangeCards[0].transform.position = card.transform.position;
				
				Destroy(card);
				CurrentDeck[i] = dealer.ExchangeCards[0];
				
				dealer.ExchangeCards.RemoveAt(0);
			}
		}

		NumberOfChanges -= SelectedCards.Count;

		SelectedCards.Clear();
	}
}