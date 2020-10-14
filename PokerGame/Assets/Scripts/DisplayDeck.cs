using System;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDeck : MonoBehaviour
{
	[SerializeField] private List<Sprite> values;
	[SerializeField] private List<Sprite> suits;
	[SerializeField] private PlayerStates playerStates;

	private SetCardIcon[] cardsIcon;
	
    private void Awake()
    {
	    cardsIcon = FindObjectsOfType<SetCardIcon>();
    }

    private void Start()
    {
	    
	    for (int i = 0; i < cardsIcon.Length; i++)
	    {
		    Sprite tempSuit = suits[(int) playerStates.CurrentPlayerDeck[i].CardSuit];
		    Sprite tempValue = values[(int) playerStates.CurrentPlayerDeck[i].CardValue - 2];
			    
			    
		    cardsIcon[i].SetCardImage(tempValue,tempSuit);
	    }    
    }
}
