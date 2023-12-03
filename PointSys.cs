using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSys : MonoBehaviour
{
    [SerializeField] private AudioSource collect;
    [SerializeField] private AudioSource ded;
    public Text score;
    public float point;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spider"))
        {
            MinusPoints(5f);
            ded.Play();
        }

        if (other.gameObject.CompareTag("Bat"))
        {
            MinusPoints(15f);
            ded.Play();
        }
       
        if (other.gameObject.CompareTag("Candy"))
        {
            AddPoints(5f);
            collect.Play();
        }
    }

   
    public void AddPoints(float pointsToAdd)
    {
        point += pointsToAdd;
        UpdateScoreText();
    }

    public void MinusPoints(float pointsToMinus)
    {
        point -= pointsToMinus;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        score.text = "Score: " + point.ToString();
    }
}
