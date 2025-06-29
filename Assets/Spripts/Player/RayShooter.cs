using System.Collections;
using UnityEngine;
public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(
              _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //StartCoroutine(SphereIndicator(hit.point));
                Character enemy = hit.collider?.GetComponent<Character>();
                if (enemy != null)
                {
                    enemy.GetDamage(50);
                    //audioSource.PlayOneShot(hitAudioClip);

                    //Managers.AudioManager.PlaySound(hitAudioClip);
                    Messenger.Broadcast(GameEvents.PlayerAttacking);
                    //audioSource.clip = hitAudioClip;
                    //audioSource.Play(); // Прерырывает предыдущий звук
                }
            }
        }
    }
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
    private void OnGUI()
    {
        int size = 12;
        float x = _camera.pixelWidth / 2 - size / 4;
        float y = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(x, y, size, size), "*");
    }
}