using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStates : ScriptableObject
{
    [field: SerializeField] public List<Card> CurrentPlayerDeck { get; set; } = new List<Card>();
    
}
