using UnityEngine;

public enum CameraRotate { None, X, Y }
public class PlayerRotate : MonoBehaviour
{
    public CameraRotate CameraRotate = CameraRotate.None;
    public float SpeedRotation = 10f;
    // Update is called once per frame
    void Update()
    {
        float x = 0;
        float y = 0;
        switch (CameraRotate)
        {
            case CameraRotate.X:
                x = Input.GetAxis("Mouse X") * Time.deltaTime * SpeedRotation;
                break;
            case CameraRotate.Y:
                y = -Input.GetAxis("Mouse Y") * Time.deltaTime * SpeedRotation;
                break;
        }
        transform.Rotate(y, x, 0);
    }
}
