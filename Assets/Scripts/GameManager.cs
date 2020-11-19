using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Cash cash;
    public Player player;
    public BandList bands;
    public static List<OfficeInteractable> officeEquipment;
    public TaskGenerator taskGenerator;
    public GameObject ConfirmationPrefab;
    public GameObject PhoneEventPrefab;
    public GameObject CannotAffordPrefab;
    public GameObject OutcomeMessage;
    public GameObject MaxLevelPrefab;
    
    [Header("Bands UI")]
    public Transform BandUIContainer;
    public GameObject BandUIElement;
    public GameObject BandSelector;

    private void Awake()
    {
        cash = new Cash();
    }

    private void Start()
    {
        officeEquipment = GetComponentsInChildren<OfficeInteractable>().ToList();
        
        //if Saved GameDestroyTime from OnDestroy Method != "null"/000000 or whatever default is
        DateTime gameStartTime = DateTime.Now;
        var temp = PlayerPrefs.GetString("GameDestroyTime");
        if (temp != "")
        {
            DateTime destroyedTime = JsonUtility.FromJson<DateTime>(temp);
            Debug.Log(gameStartTime);
            Debug.Log(destroyedTime);
            Debug.Log(destroyedTime - gameStartTime);
        }

        if (bandsOwned(bands) < 1)
        {
            var instance = Instantiate(BandSelector, transform);
            instance.GetComponent<BandSelectorController>().PopulateList(BandTier.Tier1);
        }
        else if (bandsOwned(bands) < 2 && player.Level >= 5)
        {
            var instance = Instantiate(BandSelector, transform);
            instance.GetComponent<BandSelectorController>().PopulateList(BandTier.Tier2);
        }
        else if (bandsOwned(bands) < 3 && player.Level >= 10)
        {
            var instance = Instantiate(BandSelector, transform);
            instance.GetComponent<BandSelectorController>().PopulateList(BandTier.Tier3);
        }
        else if (bandsOwned(bands) < 4 && player.Level >= 15)
        {
            var instance = Instantiate(BandSelector, transform);
            instance.GetComponent<BandSelectorController>().PopulateList(BandTier.Tier3);
        }
    }

    public static int bandsOwned(BandList bandsList)
    {
        int counter = 0;
        foreach (var band in bandsList.bands)
        {
            if (band.GetOwned())
                counter++;
        }

        return counter;
    }

    private void Update()
    {
        
        #region Testing
        if (Input.GetKeyDown(KeyCode.F1)) //Shows name, level and cost of upgrade of all OfficeInteractables
        {
            foreach (var value in officeEquipment)
            {
                Debug.Log(value);
            }
            Debug.Log($"{FindObjectOfType<BG>().GetLowestLevel()} is the level of the lowest item");;
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            var instance = Instantiate(BandSelector, transform);
            
        }

        if (Input.GetKeyDown(KeyCode.F8))
        {
            player.AddXp(50);
            Debug.Log($"Adding 5 xp to {player.name}");
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            cash.Add(500);
        }
        #endregion
    }
    
    private void OnDestroy()
    {
        //Save Date and Time as String.
        //var gameDestroyTime = DateTime.Now.ToString("yyyyMMdd-HHMMss");
        
        PlayerPrefs.SetString("GameDestroyTime", JsonUtility.ToJson(DateTime.Now));
    }

    [ContextMenu("Delete Save Game")]
    public void DeleteSaveGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
