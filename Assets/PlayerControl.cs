using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //control ke atas
    public KeyCode upButton = KeyCode.W;

    //control bawah
    public KeyCode downButton = KeyCode.S;

    //kecepatan gerak
    public float speed = 10.0f;

    //get rigibody
    private Rigidbody2D rigidbody2D;

    //batas atas dan bawah game scene (Batas bawah menggunakan (-)
    public float yBoundary = 9.0f;

    //skor pemain
    private int score;

    //titik tumbukan terakhir dengan bola, untuk menampilakan variabel-variabel fisika terkait tumbukan tersebut
    private ContactPoint2D lasContactPoint;

    //untuk mengankses informasi titik kontak dari kelas lain
    public ContactPoint2D LastContactPoint
    {
        get { return lasContactPoint; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get speed raket
        Vector2 velocity = rigidbody2D.velocity;

        //jika pemain mencet atas
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }
        //jika pemain mencet bawah
        else if (Input.GetKey(downButton)) {
            velocity.y = -speed;
        }
        //pemain tidak memecet apapun
        else
        {
            velocity.y = 0.0f;
        }

        //kembalikan nilai velocity ke rigibody
        rigidbody2D.velocity = velocity;

        //dapatkan posisi raket
        Vector3 position = transform.position;

        //jika melewati batas atas kembalikan ke posisi batas
        if(position.y > yBoundary)
        {
            position.y = yBoundary;
        }

        //jika melewati batas bawah (-yBoundary)
        else if(position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        //masukkan nilai posisi ke transform
        transform.position = position;
    }

    public void IncrementScore()
    {
        score++;
    }

    //mengembalikan nilai score
    public void ResetScore()
    {
        score = 0;
    }

    //mendapatkan nilai score
    public int Score
    {
        get { return score; }
    }

    //Ketika terjadi tubukan  dengan bola, rekam titik kontaknya
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lasContactPoint = collision.GetContact(0);
        }
    }
}
