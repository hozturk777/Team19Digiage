using UnityEngine;
using UnityEngine.Tilemaps;


public class Transparency : MonoBehaviour
{
    Tilemap m_Renderer;
    public PolygonCollider2D polygonCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        //Grabs the Tilemap Component
        m_Renderer = GetComponentInParent<Tilemap>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player has entered the trigger");
        GameObject obj=other.gameObject;
        //Turns object invisible when the player enters its collider space
        if (obj!=null&&(obj.tag == "Player"||obj.tag=="Enemy"))
        {
            if(obj.GetComponent<CircleCollider2D>().IsTouching(polygonCollider2D))
                m_Renderer.color = new Color(1f, 1f, 1f, 0.4f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player has exited the trigger");
        GameObject obj=other.gameObject;
        //Turns object visible when player enters its collider space
        if (obj!=null&&(obj.tag == "Player"||obj.tag=="Enemy"))
        {
            if(!obj.GetComponent<CircleCollider2D>().IsTouching(polygonCollider2D))
                m_Renderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}