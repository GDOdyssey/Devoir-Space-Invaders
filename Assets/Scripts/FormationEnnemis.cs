using UnityEngine;

public class FormationEnnemis : MonoBehaviour
{
    public float speed = 2f;
    public float moveDown = 0.5f;
    public float boundaryX = 8f;

    private int direction = 1;

    void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        foreach (Transform enemy in transform)
        {
            if (enemy != null && Mathf.Abs(enemy.position.x) > boundaryX)
            {
                direction *= -1;
                transform.Translate(new Vector3(0, 0, -moveDown));
                break;
            }
        }
    }
}
