using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    public GameObject indicator;
    public GameObject player;

    

    Renderer rd;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(rd.isVisible == false)
        {
            if(indicator.activeSelf == false)
            {
                indicator.SetActive(true);
            }

            Vector2 direction = player.transform.position - transform.position;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

            if(hit.collider != null)
            {
                indicator.transform.position = hit.point;
            }
            else
            {
                if(indicator.activeSelf == true)
                {
                    indicator.SetActive(false);
                }
            }

        }

    }
}
