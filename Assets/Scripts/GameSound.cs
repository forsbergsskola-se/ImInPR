using UnityEngine;

[CreateAssetMenu(fileName = "New GameSound", menuName = "Sound/Game Sound")]
public class GameSound : ScriptableObject
{
    [SerializeField] public AudioClip clip;
}