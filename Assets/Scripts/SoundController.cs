using UnityEngine;
using System.Collections;
using UnityEngine.UI; // library untuk UI
public class SoundController : MonoBehaviour {

    public AudioClip[] musik;
    AudioSource[] controllerMusik;

    // buat effect button
    public Sprite[] btnNormal;
    public Sprite[] btnPress;
    public Image[] btnRender;

    public Dropdown dropdownValue;

    int idxMusik = 0;
    // 0 = play
    // 1 = pause
    // 2 = stop

	// Use this for initialization
	void Start () {
        controllerMusik = new AudioSource[2];
        controllerMusik[0] = gameObject.AddComponent<AudioSource>();
        controllerMusik[1] = gameObject.AddComponent<AudioSource>();
        controllerMusik[0].clip = musik[0];
        controllerMusik[1].clip = musik[1];
        // audio backsound
        // controllerMusik.Play();
        // controllerMusik.loop = true;

        btnRender[2].sprite = btnPress[2]; // pada button stop, gambarnya diganti dengan gambar stop press / stop atif
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickPlay()
    {
        // supaya tidak numpuk ketika diplay bersamaan
        if(idxMusik == 0)
        {
            controllerMusik[1].Stop();
        }
        else if(idxMusik == 1)
        {
            controllerMusik[0].Stop();
        }

        if(!controllerMusik[idxMusik].isPlaying)
        controllerMusik[idxMusik].Play();

        btnRender[0].sprite = btnPress[0];
        btnRender[1].sprite = btnNormal[1];
        btnRender[2].sprite = btnNormal[2];
    }

    public void OnClickPause()
    {
        controllerMusik[idxMusik].Pause();

        btnRender[0].sprite = btnNormal[0];
        btnRender[1].sprite = btnPress[1];
        btnRender[2].sprite = btnNormal[2];
    }

    public void OnClickStop()
    {
        controllerMusik[idxMusik].Stop();

        btnRender[0].sprite = btnNormal[0];
        btnRender[1].sprite = btnNormal[1];
        btnRender[2].sprite = btnPress[2];
    }

    public void OnSelectPilihan()
    {

        Debug.Log("idx "+dropdownValue.value);

        idxMusik = dropdownValue.value;
    }
}
