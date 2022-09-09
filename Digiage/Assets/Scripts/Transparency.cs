using UnityEngine;
using UnityEngine.Tilemaps;


public class Transparency : MonoBehaviour
{
    Tilemap m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        //Grabs the Tilemap Component
        m_Renderer = GetComponentInParent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player has entered the trigger");

        //Turns object invisible when the player enters its collider space
        if (other.gameObject.tag == "Player")
        {
            m_Renderer.color = new Color(1f, 1f, 1f, 0.4f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player has exited the trigger");

        //Turns object visible when player enters its collider space
        if (other.gameObject.tag == "Player")
        {
            m_Renderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}