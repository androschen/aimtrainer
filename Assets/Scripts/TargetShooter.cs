using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;


class TargetShooter : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Text scoreText;
    [SerializeField] Text missText;
    [SerializeField] Text accuraccyText;
    public float score=0;
    public float miss=0;
    public float accuraccy=0;
    TimeSetting timesetting;

    private void Start()
    {
        score=0;
        miss=0;
        timesetting = GameObject.FindObjectOfType<TimeSetting>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!timesetting.gameOver){
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f));
                if(Physics.Raycast(ray, out RaycastHit hit))
                {
                    Target target = hit.collider.gameObject.GetComponent<Target>();
                    if(target!=null)
                    {
                        score++;
                        scoreText.text = score.ToString("0");
                        target.Hit();
                    }
                }
                else
                {
                    miss++;
                    missText.text = miss.ToString("0");
                }
            }
            else{
                StartCoroutine(DelayAction(2));
            }
            accuraccy = Mathf.Max(0f,((score/(score+miss))*100f));
            accuraccyText.text = accuraccy.ToString("0");
        }
    }

    IEnumerator DelayAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); 

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

