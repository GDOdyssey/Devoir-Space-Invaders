using UnityEngine;
using UnityEngine.InputSystem;

public class MouvementVaisseau : MonoBehaviour
{
    [Header("Deplacement settings")]
    public float speed = 8f;
    public float minX = -7f;
    public float maxX = 4.5f;
    public float minZ = -1f;
    public float maxZ = 1.5f;

    [Header("Tir settings")]
    public GameObject blaster;
    public Transform canon;
    public float cadenceTir = 1f;

    private float rechargeTir = 0f;

    public bool canMoveAndShoot = true;

    void Update()
    {
        Deplacement();
        Tir();
    }

    void Deplacement()
    {
        if (!canMoveAndShoot) return;
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;

        pos.x += horizontalInput * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        float verticalInput = Input.GetAxis("Vertical");

        pos.z += verticalInput * speed * Time.deltaTime;
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }

    void Tir()
    {
        if (!canMoveAndShoot) return;
        rechargeTir -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && rechargeTir <= 0f)
        {
            Instantiate(blaster, canon.position, canon.rotation);
            rechargeTir = cadenceTir;
        }
    }
}
