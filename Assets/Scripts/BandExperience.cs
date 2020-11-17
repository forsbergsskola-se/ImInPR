using UnityEngine;

public class BandExperience
{
    private string type;
    private string key;
    private BandBehaviour band;

    public BandExperience(BandBehaviour band, string experience, string bandName)
    {
        this.band = band;
        this.type = experience;
        this.key = bandName;
    }
    public int Amount
    {
        get => PlayerPrefs.GetInt($"{key}.{type}", 0);
        set
        {
            PlayerPrefs.SetInt($"{key}.{this.type}", Mathf.Clamp(value, band.RequiredExp - 105, band.RequiredExp));
            band.CheckIfLeveledUp();
        }
    }
}
