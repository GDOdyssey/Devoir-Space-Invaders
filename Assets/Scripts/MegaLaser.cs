using UnityEngine;

//La partie concernant le rallentissement du vaisseau a ete generee par IA
public class MegaLaser : MonoBehaviour
{
    public float slow = 0.5f;
    public float lifeTime = 1.5f;
    private MouvementVaisseau mouvementVaisseau;

    void Start()
    {
        if (mouvementVaisseau != null) mouvementVaisseau.speed *= slow;
        Destroy(gameObject, lifeTime);
    }

    void OnDestroy()
    {
        if (mouvementVaisseau != null) mouvementVaisseau.speed /= slow;
    }

    private void OnTriggerEnter(Collider other)
    {
        EliminationEnnemi ennemi = other.GetComponent<EliminationEnnemi>();
        if (ennemi != null)
        {
            ennemi.DieNoXP();
        }
    }
}
