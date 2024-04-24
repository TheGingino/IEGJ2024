using UnityEngine;
using UnityEngine.SceneManagement;

public class RESTART : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
