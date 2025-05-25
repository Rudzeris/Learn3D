using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ReloadButton : MonoBehaviour
{
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ReloadGame);
    }
    private void ReloadGame()
        => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
