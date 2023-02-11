using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] AsteroidSprites;
    public float AsteroidSize = 1.0f;
    public float MinSize = 0.5f;
    public float MaxSize = 2.0f;
    public float AsteroidSpeed = 0.0f;
    public float MaxLifetime = 25.0f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        spriteRenderer.sprite = AsteroidSprites[Random.Range(0, AsteroidSprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360f);
        this.transform.localScale = Vector3.one * this.AsteroidSize;

        rigidbody.mass = this.AsteroidSize;
    }

    public void setTrajectory(Vector2 direction)
    {
        rigidbody.AddForce(direction * this.AsteroidSpeed);
        Destroy(this.gameObject, this.MaxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy Asteroid when it is hit by a bullet
        if (collision.gameObject.tag == "Bullet")
        {

            //Split Asteroid if it is a large one 
            //The asteroid is still destroyed if split
            //Two smaller ones are created at the same time
            if(this.AsteroidSize/2f >= this.MinSize)
            {
                SplitAsteroid();
            }

            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            Destroy(this.gameObject);
        }
    }

    //
    private void SplitAsteroid()
    {
        //offset the smaller asteroids from the larger one, makes it look smoother
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.75f;

        Asteroid firstHalf = Instantiate(this, position, this.transform.rotation);
        firstHalf.AsteroidSize = this.AsteroidSize / 2f;
        firstHalf.setTrajectory(Random.insideUnitCircle.normalized * this.AsteroidSpeed);

        Asteroid secondHalf = Instantiate(this, position, this.transform.rotation);
        secondHalf.AsteroidSize = this.AsteroidSize / 2f;
        secondHalf.setTrajectory(Random.insideUnitCircle.normalized * this.AsteroidSpeed);
    }

}
