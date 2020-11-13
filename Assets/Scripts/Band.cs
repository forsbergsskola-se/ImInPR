using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Band", menuName = "Bands")]
public class Band : ScriptableObject


{
    public string name;
    public string genre;



    public bandTier Tier;
    public string bioText;

    public Sprite thumbnail;
    public string songName;

}

public enum bandTier
{
    Tier1, Tier2, Tier3
    
}