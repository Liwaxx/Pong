using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    //rigibody bola
    private Rigidbody2D rigidBody2D;

    //besarnya gaya awal mendorong bola
    public float xInitialForce;
    public float yInitialForce;

    //titik asal lintasa bola saat ini
    private Vector2 trajectoryOrigin;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        //mulai game
        RestartGame();

        trajectoryOrigin = transform.position;
    }

    void ResetBall()
    {
        //rest posisi 
        transform.position = Vector2.zero;

        //reset kecepatan
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        //tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        //tentukan nilai acak antai 0 (inklusif) dan 2(ekslusif)
        float randomDirection = Random.Range(0, 2);

        //jika nilai dibawah 1 akan bergerak ke kiri jika tidak ke kanan
        if (randomDirection < 1.0f)
        {
            //gunakan gaya untuk menggerakkna bola ini
            rigidBody2D.AddRelativeForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddRelativeForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }
    void RestartGame()
    {
        //kembalikan bola ke poisi semula
        ResetBall();

        //setelah 2 detik , berikan gaya ke bola
        Invoke("PushBall", 2);
    }

    //ketika bola beranjak dari sebuah tumbukan, titik tumbukan tersebut
    private void OnCollisionEnter2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    //Untuk mengakses informasi titika asal lintasan
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}

