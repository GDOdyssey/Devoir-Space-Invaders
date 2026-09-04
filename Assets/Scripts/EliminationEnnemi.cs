using UnityEngine;

public class EliminationEnnemi : MonoBehaviour
{
    public float moveSpeed = 1f;
    public int xpDrop = 10;

    public void Die()
    {
        XPManager.Instance.AddXP(10);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerBlaster"))
        {
            Die();
            Destroy(other.gameObject);
        }
    }
}
