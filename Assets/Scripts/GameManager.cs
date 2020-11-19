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
    public GameObject ImagePopUp;

    [Header("Bands UI")]
    public Transform BandUIContainer;
    public GameObject BandUIElement;
    public GameObject BandSelector;

    public bool NewGame => bandsOwned(bands) == 0;
    private void Awake()
    {
        cash = new Cash();
    }

    private void Start()
    {
        officeEquipment = GetComponentsInChildren<OfficeInteractable>().ToList();

        if (NewGame)
        {
            var instance = Instantiate(FindObjectOfType<GameManager>().BandSelector, FindObjectOfType<GameManager>().transform);
            instance.GetComponent<BandSelectorController>().PopulateList(BandTier.Tier1);
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
            instance.GetComponent<BandSelectorController>().PopulateList(BandTier.Tier3);
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
    
    [ContextMenu("Delete Save Game")]
    public void DeleteSaveGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
