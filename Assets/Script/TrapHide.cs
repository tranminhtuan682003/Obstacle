using System.Collections;
using UnityEngine;

public class TrapHide : MonoBehaviour
{
    private PolygonCollider2D colider;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float timeHide;
    bool isActivate;

    private void Start()
    {
        colider = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    IEnumerator WaitHide()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.enabled = false;
        colider.enabled = false;
        yield return new WaitForSeconds(timeHide);
        spriteRenderer.enabled = true;
        colider.enabled = true;
        yield return new WaitForSeconds(timeHide);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player") && !isActivate)
        {
            StartCoroutine (WaitHide());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            isActivate = false;
        }
    }
}
