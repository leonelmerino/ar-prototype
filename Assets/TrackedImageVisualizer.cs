using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackedImageVisualizer : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager trackedImageManager;
    [SerializeField] private GameObject prefabToSpawn;

    private readonly Dictionary<TrackableId, GameObject> spawnedObjects = new();

    private void OnEnable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackablesChanged.AddListener(OnTrackedImagesChanged);
    }

    private void OnDisable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackablesChanged.RemoveListener(OnTrackedImagesChanged);
    }

    private void OnTrackedImagesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> changes)
    {
        foreach (var trackedImage in changes.added)
        {
            Debug.Log($"[IMG ADDED] {trackedImage.referenceImage.name} state={trackedImage.trackingState}");
            AddOrUpdateImage(trackedImage);
        }

        foreach (var trackedImage in changes.updated)
        {
            Debug.Log($"[IMG UPDATED] {trackedImage.referenceImage.name} state={trackedImage.trackingState} pos={trackedImage.transform.position}");
            AddOrUpdateImage(trackedImage);
        }

        foreach (var removedPair in changes.removed)
        {
            Debug.Log($"[IMG REMOVED] id={removedPair.Key}");

            if (spawnedObjects.TryGetValue(removedPair.Key, out var obj))
            {
                Destroy(obj);
                spawnedObjects.Remove(removedPair.Key);
            }
        }
    }

    private void AddOrUpdateImage(ARTrackedImage trackedImage)
    {
        if (!spawnedObjects.TryGetValue(trackedImage.trackableId, out var spawnedObject))
        {
            spawnedObject = Instantiate(prefabToSpawn, trackedImage.transform);
            spawnedObject.name = "DEBUG_CUBE";
            spawnedObjects.Add(trackedImage.trackableId, spawnedObject);
        }

        spawnedObject.transform.localPosition = new Vector3(0f, 0.05f, 0f);
        spawnedObject.transform.localRotation = Quaternion.identity;
        spawnedObject.transform.localScale = Vector3.one * 0.05f;

        // Para depuración, no lo ocultamos.
        spawnedObject.SetActive(true);
    }
}