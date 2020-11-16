using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //This levels up the player when all OfficeInteractables are upgraded. 
    
    public Experience xp;
    public int xpPerLevel;
    private Image _playerSprites;
    public Sprite[] images;
    
    
    public int Level { get; private set; } 
    
    //(int)Mathf.Floor(xp.ExperienceAmount / xpPerLevel);
    private void Start()
    {
        _playerSprites = GetComponent<Image>();
    }
    public void LevelUp()
    {
        Level = (int)Mathf.Floor(xp.ExperienceAmount / xpPerLevel);
    }
}
