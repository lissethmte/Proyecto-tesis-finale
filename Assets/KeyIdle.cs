// KeyIdleRotate.cs
using UnityEngine;

public class KeyIdleRotate : MonoBehaviour
{
    [Tooltip("Velocidad en grados/segundo")]
    public Vector3 rotationSpeed = new Vector3(0f, 60f, 0f);
    public bool useLocal = true;

    void Update()
    {
        if (useLocal)
            transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
        else
            transform.Rotate(rotationSpeed * Time.deltaTime, Space.World);
    }
}

