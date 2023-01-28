using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 500.0f;
    public float BulletLifeTime = 10.0f;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        rigidbody.AddForce(direction * BulletSpeed);

        Destroy(this.gameObject, this.BulletLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

}
