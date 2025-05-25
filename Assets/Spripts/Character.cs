using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float HP = 100f;
    public GameObject Camera;
    public GameObject GameOverPanel;
    private bool isDead = false;

    public void GetDamage(float damage)
    {
        if (isDead) return;
        HP -= damage;
        if (HP <= 0)
        {
            isDead = true;
            HP = 0;
            Debug.Log("Character is dead");
            if(GameOverPanel != null)
                GameOverPanel.SetActive(true);
            StartCoroutine(Die());
        }
    }
    private IEnumerator Die()
    {
        if(GetComponent<WanderingAI>() is WanderingAI ai)
            ai.enabled = false;
        transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        if (Camera != null)
        {
            Camera.transform.parent = null;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        Destroy(this.gameObject);
    }
}
