using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneActions : MonoBehaviour
{
    private Animator phoneAnimator;

    [SerializeField] private GameObject callPanel;
    void Start()
    {
        phoneAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            callPanel.SetActive(true);
        }
    }
    
    private bool isCalling()
    {
        Debug.Log("Someone is calling..");
        return true;
    }

    public void onUserClickAcceptDecline(int choice) // 1 = Accept call, 0 = Decline call
    {
        if (choice == 1)
        {
            //Give Task
            callPanel.SetActive(false);
        }
        callPanel.SetActive(false); // Else
    }
}
