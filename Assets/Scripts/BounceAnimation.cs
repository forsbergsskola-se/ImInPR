using System;
using UnityEngine;

public class BounceAnimation : MonoBehaviour
{
    public float baseTransitionTime;
    public float durationBetweenReplay;
    public float distanceToMoveY;
    public float downDifference;
    private Vector3 _startLocation, _endLocation;
    private bool movingUpwards = true;
    private bool isPlaying = true;
    private bool movingDownwards;
    private float waitTimeRemaining, elapsedTime;
    private int timesToDo;
    private float transitionTime;

    private void Start()
    {
        _startLocation = this.transform.position;
        _endLocation = new Vector2(_startLocation.x, _startLocation.y + distanceToMoveY);
        waitTimeRemaining = durationBetweenReplay;
    }

    private void Update()
    {
        if (isPlaying)
        {
            Debug.Log("move");
            if (transform.position.y < _endLocation.y && !movingDownwards)
            {
                movingUpwards = true;
            }
            else if (!movingDownwards)
            {
                movingUpwards = false;
                movingDownwards = true;
                elapsedTime = 0;
            }
            
            elapsedTime += Time.deltaTime;
            Move();

            if (transform.position.y <= _startLocation.y)
            {
                timesToDo++;
                movingDownwards = false;
                movingUpwards = true;
                elapsedTime = 0;
                waitTimeRemaining = durationBetweenReplay;
            }
        }
        else
        {
            waitTimeRemaining -= Time.deltaTime;
            if (waitTimeRemaining <= 0)
            {
                waitTimeRemaining = durationBetweenReplay;
                isPlaying = true;
            }
        }

        if (timesToDo == 2)
        {
            isPlaying = false;
            timesToDo = 0;
        }

        if (timesToDo == 1)
        {
            transitionTime = baseTransitionTime * 0.75f;
        }

        if (timesToDo == 0)
        {
            transitionTime = baseTransitionTime;
        }
    }

    void Move()
    {
        if (movingUpwards)
        {
            transform.position = Vector2.Lerp(_startLocation, _endLocation, elapsedTime / transitionTime);
        }
        else
            transform.position = Vector2.Lerp(_endLocation, _startLocation, elapsedTime / (transitionTime / downDifference));
    }
}
