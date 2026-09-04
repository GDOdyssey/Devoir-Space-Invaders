using UnityEngine;

public class GenerationEnnemis : MonoBehaviour
{
    public GameObject ennemi;
    public int lignes = 8;
    public int colonnes = 8;
    public float spacing = 1.5f;

    void Start()
    {
        for (int l = 0; l < lignes; l++)
        {
            for (int c = 0; c < colonnes; c++)
            {
                Vector3 pos = new Vector3(c * spacing, 0, l * spacing);

                Instantiate(ennemi, transform.position + pos, Quaternion.identity, transform);
            }
        }
    }
}
