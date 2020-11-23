using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BandBehaviour))]
public class BandUI : MonoBehaviour
{
    public SetString lvl, genre, bandName;
    public SetFloat awareness, popularity;
    public SetSprite logo;

    public void SetUp(Band band)
    {
        var bandBehaviour = GetComponent<BandBehaviour>();
        bandName.Invoke(band.name);
        genre.Invoke(band.genre);
        logo.Invoke(band.thumbnail);
        bandBehaviour.OnLevelUp += BandBehaviourOnLevelUp;
        bandBehaviour.OnPopularityChange += BandBehaviourOnPopularityChange;
        bandBehaviour.OnAwarenessChange += BandBehaviourOnAwarenessChange;
    }

    private void BandBehaviourOnAwarenessChange(float value)
    {
        awareness.Invoke(value);
    }

    private void BandBehaviourOnPopularityChange(float value)
    {
        popularity.Invoke(value);
    }

    private void BandBehaviourOnLevelUp(int level)
    {
        lvl.Invoke(level.ToString());
    }
}
