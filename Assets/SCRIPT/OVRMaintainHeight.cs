using UnityEngine;

public class OVRMaintainHeight : MonoBehaviour
{
    public Transform trackingSpace;
    public float desiredHeight = 1.6f; // Altezza ideale in metri

    void LateUpdate()
    {
        if (trackingSpace != null)
        {
            Vector3 pos = trackingSpace.localPosition;
            pos.y = desiredHeight;
            trackingSpace.localPosition = pos;
        }
    }
}
