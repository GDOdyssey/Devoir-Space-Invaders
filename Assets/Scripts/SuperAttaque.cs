using System.Collections;
using UnityEngine;

public class SuperAttaque : MonoBehaviour
{
    public static SuperAttaque Instance;

    public float grenadeAOE = 4f;
    public LineRenderer laser;
    public float laserDuration = 2f;

    private void Awake()
    {
        Instance = this;
    }

    public void UseGrenade()
    {
        if (!XPManager.Instance.IsHalfFull()) return;

        XPManager.Instance.ConsumeXP(50);

        Collider[] hits = Physics.OverlapSphere(Vector3.zero, grenadeAOE);
        foreach (var h  in hits)
        {
            EliminationEnnemi a = h.GetComponent<EliminationEnnemi>();
            if (a != null)
            {
                a.Die();
            }
        }
    }

    public void UseSweep()
    {
        if (!XPManager.Instance.IsVeryFull()) return;

        XPManager.Instance.ConsumeXP(150);

        var aliens = Object.FindObjectsByType<EliminationEnnemi>(FindObjectsSortMode.None);

        foreach (var alien in aliens)
            alien.Die();
    }

    public void UseLaser()
    {
        if (!XPManager.Instance.IsThreeQuarterFull()) return;

        XPManager.Instance.ConsumeXP(75);
        StartCoroutine(Laser());
    }

    IEnumerator Laser()
    {
        laser.enabled = true;

        float timer = 0f;
        while (timer < laserDuration)
        {
            timer += Time.deltaTime;

            Ray ray = new Ray(laser.transform.position, laser.transform.forward);
            RaycastHit[] hits = Physics.RaycastAll(ray, 100f);

            foreach (var h in hits)
            {
                EliminationEnnemi a = h.collider.GetComponent<EliminationEnnemi>();
                if (a != null) a.Die();
            }

            yield return null;
        }

        laser.enabled = false;
    }
}
