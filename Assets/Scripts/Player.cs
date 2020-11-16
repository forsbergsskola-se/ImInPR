using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //This levels up the player when all OfficeInteractables are upgraded. 

    private Experience xp;
    [SerializeField] private int xpPerLevel;
    [SerializeField] private Sprite[] images;

    public int Level { get; private set; }

    public void LevelUp()
    {
        //Level = (int) Mathf.Floor(xp.ExperienceAmount / xpPerLevel);
        Level = GetLowestLevel();
        GetComponent<Image>().sprite = images[Level - 1];
    }

    public int GetLowestLevel()
    {
        var upgradables = FindObjectsOfType<OfficeInteractable>().ToList();

        int lowestLvlItem = 5;

        foreach (var upgradable in upgradables)
        {
            if (upgradable.Level <= lowestLvlItem)
            {
                lowestLvlItem = Mathf.Min(upgradable.Level);
            }
            
        }
        Debug.Log($"{lowestLvlItem} is the lowest level Upgradable in scene");
        
        return lowestLvlItem;
    }
}
