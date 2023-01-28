using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player Player;
    public int Lives = 3;
    public float RespawnTime = 2.5f; 

    public void PlayerDied()
    {
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
        this.Player.gameObject.SetActive(true);
    }

    public void GameOver()
    {

    }

}
