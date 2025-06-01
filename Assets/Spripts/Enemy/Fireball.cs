using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 3f;
    public float damage = 20f;
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider != null)
        {
            // Проверить, что столкнулись с игроком и нанести ему урон
            Character character = collider.gameObject.GetComponent<Character>();
            if (character != null)
                character.GetDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
