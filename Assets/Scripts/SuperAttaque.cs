using System.Collections;
using UnityEngine;

public class SuperAttaque : MonoBehaviour
{
    public static SuperAttaque Instance;

    public Transform canonLaser;
    public Transform canonGrenade;
    public GameObject laserPrefab;
    public GameObject grenadePrefab;
    public int grenadeXP = 50;
    public int laserXP = 75;
    public int sweepXP = 150;

    private void Awake()
    {
        Instance = this;
    }

    public void UseGrenade()
    {
        if (XPManager.Instance.xp < grenadeXP) return;

        XPManager.Instance.ConsumeXP(grenadeXP);

        Instantiate(grenadePrefab, canonGrenade.position, canonGrenade.rotation);
    }
    public void UseLaser()
    {
        if (XPManager.Instance.xp < laserXP) return;

        XPManager.Instance.ConsumeXP(laserXP);

        GameObject laser = Instantiate(laserPrefab, canonLaser.position, canonLaser.rotation);
        laser.transform.SetParent(canonLaser);
    }
    public void UseSweep()
    {
        if (XPManager.Instance.xp < sweepXP) return;

        XPManager.Instance.ConsumeXP(sweepXP);

        var aliens = Object.FindObjectsByType<EliminationEnnemi>(FindObjectsSortMode.None);

        foreach (var alien in aliens) alien.DieNoXP();
    }
}
