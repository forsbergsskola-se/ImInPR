using UnityEngine;

public class PopUps : MonoBehaviour
{
    public Vector2 PopUpPosition = new Vector2(0, 0);
    public bool isCreated; 


    [SerializeField] private GameObject PopUpPrefab;

    public void PopUpMenu()
    {
        if (!isCreated) 
        {
            Instantiate(PopUpPrefab, FindObjectOfType<GameManager>().transform);
            isCreated = true;
        }
    }

    public void AcceptPopUp()
    {
        // Give task
        isCreated = false;
    }

    public void DeclinePopUp()
    {
        isCreated = false;
    }
}
