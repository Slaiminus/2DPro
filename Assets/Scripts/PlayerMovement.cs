using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private InputControler movementInputs;
    [SerializeField] private string bulletTag;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Movement(Vector2 movement)
    {
        Vector3 direction = (new Vector3(movement.x, movement.y, 0) * speed);
        _rb.linearVelocity = direction;
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Player died");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == bulletTag)
        {
            Death();
        }
    }
}
