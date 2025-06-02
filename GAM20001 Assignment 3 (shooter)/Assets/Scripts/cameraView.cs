using UnityEngine;

public class cameraView : MonoBehaviour
{

    public float mouseSensitivity;

    public Transform playerBody;

    float xRotation = 0f;
    float yRotation = 0f;

    private bool roundactive;

    void Start()
    {

    }

    void Update()
    {
        if (GameObject.Find("RoundSystem").GetComponent<RoundLogic>().roundactive == true)
        {
            //Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            yRotation += mouseX;
            yRotation = Mathf.Clamp(yRotation, -45f, 45f);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
            //playerBody.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        }

        if (GameObject.Find("RoundSystem").GetComponent<RoundLogic>().roundactive == false)
        {
            Cursor.lockState = CursorLockMode.None;
        }


    }

    public void updatesens()
    {
        mouseSensitivity = GameObject.Find("SettingsMenu").GetComponent<Settings>().sens;
    }
}

