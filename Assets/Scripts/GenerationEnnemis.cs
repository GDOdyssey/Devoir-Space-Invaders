using UnityEngine;
using System.Collections;

//Ce script a en partie ete genere par IA
public class GenerationEnnemis : MonoBehaviour
{
    public GameObject ennemi;
    public int lignes1 = 8;
    public int colonnes1 = 8;
    public int lignes2 = 10;
    public int colonnes2 = 5;
    public float spacing = 1.5f;
    public float spawnDelay = 0.05f;
    public bool isSpawning = false;
    private Vector3 startPos;

    public void SpawnWave()
    {
        transform.position = startPos;
        StartCoroutine(SpawnWaveRoutine());
    }

    public void SpawnSecondWave()
    {
        transform.position = startPos;
        StartCoroutine(SpawnSecondWaveRoutine());
    }

    IEnumerator SpawnWaveRoutine()
    {
        isSpawning = true;

        FormationEnnemis formation = GetComponent<FormationEnnemis>();
        if (formation != null) formation.enabled = false;

        MouvementVaisseau player = FindObjectOfType<MouvementVaisseau>();
        if (player != null) player.canMoveAndShoot = false;

        TirEnnemi[] tirs = GetComponentsInChildren<TirEnnemi>();
        foreach (var t in tirs) t.canShoot = false;

        for (int r = 0; r < lignes1; r++)
        {
            for (int c = 0; c < colonnes1; c++)
            {
                Vector3 pos = new Vector3(c * spacing, 0, r * spacing);
                Instantiate(ennemi, transform.position + pos, Quaternion.identity, transform);

                yield return new WaitForSeconds(spawnDelay);
            }
        }

        yield return null;

        if (formation != null) formation.enabled = true;

        if (player != null) player.canMoveAndShoot = true;

        tirs = GetComponentsInChildren<TirEnnemi>();
        foreach (var t in tirs) t.canShoot = true;

        isSpawning = false;
    }

    IEnumerator SpawnSecondWaveRoutine()
    {
        isSpawning = true;

        FormationEnnemis formation = GetComponent<FormationEnnemis>();
        if (formation != null) formation.enabled = false;

        MouvementVaisseau player = FindObjectOfType<MouvementVaisseau>();
        if (player != null) player.canMoveAndShoot = false;

        TirEnnemi[] tirs = GetComponentsInChildren<TirEnnemi>();
        foreach (var t in tirs) t.canShoot = false;

        for (int r = 0; r < lignes2; r++)
        {
            for (int c = 0; c < colonnes2; c++)
            {
                Vector3 pos = new Vector3(c * spacing, 0, r * spacing);
                Instantiate(ennemi, transform.position + pos, Quaternion.identity, transform);

                yield return new WaitForSeconds(spawnDelay);
            }
        }

        yield return null;

        if (formation != null) formation.enabled = true;

        if (player != null) player.canMoveAndShoot = true;

        tirs = GetComponentsInChildren<TirEnnemi>();
        foreach (var t in tirs) t.canShoot = true;

        isSpawning = false;
    }

    void Start()
    {
        //SpawnWave();
    }
}
