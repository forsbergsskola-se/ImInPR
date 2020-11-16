using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private Sprite[] images;

    public int Level { get; private set; }

    public void LevelUp()
    {
        Level = GetLowestLevel();
        GetComponent<Image>().sprite = images[Mathf.Clamp(Level - 1, 0, 4)];
        
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
