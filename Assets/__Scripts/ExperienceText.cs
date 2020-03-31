using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceText : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Text text;

    [SerializeField]
    private float LifeSpan;

  
    void Start()
    {
        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public IEnumerator FadeOut()
    {
        float startAlpha=text.color.a;

        float rate = 1.0f / LifeSpan;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Color tmp = text.color;
            tmp.a = Mathf.Lerp(startAlpha, 0, progress);
            text.color = tmp;
            progress += rate * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
