using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player Player;
    public ParticleSystem Explosion;
    public int Lives = 3;
    public float RespawnTime = 2.5f;
    public float RespawnInvincibilityTime = 3.0f;
    public int Score = 0;

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.Explosion.transform.position = asteroid.transform.position;
        this.Explosion.Play();

        this.Score += (int)(asteroid.AsteroidSize*100);
    }

    public void PlayerDied()
    {

        this.Explosion.transform.position = this.Player.transform.position;
        this.Explosion.Play();
        this.Lives--;

        if(this.Lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.RespawnTime);
        }
    }

    private void Respawn()
    {
        this.Player.transform.position = Vector3.zero;
        this.Player.gameObject.layer = LayerMask.NameToLayer("Invincibility");
        this.Player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), RespawnInvincibilityTime);
    }

    private void TurnOnCollisions()
    {
        this.Player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public void GameOver()
    {

    }

}
