using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastryScript : MonoBehaviour
{
    [SerializeField] AudioClip baRing;
    [SerializeField] AudioClip missSnd;

    private void OnTriggerEnter2D(Collider2D collision) {
        print("triggered!!");
        if (collision.gameObject.tag.Equals("Player")) {
            AudioSource.PlayClipAtPoint(baRing, transform.position);
            GameManager.gm.incrementScore();
            print("Player caught it!");
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Boundary")) {
            AudioSource.PlayClipAtPoint(missSnd, transform.position);
            GameManager.gm.decreaseLives();
            Destroy(gameObject);
        }
    }
}
