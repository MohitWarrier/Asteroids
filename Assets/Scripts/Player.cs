using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet BulletPrefab;

    public float ThrustSpeed = 1.0f;
    public float TurnSpeed = 1.0f;

    private bool thrusting;
    private float turnDirection;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1.0f;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1.0f;
        }
        else
        {
            turnDirection = 0.0f;
        }

        //Holding down key does not shoot multiple times
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }

    }

    private void FixedUpdate()
    {
        if(thrusting)
        {
            rigidbody.AddForce(this.transform.up * this.ThrustSpeed);
        }

        if(turnDirection != 0.0f)
        {
            rigidbody.AddTorque(turnDirection * TurnSpeed);
        }

    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.BulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(transform.up);
    }

}
