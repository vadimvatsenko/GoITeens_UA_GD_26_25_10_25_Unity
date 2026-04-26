using TMPro;
using UnityEngine;

namespace Sctipts.UI
{
    public class ScoreUI : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;
        private int _score;

        private void Awake()
        {
            _scoreText  = GetComponent<TextMeshProUGUI>();
            Debug.Log(_scoreText.text);
        }

        public void ChangeScore(int score)
        {
            _score += score;
            _scoreText.text = $"Score: {_score}";
        }
    }
}
