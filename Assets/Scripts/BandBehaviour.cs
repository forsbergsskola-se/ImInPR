using System;
using UnityEngine;

[RequireComponent(typeof(BandUI))]
public class BandBehaviour : MonoBehaviour
{
    public Bands bandConfig;
    private int currentLevel;
    public Experience awareness;
    public Experience popularity;

    private void Start()
    {
        UpdateUI();
    }

    void GenerateTask()
    {
        FindObjectOfType<GameManager>().taskGenerator.SpawnTask(this);
    }


    public void OnReward()
    {
        //TODO UpdateUI here, Do some Visual Effect?
    }

    //TODO Decide whether to make the UI a separate class
    void UpdateUI()
    {
        GetComponent<BandUI>().UpdateUI(1, 0.7f, 0.7f);
    }
}
