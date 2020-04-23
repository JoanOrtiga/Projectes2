using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    public Animator animator;
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            StartCoroutine(AnimationFade(0.75f));
    }



    private IEnumerator AnimationFade(float animationLength)
    {
        animator.SetBool("Fading", true);

        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        if (player.inputX < 0.1f)
        {
            player.GetComponent<Rigidbody2D>().position -= new Vector2(2.5f, 0);
        }
        else if(player.inputX > -0.1f)
        {
            player.GetComponent<Rigidbody2D>().position += new Vector2(2.5f, 0);
        }

        player.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(animationLength - 0.1f);
        player.GetComponent<PlayerController>().enabled = true;
        yield return new WaitForSeconds(0.1f);

        animator.SetBool("Fading", false);
    }
}
