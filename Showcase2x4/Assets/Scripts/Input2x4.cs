using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input2x4 : MonoBehaviour
{
    [SerializeField] internal References references;
    [Serializable]
    internal class References
    {
        public CameraController cameraController;
    }

    public void OnRightClick(InputValue value) => references.cameraController.OnRightClick(value.isPressed);
    public void OnLook(InputValue value) => references.cameraController.OnLook(value.Get<Vector2>());
    public void OnScrollWheel(InputValue value) => references.cameraController.OnScrollWheel(value.Get<Vector2>());

}
