using UnityEngine;

public class BandTask : MonoBehaviour
{
    [SerializeField] private BandTaskConfig task;
    //private Band band;
    private float time;
    private bool owned;

    //TODO implement band class
    /*void Setup(ref Band band)
    {
        this.band = band;
        time = task.time;
        owned = true;
    }*/

    private void Update()
    {
        if (owned)
        {
            time -= Time.deltaTime;
        }

        /*if (time < 0)
        {
            task.Finish(band);
        }*/
    }
}
