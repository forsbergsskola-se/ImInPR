using UnityEngine;

public class PopUps : MonoBehaviour
{
    public bool PopUp = false;


    [SerializeField] private GameObject PopUpPanel;
    public void Update()
    {
        PopUpMenu();
    }
    
    public void PopUpMenu()
    {
        if (PopUp) 
        {
            PopUpPanel.SetActive(true);
        }
        else
        {
            PopUpPanel.SetActive(false); 
        }
    }

    public void AcceptPopUp()
    {
        // Give task
        PopUp = false;
    }

    public void DeclinePopUp()
    {
        PopUp = false;
    }
}
