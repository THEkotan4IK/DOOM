using UnityEngine;

public class XPSystem : MonoBehaviour
{
    public int score { get; private set; }

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
    }
}
