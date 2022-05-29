using Scoring;
using TMPro;
using UnityEngine;

namespace _Game.Scripts.UI.HUD
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text textBox;
        
        public void SetScore(Score score)
        {
            textBox.text = $"{score.PlayerScore} : {score.OpponentScore}";
        }
    }
}