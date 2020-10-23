using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Random = UnityEngine.Random;

namespace Tests
{
    public class pokerHand_evaluator
    {
	    [Test]
	    public void with_royal_flush_get_100_points()
	    {
		    List<CardInfo> cardInfos = new List<CardInfo>();
	        
		    for (int i = 0; i < 5; i++)
		    {
			    GameObject card = new GameObject("Card" + i);
			    CardInfo cardInfo = card.AddComponent<CardInfo>();
			    cardInfo.CardValue = Value.Ten + i;
			    cardInfo.CardSuit = Suit.Diamond;
				
			    cardInfos.Add(cardInfo);
		        
		    }
	        
		    PokerHands pokerHand = new PokerHands();
		    int result = (int)pokerHand.EvaluatePokerHand(cardInfos);
		    

		    Assert.AreEqual(100, result);
	    }
	    
	    [Test]
	    public void with_full_house_get_15_points()
	    {
		    List<CardInfo> cardInfos = new List<CardInfo>();
	        
		    for (int i = 0; i < 5; i++)
		    {
			    GameObject card = new GameObject("Card" + i);
			    CardInfo cardInfo = card.AddComponent<CardInfo>();
			    
			    if (i < 3)
			    {
				    cardInfo.CardValue = Value.Ace;
				    cardInfo.CardSuit = Suit.Diamond;
			    }
			    else
			    {
				    cardInfo.CardValue = Value.King;
				    cardInfo.CardSuit = Suit.Spade;    
			    }
				
			    cardInfos.Add(cardInfo);
		    }

		    PokerHands pokerHand = new PokerHands();
		    int result = (int)pokerHand.EvaluatePokerHand(cardInfos);
		    

		    Assert.AreEqual(15, result);
	    }
	    
	    [Test]
	    public void with_one_pair_get_1_points()
	    {
		    List<CardInfo> cardInfos = new List<CardInfo>();
		    
		    for (int i = 0; i < 5; i++)
		    {
			    GameObject card = new GameObject("Card" + i);
			    CardInfo cardInfo = card.AddComponent<CardInfo>();
			    
			    if (i < 2)
			    {
				    
				    cardInfo.CardValue = Value.Eight;
				    cardInfo.CardSuit = Suit.Club + i;
			    }
			    else
			    {
				    cardInfo.CardValue = Value.Two + i;
				    cardInfo.CardSuit = Suit.Club;
			    }
				
			    cardInfos.Add(cardInfo);
		    }

		    PokerHands pokerHand = new PokerHands();
		    int result = (int)pokerHand.EvaluatePokerHand(cardInfos);
		    

		    Assert.AreEqual(1, result);
	    }
	    
	    [Test]
	    public void with_two_pairs_get_3_points()
	    {
		    List<CardInfo> cardInfos = new List<CardInfo>();
	        
		    for (int i = 0; i < 5; i++)
		    {
			    GameObject card = new GameObject("Card" + i);
			    CardInfo cardInfo = card.AddComponent<CardInfo>();
			    
			    if (i < 2)
			    {
				    cardInfo.CardValue = Value.Eight;
				    cardInfo.CardSuit = Suit.Club + i;
			    }
			    else if(i < 4)
			    {
				    cardInfo.CardValue = Value.Two;
				    cardInfo.CardSuit = Suit.Heart;
			    }
			    else
			    {
				    cardInfo.CardValue = Value.Ace;
				    cardInfo.CardSuit = Suit.Spade;
			    }
				
			    cardInfos.Add(cardInfo);
		    }

		    PokerHands pokerHand = new PokerHands();
		    int result = (int)pokerHand.EvaluatePokerHand(cardInfos);
		    

		    Assert.AreEqual(3, result);
	    }
	    
	    [Test]
	    public void with_three_of_a_kind_get_5_points()
	    {
		    List<CardInfo> cardInfos = new List<CardInfo>();
	        
		    for (int i = 0; i < 5; i++)
		    {
			    GameObject card = new GameObject("Card" + i);
			    CardInfo cardInfo = card.AddComponent<CardInfo>();
			    
			    if (i < 3)
			    {
				    cardInfo.CardValue = Value.Jack;
				    cardInfo.CardSuit = Suit.Club + i;
			    }
			    else
			    {
				    cardInfo.CardValue = Value.Two + i;
				    cardInfo.CardSuit = Suit.Spade;
			    }
				
			    cardInfos.Add(cardInfo);
		    }

		    PokerHands pokerHand = new PokerHands();
		    int result = (int)pokerHand.EvaluatePokerHand(cardInfos);
		    

		    Assert.AreEqual(5, result);
	    }
	    
	    [Test]
	    public void with_straight_get_10_points()
	    {
		    List<CardInfo> cardInfos = new List<CardInfo>();
	        
		    for (int i = 0; i < 5; i++)
		    {
			    int sum = i > 3 ? 0 : i; 
			    
			    GameObject card = new GameObject("Card" + i);
			    CardInfo cardInfo = card.AddComponent<CardInfo>();
			    cardInfo.CardValue = Value.Two + i;
			    cardInfo.CardSuit = Suit.Club + sum;
			   
			    cardInfos.Add(cardInfo);
		    }

		    PokerHands pokerHand = new PokerHands();
		    int result = (int)pokerHand.EvaluatePokerHand(cardInfos);
		    

		    Assert.AreEqual(10, result);
	    }
	    
	    [Test]
	    public void with_poker_get_20_points()
	    {
		    List<CardInfo> cardInfos = new List<CardInfo>();
	        
		    for (int i = 0; i < 5; i++)
		    {
			    GameObject card = new GameObject("Card" + i);
			    CardInfo cardInfo = card.AddComponent<CardInfo>();
			    
			    if (i < 4)
			    {
				    cardInfo.CardValue = Value.Four;
				    cardInfo.CardSuit = Suit.Club + i;
			    }
			    else
			    {
				    cardInfo.CardValue = Value.Seven;
				    cardInfo.CardSuit = Suit.Spade;
			    }
			   
			    cardInfos.Add(cardInfo);
		    }

		    PokerHands pokerHand = new PokerHands();
		    int result = (int)pokerHand.EvaluatePokerHand(cardInfos);
		    

		    Assert.AreEqual(20, result);
	    }
    }
}
