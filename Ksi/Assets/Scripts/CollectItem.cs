using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D cc;
    public float autoDestroy;
    public AudioClip somColeta;
    public int points;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();
        Destruct();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.CompareTag("SpaceShip"))
        {
            AudioSource.PlayClipAtPoint(somColeta, this.gameObject.transform.position);
            ScoreS1.instance.ScoreUpdate();
            sr.enabled = false;
            cc.enabled = false;
            Destroy(gameObject);
        }

        if (collider.gameObject.CompareTag("SpaceShipRed"))
        {
            AudioSource.PlayClipAtPoint(somColeta, this.gameObject.transform.position);
            ScoreS2.instance.ScoreUpdate();
            sr.enabled = false;
            cc.enabled = false;
            Destroy(gameObject);
        }
    }
    private void Destruct()
    {
        Destroy(gameObject, autoDestroy);
    }
}
