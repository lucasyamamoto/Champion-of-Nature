using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObjects/Score")]
public class Score : ScriptableObject
{
    [SerializeField] private double defaultScore;
    [SerializeField] private double defaultGain;
    [SerializeField] private double score;
    [SerializeField] private double gain;
    [SerializeField] private float penalityPerHit;

    public double CurrentScore { get => score; }
    public double Gain { get => gain; }

    public void AddScore()
    {
        score += gain;
    }

    public void DecreaseGain()
    {
        gain -= penalityPerHit;
    }

    public void Restart()
    {
        score = defaultScore;
        gain = defaultGain;
    }
}
