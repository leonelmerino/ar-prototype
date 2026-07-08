using UnityEngine;

public class VideoBillboard : MonoBehaviour
{
    [SerializeField] private bool mantenerVertical = true;
    [SerializeField] private bool invertirFrente = false;

    private Camera arCamera;

    private void Start()
    {
        arCamera = Camera.main;
    }

    private void LateUpdate()
    {
        if (arCamera == null)
        {
            arCamera = Camera.main;
            return;
        }

        Vector3 direccion = arCamera.transform.position - transform.position;

        if (mantenerVertical)
        {
            direccion.y = 0f;
        }

        if (direccion.sqrMagnitude < 0.001f)
        {
            return;
        }

        transform.rotation = Quaternion.LookRotation(direccion, Vector3.up);

        if (invertirFrente)
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
