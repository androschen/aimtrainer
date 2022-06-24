using UnityEngine;


class PlayerController : MonoBehaviour
{
    [SerializeField] Transform cameraHolder;
    [SerializeField] float mouseSensitivity=1;
    float verticalRotation;
    private void Start()
    {
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
    }


    private void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X")* mouseSensitivity);
        verticalRotation-= Input.GetAxisRaw("Mouse Y");
        verticalRotation = Mathf.Clamp(verticalRotation,-90f,90f);
        cameraHolder.localEulerAngles = new Vector3(verticalRotation,0,0);
    }
}

