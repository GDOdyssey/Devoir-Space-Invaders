using UnityEngine;

public class FormationEnnemis : MonoBehaviour
{
    public float speed = 2f;
    public float moveDown = 0.5f;
    public float boundaryX = 15f;

    private int direction = 1;
    private float lastMoveDownTime = 0f;
    public float moveDownCooldown = 0.1f;

    private GenerationEnnemis generator;

    void Start()
    {
        generator = GetComponent<GenerationEnnemis>();
    }

    void Update()
    {
        // Empêche tout mouvement pendant le spawn
        if (generator != null && generator.isSpawning)
            return;

        // Mouvement horizontal
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        // Détection des limites (GLOBAL, pas local)
        foreach (Transform enemy in transform)
        {
            if (enemy != null && Mathf.Abs(enemy.position.x) > boundaryX)
            {
                // Cooldown pour éviter plusieurs descentes dans le même frame
                if (Time.time - lastMoveDownTime > moveDownCooldown)
                {
                    direction *= -1;
                    transform.Translate(new Vector3(0, 0, -moveDown));
                    lastMoveDownTime = Time.time;
                }
                break;
            }
        }
    }
}
