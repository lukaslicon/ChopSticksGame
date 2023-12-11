

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    //looked this up. Found that using TMPro and using a textmeshprougui i could also update score this way.
    public TextMeshProUGUI pointsText;

    public GameObject particleEffectPrefab;
    public int points = 2;
    public GameOverManager GameManager;
    private void Start()
    {
        UpdatePointsText();
    }
    public void UpdatePoints(int amount)
    {
        points += amount;
        UpdatePointsText();
        if (points <= 0)
        {
            GameManager.isGameOver = true;
        }

    }
    private void UpdatePointsText()
    {
        if (pointsText != null)
        {
            pointsText.text = "Lives: " + points.ToString();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GamePiece"))
        {
            
            PlayParticleEffect(other.transform.position); // Pass the other object's position
            other.gameObject.SetActive(false);
            UpdatePoints(-1);
            Debug.Log("Player Gained Point");
        }
    }

    void PlayParticleEffect(Vector3 position) // Receive position as a parameter
    {
        if (particleEffectPrefab != null)
        {
            GameObject particle = Instantiate(particleEffectPrefab, position, Quaternion.identity);
            Destroy(particle, 1f);
        }
    }
}