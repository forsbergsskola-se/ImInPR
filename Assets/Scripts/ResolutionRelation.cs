using UnityEngine;

public static class ResolutionRelation
{
    private static Resolution DefaultResolution => new Resolution{width = 1920, height = 1080, refreshRate = 60};
    private static int DefaultResPixelCount => DefaultResolution.width * DefaultResolution.height;
    public static float ScreenRelation => (float) Screen.width * Screen.height / DefaultResPixelCount;
    public static float WidthRelation => (float) Screen.width / 1920;
    public static float HeightRelation => (float) Screen.height / 1080;
}
