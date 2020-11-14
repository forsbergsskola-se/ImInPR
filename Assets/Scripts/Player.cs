using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Experience xp;
    public int xpPerLevel;
    private Image playerSprite;
    public Sprite[] images;
    
    public int Level => (int)Mathf.Floor(xp.ExperienceAmount / xpPerLevel);

    private void Start()
    {
        playerSprite = GetComponent<Image>();
        
    }

    private void FixedUpdate()
    {
        playerSprite.sprite = images[Level];
    }
}
