using UnityEngine;

#if UNITY_ANDROID
using UnityEngine.Android;
#endif

public class ARPermissionsBootstrap : MonoBehaviour
{
    private void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        RequestAndroidPermissions();
#endif
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void RequestAndroidPermissions()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            Permission.RequestUserPermission(Permission.Camera);

        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            Permission.RequestUserPermission(Permission.FineLocation);

        if (!Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
            Permission.RequestUserPermission(Permission.CoarseLocation);
    }
#endif
}
