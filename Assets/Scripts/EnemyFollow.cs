using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask PlayerMask;
    private PlayerMovement playerMovement;
    private bool playerInRange;
    private Rigidbody2D _rb;
    private Transform target;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (playerInRange)
        {
            Vector2 dir = (target.position - transform.position).normalized;
            _rb.linearVelocity = dir * speed;
        }
        else
        {
            _rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMaskUtil.ContainsLayer(PlayerMask, other.gameObject))
        {
            Debug.Log("FindPlayer");
            playerInRange = true;
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (LayerMaskUtil.ContainsLayer(PlayerMask, other.gameObject))
        {
            playerInRange = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (LayerMaskUtil.ContainsLayer(PlayerMask, other.gameObject))
        {
            playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            playerMovement.Death();
        }
    }
}

public static class LayerMaskUtil
{
    public static bool ContainsLayer(LayerMask mask, GameObject gameObject) => (mask.value & 1 << gameObject.layer) > 0;
}