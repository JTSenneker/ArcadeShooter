using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;


public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 5;

    Vector3 targetPosition;
    float barrelRollProgrssion = 0;

    private bool doABarrelRoll = false;

    Player player;
	// Use this for initialization
	void Start () {
        player = ReInput.players.GetPlayer(0);
	}
	
	// Update is called once per frame
	void Update () {
        float moveV = player.GetAxis("Horizontal");

        
        
        if (player.GetButtonDoublePressDown("Horizontal"))
        {
            targetPosition = transform.position + (transform.right * 5);
            barrelRollProgrssion = 0;
            doABarrelRoll = true;
        }
        if (player.GetNegativeButtonDoublePressDown("Horizontal"))
        {
            targetPosition = transform.position + (transform.right * -5);
            barrelRollProgrssion = 0;
            doABarrelRoll = true;
        }

        if (doABarrelRoll)
        {
            BarrelRoll(targetPosition);
        }else transform.position += transform.right * moveV * Time.deltaTime * speed;
    }

    void BarrelRoll(Vector3 targetPosition)
    {
        barrelRollProgrssion += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, targetPosition, barrelRollProgrssion * 5);
        if (Vector3.Distance(transform.position, targetPosition) < .05f)  doABarrelRoll = false;
        
    }
}
