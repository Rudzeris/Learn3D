using UnityEngine;

public enum CameraRotate { None, X, Y }
public class PlayerRotate : MonoBehaviour
{
    // �������� ������ ��� ������, �������� X. ��� ������ - Y
    public CameraRotate CameraRotate = CameraRotate.None;
    public float SpeedRotation = 10f;
    public float maxAngle = 45f;
    public float minAngle = -45f;
    private float currentAngle = 0f;
    // Update is called once per frame
    void Update()
    {
        float y = 0;
        float x = 0;
        switch (CameraRotate)
        {
            case CameraRotate.X:
                y = Input.GetAxis("Mouse X") * Time.deltaTime * SpeedRotation;
                break;
            case CameraRotate.Y:
                x = -Input.GetAxis("Mouse Y") * Time.deltaTime * SpeedRotation;
                currentAngle = Mathf.Clamp(currentAngle + x, minAngle, maxAngle);
                break;
        }
        transform.localEulerAngles = new Vector3(
                    currentAngle,
                    transform.localEulerAngles.y,
                    transform.localEulerAngles.z
                    );
        transform.Rotate(0, y, 0); // �������� ����� ������
    }
}
