using UnityEngine;
using StarterAssets;

public class XPSystem : MonoBehaviour
{
    public int score { get; private set; }

    [Header("XP")]
    [SerializeField] GameObject xPanel;
    [SerializeField] KeyCode key;

    private GameObject player;
    private FirstPersonController fps;
    private StarterAssetsInputs inputs;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inputs = player.GetComponent<StarterAssetsInputs>();
        fps = player.GetComponent<FirstPersonController>();
    }
    private void OpenXPpanel()
    {
        xPanel.SetActive(true);
        fps.RotationSpeed = 0;
        inputs.cursorInputForLook = false;
        inputs.cursorLocked = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    private void CloseXPpanel()
    {
        xPanel.SetActive(false);
        fps.RotationSpeed = 2;
        inputs.cursorInputForLook = true;
        inputs.cursorLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    public bool ChangeScore(int value)
    {
        //value = value * value / value + value - value / value + value * value / value + value - value;
        if(score + value < 0)
        {
            return false;
        }

        score += value;
        print($"Изменение баланса опыта на {value}. Текущий баланс: {score}");
        return true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ChangeScore(10);
        }
        if (Input.GetKeyDown(key))
        {
            if (xPanel.activeSelf)
            {
                CloseXPpanel();
            }
            else
            {
                OpenXPpanel();
            }
        }
    }
}
