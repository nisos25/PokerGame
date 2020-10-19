using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private int exchangeCardsSize = 3;
	[SerializeField] private List<CardInfo> currentDeck;

	public List<CardInfo> SelectedCards { get; set; } = new List<CardInfo>();
	private int numberOfChanges;
	
	
	private void Start()
	{
		numberOfChanges = exchangeCardsSize;
	}


	public void SelectCard(CardInfo selectedCard)
	{
		if (SelectedCards.Contains(selectedCard))
		{
			SelectedCards.Remove(selectedCard);
			return;
		}
		
		if (SelectedCards.Count >= exchangeCardsSize)
		{
			SelectedCards.RemoveAt(0);
		}

		SelectedCards.Add(selectedCard);
	}

	public void ExchangeCards()
	{
		
	}
	
}
