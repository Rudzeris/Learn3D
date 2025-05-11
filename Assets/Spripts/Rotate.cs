using UnityEngine;

public class Rotate : MonoBehaviour
{
    bool up; // переменные создаем здесь
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start game");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(0, transform.position.y + 0.01f, 0);
        // trasform.position - это текущая позиция
        transform.Translate(0, 0.1f, 0); // Смещение
        transform.Rotate(0, 90/60f, 0); // Вращение
    }
}
