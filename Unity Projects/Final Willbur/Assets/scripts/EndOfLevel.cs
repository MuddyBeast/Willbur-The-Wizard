using UnityEngine;
using System.Collections;

public class EndOfLevel : MonoBehaviour
{
    public SpriteRenderer background;
    public float amount = 0.01f;

    private bool isFading = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && !isFading)
        {

            Rigidbody2D body = other.transform.GetComponent<Rigidbody2D>();
            if (body.velocity.x>0f)
            { StartCoroutine(FadeOut()); }
            else { StartCoroutine(FadeIn()); }

            //background.color = new Color(1f, 1f, 1f, 0.5f);
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        isFading = true;

        Color color = background.color;
        while (color.a > 0f)
        {
            color.a -= amount;
            background.color = color;
            yield return new WaitForEndOfFrame();
        }

        isFading = false;
    }

    IEnumerator FadeIn()
    {
        isFading = true;

        Color color = background.color;
        while (color.a < 1f)
        {
            color.a += amount;
            background.color = color;
            yield return new WaitForEndOfFrame();
        }

        isFading = false;
    }
}