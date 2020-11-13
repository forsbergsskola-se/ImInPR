using UnityEngine;

public class PhoneActions : MonoBehaviour
{
    private Animator phoneAnimator;
    public int randomNumberRange;
    public float repeatTime = 20f;
    public PopUps popUpsScript;

    void Start()
    {
        phoneAnimator = gameObject.GetComponent<Animator>();
        InvokeRepeating("IsCalling",2f, repeatTime);
    }

    void Update()
    { 
        popUpsScript.Update();
    }
    
    private void IsCalling()
    {
        if (!popUpsScript.PopUp)
        {
            if (NumberGenerator() == randomNumberRange - 1)
            {
                popUpsScript.PopUp = true;
            }
        }
    }

    private int NumberGenerator()
    {
        return Random.Range(0, randomNumberRange);
    }
}
