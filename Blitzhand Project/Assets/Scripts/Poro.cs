using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Poro : MonoBehaviour
{
    public GameObject gm;
    public void Start()
    {
        gm  = GameObject.Find("GameManager");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Deep")
        {
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
            StartCoroutine(DyingPoro());
        }
    }

    IEnumerator DyingPoro()
    {
        gm.GetComponent<GameManager>().DecreaseHealthPoint();
        yield return new WaitForSeconds(.3f);
        Destroy(this.gameObject);
    }
}
