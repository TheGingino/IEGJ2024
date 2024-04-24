using TMPro;
using UnityEngine;

public class UI_Health : MonoBehaviour
{
    [SerializeField] private int lives;
    [SerializeField] private TextMeshProUGUI livesText;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        UpdateLivesUI();
    }

    public void DecreaseLives(int amount)
    {
        lives -= amount;
        UpdateLivesUI();
    }

    void UpdateLivesUI()
    {
        livesText.text = lives.ToString();
    }
}