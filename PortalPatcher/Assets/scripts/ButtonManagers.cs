using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagers : MonoBehaviour
{
    // Start is called before the first frame update

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Play()
    {
        SceneManager.LoadScene("MainMap");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
