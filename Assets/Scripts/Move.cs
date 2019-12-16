using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{

    private Vector3 touchPosition;
    private Vector3 direction;
    private float moveSpeed = 10f;

    
    private Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            touchPosition.z = 0;

            direction = new Vector3((touchPosition.x - transform.position.x), transform.position.y);

            rb.velocity = new Vector2(direction.x, 0f) * moveSpeed;

            if (touch.phase == TouchPhase.Ended) {
                rb.velocity = Vector2.zero;
            }
            
        }
    }
}
