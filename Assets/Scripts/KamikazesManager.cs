using UnityEngine;

public class KamikazesManager : MonoBehaviour
{
    public static KamikazesManager Instance;

    public int maxKamikazes = 3;
    public float globalCooldown = 6f;
    private int currentKamikazes = 0;
    private bool canSpawnKamikaze = true;
    private float cooldownTimer = 0f;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!canSpawnKamikaze)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                canSpawnKamikaze = true;
                cooldownTimer = 0f;
            }
        }
    }

    public bool PeutLancerKamikaze()
    {
        return canSpawnKamikaze && currentKamikazes < maxKamikazes;
    }

    public void RegisterKamikaze()
    {
        currentKamikazes++;

        canSpawnKamikaze = false;
        cooldownTimer = globalCooldown;
    }

    public void UnregisterKamikaze()
    {
        currentKamikazes--;
        if (currentKamikazes < 0) currentKamikazes = 0;
    }
}
