using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


class TimeSetting : MonoBehaviour
{
    [SerializeField] Text TextTimer;
    public float time = 100;
    public bool gameOver = false;
    public GameObject gameOverCanvas;

    void setText(){
        int minute = Mathf.FloorToInt(time/60);
        int second = Mathf.FloorToInt(time%60);
        TextTimer.text = minute.ToString("00")+":"+second.ToString("00");
    }


    public float s;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(gameOver) return;

        setText();

        s+=Time.deltaTime;
        if(s>=1){
            time--;
            s=0;
        }
        
        if(!gameOver && time<=0){
            gameOver=true;
            gameOverCanvas.SetActive(true);
        }

    }
}

