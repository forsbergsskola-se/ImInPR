using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandBehaviour : MonoBehaviour
{
    public Bands bandConfig;
    private int currentLevel;
    public Experience awareness;
    public Experience popularity;

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
        
    }
}
