using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Band", menuName = "Band/Bands")]
public class Band : ScriptableObject
{
    public string name;
    public string genre;
    public BandTier Tier;
    public string bioText;
    public Sprite thumbnail;
    
    public GameSong song;

    public bool isOwned;
}

public enum BandTier
{
    Tier1, 
    Tier2, 
    Tier3
}