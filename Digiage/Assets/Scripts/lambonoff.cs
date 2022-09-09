using UnityEngine;

public class lambonoff : MonoBehaviour
{

    float nextTime = 0f;
    float waitTime = 2f;

    public float betweenTime;
    public GameObject light2D;
    
    
    // Update is called once per frame
    void Update()
    {
        float random = Random.Range(0, 10f);

        if (Time.time>nextTime)
        {
            nextTime = Time.time + betweenTime* random;
            light2D.SetActive(true);
            waitTime = Time.time + (betweenTime/2)* random;
        }
        else if(Time.time>waitTime)
        {
            light2D.SetActive(false);
        }
        
    }
}
