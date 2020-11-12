using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New GameSong", menuName = "Sound/Game Song")]
public class GameSong : GameSound
{
    [Header("Track Info")] 
    public string songName;
    public string bandName;
    
    [Header("Created By")]
    public string soundDesignerName;
}
