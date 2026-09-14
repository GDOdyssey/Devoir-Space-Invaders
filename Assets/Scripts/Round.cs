using UnityEngine;

public class Round : MonoBehaviour
{
    public static Round Instance;
    public bool roundEnCours = false;
    public GenerationEnnemis spawner;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Round.Instance.DemarrerRound();
    }

    void Update()
    {
        if (!roundEnCours) return;
        CheckWave();
    }

    public void DemarrerRound()
    {
        roundEnCours = true;
        spawner.SpawnWave();
    }

    void CheckWave()
    {
        EliminationEnnemi[] aliens = FindObjectsOfType<EliminationEnnemi>();

        if (aliens.Length == 0)
        {
            spawner.SpawnSecondWave();
        }
    }

    public void ResetRound()
    {
        roundEnCours = false;

        EliminationEnnemi[] aliens = FindObjectsOfType<EliminationEnnemi>();
        foreach (var a in aliens)
            Destroy(a.gameObject);

        BlasterEnnemi[] tirs = FindObjectsOfType<BlasterEnnemi>();
        foreach (var t in tirs)
            Destroy(t.gameObject);

        StopAllCoroutines();
        spawner.isSpawning = false;
    }
}
