using UnityEngine;


public class Transparency : MonoBehaviour
{
    SpriteRenderer m_Renderer;
    PolygonCollider2D polygonCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        //Grabs the Tilemap Component
        m_Renderer = GetComponentInParent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player has entered the trigger");
        BoxCollider2D boxCollider2D = other.gameObject.GetComponent<BoxCollider2D>();
        //Turns object invisible when the player enters its collider space
        if (boxCollider2D !=null&& boxCollider2D.IsTouching(polygonCollider2D))
        {
            m_Renderer.color = new Color(1f, 1f, 1f, 0.4f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player has exited the trigger");
        BoxCollider2D boxCollider2D = other.gameObject.GetComponent<BoxCollider2D>();
        //Turns object visible when player enters its collider space
        if (boxCollider2D != null && !boxCollider2D.IsTouching(polygonCollider2D))
        {
            m_Renderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}