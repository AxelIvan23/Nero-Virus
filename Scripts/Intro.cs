using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
	public AnimacionesUI animaciones;
	public GameObject panel;
	UnityEngine.Video.VideoPlayer videoPlayer;
	int band=0;
    // Start is called before the first frame update
    void Start()
    {
       videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        videoPlayer.loopPointReached += EndReached;
        if (Input.anyKey && band==0) {
        	band=1;
        	videoPlayer.Pause();
        	panel.SetActive(true);
        	animaciones.animateStart();
        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp) {
        //vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        if (band==0) {
        	Debug.Log("ENTRE!");
        	band=1;
	        videoPlayer.Pause();
	        panel.SetActive(true);
	        animaciones.animateStart();
    	}
    }
}
