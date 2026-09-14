using UnityEngine;

public class BlasterEnnemi : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 7f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EliminationJoueur joueur = other.GetComponent<EliminationJoueur>();
            if (joueur != null)
            {
                joueur.PrendreDegats(1);
            }
            Destroy(gameObject);
        }
    }
}
