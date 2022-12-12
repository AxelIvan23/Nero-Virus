using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
	public AnimacionesUI animaciones;
	public GameObject panel;
	UnityEngine.Video.VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
       videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp) {
        //vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        videoPlayer.Pause();
        panel.SetActive(true);
        animaciones.animateStart();
    }
}
