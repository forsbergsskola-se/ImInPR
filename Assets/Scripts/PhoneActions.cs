using UnityEngine;

public class PhoneActions : MonoBehaviour
{
    private Animator phoneAnimator;
    private bool _incomingCall = false;
    public int randomNumber;
    public float repeatTime = 20f;

    [SerializeField] private GameObject callPanel;
    
    void Start()
    {
        phoneAnimator = gameObject.GetComponent<Animator>();
        InvokeRepeating("IsCalling",2f, repeatTime);
    }

    void Update()
    {
       IncomingCallMenu();
    }
    
    private void IsCalling()
    {
        if (!_incomingCall)
        {
            if (NumberGenerator() == randomNumber - 1)
            {
                _incomingCall = true;
            }
        }
    }

    public void IncomingCallMenu()
    {
        if (_incomingCall) 
        {
            callPanel.SetActive(true);
        }
        else
        {
            callPanel.SetActive(false); 
        }
    }

    public void AcceptCall()
    {
        // Give task
        _incomingCall = false;
    }

    public void endCall()
    {
        _incomingCall = false;
    }
    
    public int NumberGenerator()
    {
        return Random.Range(0, randomNumber);
    }
}
