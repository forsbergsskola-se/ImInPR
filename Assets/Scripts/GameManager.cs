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
        
        TimePlayed.Initialize(cash);
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

    private void OnDestroy()
    {
        TimePlayed.SaveTimePlayed();
    }

    [ContextMenu("Delete Save Game")]
    public void DeleteSaveGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
