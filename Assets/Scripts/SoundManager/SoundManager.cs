using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;    
    public Sound[] BGM, SFX;                
    public AudioSource BGMSource, SFXSource;


    void OnEnable()
    {
        // 씬 로드 이벤트에 함수 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // 씬 로드 이벤트에서 함수 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SFXSource.Stop();
        PlayMusic(scene.name);
    }

    /*    private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Title_Temp")
            {
                if (GamePaused)
                {
                    if (!IsCardOpen)
                        GameManager.instance.Resume();

                    ESC_UI.SetActive(false);
                    GamePaused = false;
                }
                else
                {
                    GameManager.instance.Stop();
                    ESC_UI.SetActive(true);
                    GamePaused = true;
                }

            }
        }*/
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(BGM, x => x.name == name);

        if (s == null)
        {
            Debug.Log("BGM not found");
        }

        else
        {
            BGMSource.clip = s.clip;
            BGMSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFX, x => x.name == name);

        if (s == null)
        {
            Debug.Log("BGM not found");
        }

        else
        {
            SFXSource.PlayOneShot(s.clip);
        }
    }

    //ī�� ���� ui �㶧 _pitch�� 0.8��, ī�� ���� �Ŀ��� �ٽ� 0.1f�� �������ֽø� �˴ϴ� - ����
    public void BGMVolume(float volume)
    {
        BGMSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        SFXSource.volume = volume;
    }

/*    public void PauseGame()
    {
        GameObject pauseButton = GameObject.Find("PauseButtonRawImage");

        if (GamePaused)
        {
            if (!IsCardOpen)
                GameManager.instance.Resume();

            ESC_UI.SetActive(false);
            GamePaused = false;

            if (pauseButton != null)
            {
                pauseButton.GetComponent<RawImage>().texture = pauseTexture;
            }
        } 
        else 
        {
            GameManager.instance.Stop();
            ESC_UI.SetActive(true);

            if (pauseButton != null)
            {
                pauseButton.GetComponent<RawImage>().texture = resumeTexture;
            }

            GamePaused = true;
        }
    }*/
}
