using System;
using UnityEngine;

public enum Suit
{
	Club = 0,
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

public class CardInfo : MonoBehaviour, IEquatable<CardInfo>
{
	[field: SerializeField] public Value CardValue { get; set; }
	[field: SerializeField] public Suit CardSuit { get; set; }

	public override bool Equals(object other)
	{
		return Equals(other as CardInfo);
	}

	public bool Equals(CardInfo other)
	{
		return other != null && CardValue == other.CardValue && CardSuit == other.CardSuit;
	}

	public override int GetHashCode()
	{
		unchecked
		{
			int hashCode = base.GetHashCode();
			hashCode = (hashCode * 397) ^ (int) CardValue;
			hashCode = (hashCode * 397) ^ (int) CardSuit;
			return hashCode;
		}
	}
}
