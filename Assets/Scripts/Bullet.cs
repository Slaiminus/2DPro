using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private string playerTag;
    private PlayerMovement playerMovement;
    private Rigidbody2D _rb;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
        _rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            playerMovement.Death();
        }
        Destroy(gameObject);
    }
}
