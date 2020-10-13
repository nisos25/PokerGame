using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerStates playerStates;
    
    private List<Card> currentDeck;
    
    
    public void SetPlayerDeck()
    {
        currentDeck = playerStates.CurrentPlayerDeck;
    }
    
}
