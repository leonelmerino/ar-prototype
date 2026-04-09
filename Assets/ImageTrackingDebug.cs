using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTrackingDebug : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager manager;

    private void OnEnable()
    {
        manager.trackablesChanged.AddListener(OnChanged);
    }

    private void OnDisable()
    {
        manager.trackablesChanged.RemoveListener(OnChanged);
    }

    private void OnChanged(ARTrackablesChangedEventArgs<ARTrackedImage> changes)
    {
        foreach (var img in changes.added)
        {
            Debug.Log($"[ADDED] {img.referenceImage.name} state={img.trackingState}");
        }

        foreach (var img in changes.updated)
        {
            Debug.Log($"[UPDATED] {img.referenceImage.name} state={img.trackingState}");
        }

        foreach (var removed in changes.removed)
        {
            Debug.Log($"[REMOVED] id={removed.Key}");
        }
    }
}