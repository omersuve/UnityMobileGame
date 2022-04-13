using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private RaycastHit2D hit;
    private BoxCollider2D boxCollider;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movement.y), Mathf.Abs(movement.y * Time.deltaTime), LayerMask.GetMask("Player", "Collider"));
        if (hit.collider == null)
        {
            transform.Translate(0, movement.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(movement.x, 0), Mathf.Abs(movement.x * Time.deltaTime), LayerMask.GetMask("Player", "Collider"));
        if (hit.collider == null)
        {
            transform.Translate(movement.x * Time.deltaTime, 0, 0);
        }
    }
}
