using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BG : MonoBehaviour
{
    [SerializeField] private Sprite[] images;

    public event Action OnBGChanged;
    public int Level { get; private set; }

    private void Start()
    {
        LevelUp();
    }

    public void LevelUp()
    {
        var originalLevel = Level;
        Level = GetLowestLevel();
        GetComponent<Image>().sprite = images[Mathf.Clamp(Level - 1, 0, 4)];
        if (Level != originalLevel)
        {
            OnBGChanged?.Invoke();
            FindObjectOfType<SoundManager>().PlayGameSound("NewOffice");
        }
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
        
        return lowestLvlItem;
    }
}
