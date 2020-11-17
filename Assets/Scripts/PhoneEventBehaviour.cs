using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PhoneEventBehaviour : ConfirmationPanel
{
    public PhoneEvent phoneEvent;
    public Text chanceText;
    private float _elapsedTime;
    private bool accepted;
    public void SetUp(PhoneEvent phoneEvent)
    {
        this.phoneEvent = phoneEvent;
        confirmText.text = phoneEvent.dialogue;
        chanceText.text = phoneEvent.ToString();
    }

    public override void Confirm()
    {
        var myList = new List<Behaviour>();
        myList.AddRange(GetComponentsInChildren<Image>());
        myList.AddRange(GetComponentsInChildren<Text>());
        foreach (var image in myList)
        {
            image.enabled = false;
        }
        accepted = true;
    }


    public override void Cancel()
    {
        Destroy(this.gameObject);
    }

        private void Update()
    {
        if (accepted)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= phoneEvent.time)
            {
                if (Random.Range(0f, 1f) < phoneEvent.successChance)
                {
                    phoneEvent.ApplyPositiveOutcome();   
                }
                else
                {
                    phoneEvent.ApplyNegativeOutcome();
                }
                Destroy(this.gameObject);
            }
        }
    }
}
