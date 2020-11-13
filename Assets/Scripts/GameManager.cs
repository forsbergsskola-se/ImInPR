using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Cash cash;
    public static List<OfficeInteractable> officeEquipment;
    public TaskGenerator taskGenerator;
    public PopUps popupManager;

    private void Awake()
    {
        cash = new Cash();
    }

    private void Start()
    {
        officeEquipment = GetComponentsInChildren<OfficeInteractable>().ToList();
        
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
        }
        
        if (Input.GetKeyDown(KeyCode.F2))
        {
            FindObjectOfType<SoundManager>().PlaySong("BastardsOfSatan");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            FindObjectOfType<SoundManager>().PlaySong("GrindCore");
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            FindObjectOfType<SoundManager>().PlaySong("80Funk");
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            FindObjectOfType<SoundManager>().PlaySong("EBBA_Disco");
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            FindObjectOfType<SoundManager>().PlaySong("HipHopBeat");
        }
        #endregion
    }
}
