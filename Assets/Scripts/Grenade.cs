using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float speed = 5f;
    public float minDelay = 1f;
    public float maxDelay = 3f;
    public float AOE = 5f;
    public float lightning = 8f;
    private float timer;
    private Renderer material;

    void Start()
    {
        material = GetComponent<Renderer>();
        float delay = Random.Range(minDelay, maxDelay);
        Invoke(nameof(Explode), delay);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //c'est cense etre un effet de clignottement mais a cause de la taille et du material utilise ca ne se voit que tres peu
        timer += Time.deltaTime * lightning;
        float alpha = Mathf.Abs(Mathf.Sin(timer));
        Color c = material.material.color;
        c.a = Mathf.Lerp(0.2f, 1f, alpha);
        material.material.color = c;
    }

    void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, AOE);

        foreach (var h in hits)
        {
            EliminationEnnemi ennemi = h.GetComponent<EliminationEnnemi>();
            if (ennemi != null)
            {
                ennemi.DieNoXP();
            }
        }

        Destroy(gameObject);
    }
}
