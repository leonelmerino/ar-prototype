using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARSessionStatusOverlay : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.color = Color.white;
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 36;
        style.normal.textColor = Color.white;

        string text =
            $"ARSession.state: {ARSession.state}\n" +
            $"NotTrackingReason: {ARSession.notTrackingReason}\n" +
            $"Time: {Time.time:F1}";

        GUI.Label(new Rect(30, 80, Screen.width - 60, 300), text, style);
    }
}
