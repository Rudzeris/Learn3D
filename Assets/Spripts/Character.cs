using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public float HP = 100f;
    public GameObject GameOverPanel;
    private bool isDead = false;
    void Update()
    {
        GetDamage(10*Time.deltaTime);
    }
    public void GetDamage(float damage)
    {
        if (isDead) return;
        HP -= damage;
        if(HP <= 0)
        {
            isDead = true;
            HP = 0;
            Debug.Log("Character is dead");
            GameOverPanel.SetActive(true);
            Destroy(gameObject);
        }
    }
    public void ReloadGame()
    {
        //Debug.Log("Reloading game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
