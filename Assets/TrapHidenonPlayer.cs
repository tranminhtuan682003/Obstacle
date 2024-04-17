using System.Collections;
using UnityEngine;

public class TrapHideNonPlayer : MonoBehaviour
{
    [SerializeField] private float timehide;
    [SerializeField] private float appear;
    private SpriteRenderer _renderer;
    private PolygonCollider2D _collider;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<PolygonCollider2D>();

        StartCoroutine(WaitHide());
    }
    IEnumerator WaitHide()
    {
        while (true)
        {
            _collider.enabled = true;
            _renderer.enabled = true;
            yield return new WaitForSeconds(appear);
            _collider.enabled = false;
            _renderer.enabled = false;
            yield return new WaitForSeconds(timehide);
        }
    }
}
