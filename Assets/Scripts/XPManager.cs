using UnityEngine;
using UnityEngine.UI;

public class XPManager : MonoBehaviour
{
    public static XPManager Instance;

    public int xp = 0;
    public int xpMax = 150;
    public Slider xpBar;

    private void Awake()
    {
        Instance = this;
    }

    public void AddXP(int amount)
    {
        xp += amount;
        xp = Mathf.Clamp(xp, 0, xpMax);
        xpBar.value = (float)xp / xpMax;
    }

    public bool IsVeryFull()
    {
        return xp >= xpMax;
    }

    public bool IsHalfFull()
    {
        return xp >= 50;
    }

    public bool IsThreeQuarterFull()
    {
        return xp >= 75;
    }

    public void ConsumeXP(int amount)
    {
        xp -= amount;
        xpBar.value = (float)xp / xpMax;
    }
}
