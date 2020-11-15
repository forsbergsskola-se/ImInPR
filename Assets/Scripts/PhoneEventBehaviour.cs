using UnityEngine;
using Random = UnityEngine.Random;

public class PhoneEventBehaviour : ConfirmationPanel
{
    public PhoneEvent phoneEvent;
    private float _elapsedTime;
    public void SetUp(PhoneEvent phoneEvent)
    {
        this.phoneEvent = phoneEvent;
        confirmText.text = phoneEvent.dialogue;
    }

    public override void Confirm()
    {
        gameObject.SetActive(false);
    }


    public override void Cancel()
    {
        Destroy(this.gameObject);
    }

        private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= phoneEvent.time)
        {
            if (Random.Range(0f, 1f) < phoneEvent.successChance)
            {
                //Apply Positive Outcome
            }
            else
            {
                //Apply Negative Outcome
            }
            Destroy(this.gameObject);
        }
    }
}
