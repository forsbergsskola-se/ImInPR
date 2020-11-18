using UnityEngine;


[CreateAssetMenu(fileName = "New Band", menuName = "Band/New BandList")]
public class BandList : ScriptableObject
{
    public Band[] bands;
}
