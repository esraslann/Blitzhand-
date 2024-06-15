using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    public GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.transform.tag == "Poro")
        {

            Debug.Log(collision.transform.name);
            Transform pickPoro = collision.gameObject.transform;
            pickPoro.SetParent(gameObject.transform);
            pickPoro.transform.position = Vector3.zero;
            pickPoro.transform.localPosition = new Vector3(0.37f, 2, 0);
            pickPoro.transform.localScale = new Vector3(0.37f, 0.37f, 0.37f);
            pickPoro.GetComponent<CircleCollider2D>().enabled = false;
            Rigidbody2D poroRigid = pickPoro.GetComponent<Rigidbody2D>();
            poroRigid.gravityScale = 0;
            poroRigid.constraints = RigidbodyConstraints2D.FreezeRotation;
            poroRigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            StartCoroutine(DestroyPoro(pickPoro));
        }
    }


    private IEnumerator DestroyPoro(Transform poro)
    {
        gameManager.IncreaseScore();
        yield return new WaitForSeconds(.5f);
        Destroy(poro.gameObject);
    }
}
