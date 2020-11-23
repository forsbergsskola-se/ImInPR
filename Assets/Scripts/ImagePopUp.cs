using UnityEngine.UI;
using UnityEngine;
using static ResolutionRelation;

public class ImagePopUp : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.up * 20f;
    public float variation = 5f;
    public float alphaFadeSpeed = 5f;
    public Image image;
    public Sprite[] sprites;
    private float RealVariation => variation * WidthRelation;
    private Vector3 RealMoveDirection => moveDirection * HeightRelation;
    
    void Start() {
        this.variation = Random.Range(-this.variation, this.variation);
        this.transform.position += new Vector3(RealVariation, 0f, 0f);
        this.moveDirection.x += this.variation;
    }
    
    public void SetUp(int sprite)
    {
        image.sprite = sprites[sprite];
    }

    private void Update()
    {
        this.transform.position += RealMoveDirection * Time.deltaTime;
        var color = image.color;
        color.a -= this.alphaFadeSpeed * Time.deltaTime;
        image.color = color;
        if (color.a <= 0f)  
            Destroy(this.gameObject);
    }
}
