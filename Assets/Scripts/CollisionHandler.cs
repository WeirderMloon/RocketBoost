using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
    [Header("Level Settings")]
    [SerializeField] float levelLoadDelay = 2f;

    [Header("Audio & VFX")]
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isControllable = true;
    bool isCollidable = true;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void Update() 
    {
        RespondToDebugKeys();        
    }

    void RespondToDebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            isCollidable = !isCollidable;
            Debug.Log("Collisions toggled: " + isCollidable);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (!isControllable || !isCollidable) 
            return;

        switch (other.gameObject.tag)
        {
            case "Friendly":
                // Safe objects (Ground, platforms, walls, etc.)
                break;

            case "Finish":
                StartSuccessSequence();
                break;

            case "Hazard":
                // Dangerous objects (spikes, enemies, lava, etc.)
                StartCrashSequence();
                break;

            default:
                // Optional: You can make unknown objects safe or deadly
                // StartCrashSequence();     // ← Commented out so you don't die on ground
                break;
        }
    }

    void StartSuccessSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successSFX);
        successParticles.Play();
        
        GetComponent<Movement>().enabled = false;
        
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        crashParticles.Play();
        
        GetComponent<Movement>().enabled = false;
        
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}