using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    public float fullyReviveCircleScale;
    public float radius;
    public float timeToRevive;
    public float reviveTimeElapsed;
    public Player playerToRevive;
    private bool playerInRadius;
    [SerializeField] private GameObject healingEffects;
    [SerializeField] private GameObject progressCircle;

    private GameObject player1;
    private GameObject player2;
    // Start is called before the first frame update
    void Start()
    {

        player1 = InputManager.Instance.p1.gameObject;
        player2 = InputManager.Instance.p2.gameObject;
        healingEffects.SetActive(false);
        playerInRadius = false;
        healingEffects.SetActive(false);
        //Reset progress
        reviveTimeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Is the player balanced
        if (Vector3.Distance(player1.transform.position, player2.transform.position) <= radius)
        {
            playerInRadius = true;
        }
        else
        {
            playerInRadius = false;
            progressCircle.transform.localScale = 0.0001f * Vector2.one;
            reviveTimeElapsed = 0;
        }

        //Revive player
        if(playerInRadius)
        {
            reviveTimeElapsed += Time.deltaTime;
            //Scale up the progress Circle
            progressCircle.transform.localScale = Mathf.Lerp(0,fullyReviveCircleScale, reviveTimeElapsed / timeToRevive) * Vector2.one;
            healingEffects.SetActive(true);
            //If the player is in the trigger long enough
            if (reviveTimeElapsed >= timeToRevive)
            {
                playerToRevive.RevivePlayer();

                Destroy(this.gameObject);
            }
        }

     
    }

    public void SetParameters(Player playerToRevive)
    {
        this.playerToRevive = playerToRevive;
    }
}
