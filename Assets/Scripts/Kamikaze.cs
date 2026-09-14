using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    public float kamikaze = 0.02f;   // chance par seconde
    public float speed = 6f;
    public float duration = 7f;

    private bool isKamikaze = false;
    private GenerationEnnemis spawner;

    void Start()
    {
        spawner = FindObjectOfType<GenerationEnnemis>();
    }

    void Update()
    {
        if (!isKamikaze)
        {
            TentativeDevenirKamikaze();
        }
        else
        {
            DescenteKamikaze();
        }
    }

    void TentativeDevenirKamikaze()
    {
        if (spawner != null && spawner.isSpawning) return;

        if (KamikazesManager.Instance != null && !KamikazesManager.Instance.PeutLancerKamikaze()) return;

        if (Random.value < kamikaze * Time.deltaTime)
        {
            isKamikaze = true;

            transform.parent = null;

            GetComponent<Renderer>().material.color = Color.red;

            if (KamikazesManager.Instance != null) KamikazesManager.Instance.RegisterKamikaze();

            Destroy(gameObject, duration);
        }
    }

    void DescenteKamikaze()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    void OnDestroy()
    {
        if (isKamikaze && KamikazesManager.Instance != null) KamikazesManager.Instance.UnregisterKamikaze();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isKamikaze) return;

        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Application.Quit();
        }
    }
}
