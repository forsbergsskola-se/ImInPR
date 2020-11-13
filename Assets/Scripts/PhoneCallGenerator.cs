using UnityEngine;

public class PhoneCallGenerator : MonoBehaviour
{
    //private Animator phoneAnimator;
    public int phoneCallRarity;
    public float repeatTime = 20f;

    //TODO Implement a exclamation mark spawner
    void Start()
    {
        InvokeRepeating("IsCalling",2f, repeatTime);
    }

    private void IsCalling()
    {
        if (NumberGenerator() == phoneCallRarity - 1)
        {
               //Spawn Excalmation Mark 
               var instance = Instantiate(FindObjectOfType<GameManager>().ConfirmationPrefab, FindObjectOfType<GameManager>().transform);
               instance.GetComponent<ConfirmationPanel>().SetUp(this.transform, "This is a test message");
        }
    }

    private int NumberGenerator()
    {
        return Random.Range(0, phoneCallRarity);
    }
}
