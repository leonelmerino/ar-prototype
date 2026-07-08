using UnityEngine;
using Google.XR.ARCoreExtensions;

public class GeospatialDebugHUD : MonoBehaviour
{
    public AREarthManager earthManager;

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        style.normal.textColor = Color.white;

        if (earthManager == null)
        {
            GUI.Label(new Rect(20, 20, 1000, 60), "Earth Manager: NULL", style);
            return;
        }

        var pose = earthManager.CameraGeospatialPose;

        GUI.Label(new Rect(20, 20, 1200, 60), "Earth: " + earthManager.EarthTrackingState, style);
        GUI.Label(new Rect(20, 70, 1200, 60), "Lat: " + pose.Latitude.ToString("F6"), style);
        GUI.Label(new Rect(20, 120, 1200, 60), "Lon: " + pose.Longitude.ToString("F6"), style);
        GUI.Label(new Rect(20, 170, 1200, 60), "HAcc: " + pose.HorizontalAccuracy.ToString("F2") + "m", style);
    }
}
