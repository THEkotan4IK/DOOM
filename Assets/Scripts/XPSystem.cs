using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class XPSystem : MonoBehaviour
{
    public int score { get; private set; }

    [Header("XP")]
    [SerializeField] GameObject xPanel;
    [SerializeField] Text xpText;
    [SerializeField] KeyCode key;

    private GameObject player;
    private GameObject gun;
    private Shooting shoot;
    private FirstPersonController fps;
    private StarterAssetsInputs inputs;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gun = GameObject.FindGameObjectWithTag("Gun");
        shoot = gun.GetComponent<Shooting>();
        inputs = player.GetComponent<StarterAssetsInputs>();
        fps = player.GetComponent<FirstPersonController>();
        RenderXP();
    }
    private void OpenXPpanel()
    {
        xPanel.SetActive(true);
        shoot.canShoot = false;
        fps.RotationSpeed = 0;
        inputs.cursorInputForLook = false;
        inputs.cursorLocked = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    private void CloseXPpanel()
    {
        xPanel.SetActive(false);
        shoot.canShoot = true;
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
        RenderXP();
        return true;
    }

    private void RenderXP()
    {
        xpText.text = $"{score} XP";
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
