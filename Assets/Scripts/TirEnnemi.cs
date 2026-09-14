using UnityEngine;

public class TirEnnemi : MonoBehaviour
{
    public GameObject blaster;
    public Transform canon;
    public float cadenceTir = 2f;
    public float chanceTir = 0.1f;
    private float rechargeTir;
    public bool canShoot = true;

    void Update()
    {
        if (!canShoot) return;

        rechargeTir += Time.deltaTime;

        if (rechargeTir >= cadenceTir)
        {
            rechargeTir = 0f;

            if (Random.value < chanceTir)
            {
                Vector3 spawnPos = canon != null ? canon.position : transform.position;

                GameObject tir = Instantiate(blaster, spawnPos, Quaternion.identity);

                tir.transform.forward = Vector3.back;
            }
        }
    }
}
