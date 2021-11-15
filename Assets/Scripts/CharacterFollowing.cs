using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollowing : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject startWall;
    private CollisorChecker collisorChecker;

    // Start is called before the first frame update
    void Start()
    {
        collisorChecker = startWall.GetComponent<CollisorChecker>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!collisorChecker.Collided)
        {
            if (player.transform.position.x > transform.position.x)
            {
                transform.Translate(new Vector3(player.transform.position.x - transform.position.x, 0f, 0f));
            }
        }
    }
}
