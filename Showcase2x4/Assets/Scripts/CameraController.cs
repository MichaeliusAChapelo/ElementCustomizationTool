using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] internal Settings settings;
    [Serializable]
    internal class Settings
    {
        public float HorizontalSensitivity = 0.066f;
        public float VerticalSensitivity = 0.066f;
        public bool InvertedVertical = true;

        [Header("Zoom")]
        public float ZoomSensitivity = 0.25f;
        public float ZoomMin = 1, ZoomMax = 6;
    }

    [SerializeField] internal References references;
    [Serializable]
    internal class References
    {
        [Header("Transforms")]
        public Transform HorizontalRotation;
        public Transform VerticalRotation;
        public Transform DepthDistance;
    }

    private bool RightClickHeld;
    private Vector2 MouseDelta, ScrollWheel;

    internal void OnRightClick(bool rightClickHeld) => RightClickHeld = rightClickHeld;
    internal void OnLook(Vector2 mouseDelta) => MouseDelta = mouseDelta;
    internal void OnScrollWheel(Vector2 scrollWheel) => ScrollWheel = scrollWheel;

    // Update is called once per frame
    void Update()
    {
        if (RightClickHeld)
        {
            HandleHorizontalRotation(MouseDelta.x);
            HandleVerticalRotation(MouseDelta.y);
        }

        HandleZoom(ScrollWheel.y);
    }


    #region Mouse Movement

    void HandleHorizontalRotation(float MouseX)
    {
        references.HorizontalRotation.localEulerAngles += MouseX * settings.HorizontalSensitivity * Vector3.up;
    }

    void HandleVerticalRotation(float MouseY)
    {
        var input = MouseY * settings.VerticalSensitivity;
        if (settings.InvertedVertical)
            input *= -1f;

        float value = references.VerticalRotation.localEulerAngles.x + input;

        if (value > 180) value -= 360;
        else if (value < -180) value += 360;

        value = Mathf.Clamp(value, -80, 90);

        references.VerticalRotation.localEulerAngles = Vector3.right * value;
    }

    void HandleZoom(float mouseScrollDeltaY)
    {
        if (mouseScrollDeltaY > 0 && references.DepthDistance.localPosition.z < -settings.ZoomMin)
            references.DepthDistance.localPosition += Vector3.forward * settings.ZoomSensitivity;
        else if (mouseScrollDeltaY < 0 && references.DepthDistance.localPosition.z > -settings.ZoomMax)
            references.DepthDistance.localPosition += Vector3.back * settings.ZoomSensitivity;
    }

    #endregion


}
