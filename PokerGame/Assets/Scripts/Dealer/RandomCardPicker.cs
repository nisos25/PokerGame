using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCardPicker : MonoBehaviour
{
	[SerializeField] private GameObject card;
	[SerializeField] private Transform exchangeCardsParent;
	[SerializeField] private Transform[] cardsPositions;

	private Dealer dealer;
	private List<CardInfo> generatedCardsList = new List<CardInfo>();
	
	private void Awake()
	{
		dealer = GetComponent<Dealer>();
		
		GetDeck(5, cardsPositions);
		GetDeck(3, exchangeCardsParent);

		dealer.PlayerCards = generatedCardsList.Take(5).ToList();
		dealer.ExchangeCards = generatedCardsList.Skip(5).Take(3).ToList();
	}
	
	private void GetDeck(int size, params Transform[] parent)
	{
		int index = 0;
		
		while (index < size)
		{
			CardInfo cardInfo;
			
			if (parent.Length >= size)
			{
				cardInfo = GenerateCard(parent[index]);
			}
			else
			{ 
				cardInfo = GenerateCard(parent[0]);
			}
			
			
			if (generatedCardsList.Contains(cardInfo))
			{
				Destroy(cardInfo.gameObject);
				continue;
			}
			
			generatedCardsList.Add(cardInfo);
			index++;
		}
	}

	private CardInfo GenerateCard(Transform position)
	{
		int suit = Random.Range(0, Suit.GetNames(typeof(Suit)).Length);
		int value = Random.Range(2, Value.GetNames(typeof(Value)).Length + 2);

		CardInfo newCard = Instantiate(card, Vector3.zero, Quaternion.identity).GetComponent<CardInfo>();

		newCard.transform.SetParent(position, false);
		
		
		newCard.CardValue = (Value) value;
		newCard.CardSuit = (Suit) suit;
		
		return newCard;
	}
}