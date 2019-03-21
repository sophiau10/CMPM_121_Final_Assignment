using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform Player;
    public float MoveSpeed = 4;
    public float MaxDist = 10;
    public float delay = 105;
    public float MinDist = .5f;
    public float MinMove = 0;

    public Text countText;
    public float count = 10;
    // Start is called before the first frame update
    void Start()
    {
        //SetCountText();
    }
    void SetCountText()
    {
        countText.text = "Health: " + count.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        delay++;
        if ((Vector3.Distance(transform.position, Player.position) <= MaxDist) && (Vector3.Distance(transform.position, Player.position) >= MinMove))
        {
            transform.Translate(transform.forward * MoveSpeed * Time.deltaTime);
        }
        /*if (Vector3.Distance(transform.position, Player.position) <= MinDist)
        {
            if (delay > 100)
            {
                count = count-1;
                SetCountText();
                delay = 0;
            }
        }
        if(count==0)
        {
            Player.position = new Vector3(471.26f, 144.076f, 410.06f);
        }*/
    }
}
