using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARDebugOverlay : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.color = Color.white;
        GUI.Label(
            new Rect(30, 30, 1200, 300),
            $"ARSession.state: {ARSession.state}\n" +
            $"ARSession.notTrackingReason: {ARSession.notTrackingReason}\n" +
            $"Time: {Time.time:F1}"
        );
    }
}