using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class NowPlaying : MonoBehaviour
{
    private enum State{ TransitionIn, Display, TransitionOut}
    
    [SerializeField] private TextMeshProUGUI songTitle;
    [SerializeField] private TextMeshProUGUI soundDesignStudent;
    [SerializeField] private float distanceToMoveOnX = 500f;
    [SerializeField] private float transitionTime = 1.5f;
    [SerializeField] private float durationToLive = 3f;

    private State currentState = State.TransitionIn;
    private Vector2 startingPos;
    private Vector2 endPos;
    float timeElapsed = 0;
    
    public void Setup(string bandName, string songName, string studentName)
    {
        songTitle.SetText($"{bandName} - {songName}");
        soundDesignStudent.SetText($"composed by: {studentName}");
        //StartCoroutine(TransitionIn());
    }
    
    private void Start()
    {
        startingPos = new Vector2(transform.position.x, transform.position.y);
        endPos = new Vector2(startingPos.x + distanceToMoveOnX, startingPos.y);
        Destroy(this.gameObject, 2*transitionTime+durationToLive);
    }

    private void Update()
    {
        
        switch (currentState)
        {
            case State.TransitionIn:
                if (timeElapsed < transitionTime)
                {
                    transform.position = Vector2.Lerp(startingPos, endPos, timeElapsed / transitionTime);
                }
                else
                    currentState = State.Display;
                break;
                /*else if((timeElapsed < transitionTime + durationToLive) && (timeElapsed > transitionTime))
                    currentState = State.Display;*/
              
            case State.Display:
                if (timeElapsed > transitionTime + durationToLive)
                    currentState = State.TransitionOut;
                break;
            case State.TransitionOut:
                timeElapsed = 0;
                transform.position = Vector2.Lerp(endPos, startingPos, timeElapsed / transitionTime);
                break;
        }
        timeElapsed += Time.deltaTime;
    }
}

