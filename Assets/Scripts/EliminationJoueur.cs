using UnityEngine;

public class EliminationJoueur : MonoBehaviour
{
    public int vieMax = 10;
    public int vie;

    void Start()
    {
        vie = vieMax;
    }

    public void PrendreDegats(int amount)
    {
        vie -= amount;

        if (vie <= 0)
        {
            Mourir();
        }
    }

    void Mourir()
    {
        Destroy(gameObject);
        Application.Quit();
    }
}
