using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float h;
    float v;
    Rigidbody2D rigid;
    void Start()
    {
        
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        rigid.linearVelocity = new Vector2(h, v);
    }
}
