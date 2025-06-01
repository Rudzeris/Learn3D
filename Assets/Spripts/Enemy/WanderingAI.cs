using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            PlayerMove playerMove = hit.collider.GetComponent<PlayerMove>();
            Character character = hit.collider?.GetComponent<Character>();
            if(character != null)
            {
                // Логика создания и направления Fireball
                if(_fireball == null)
                {
                    _fireball = Instantiate(fireballPrefab);
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            } else
            if (hit.distance < obstacleRange)
            {
                // Противник атакует вблизи - поэтому код находится внутри проверки дистанции
                if (character != null && playerMove != null)
                {
                    character.GetDamage(50 * Time.deltaTime);
                }
                else
                {
                    float angle = UnityEngine.Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

}
