using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    [SerializeField]
    public float vida = 100;
    public float currentExperience;
    public float MaxExperience;
    public float currentLevel;

    private Gun gun;

    private void Awake()
    {
        gun = FindObjectOfType<Gun>(); // Obtiene la referencia al script Gun
    }

    private void Start()
    {
        ExperienceManager.instance.OnExperienceChange += HandleExperienceChange;
    }

    //private void OnEnable()
    //{
    //    ExperienceManager.instance.OnExperienceChange += HandleExperienceChange;
    //}

    private void OnDisable()
    {
        ExperienceManager.instance.OnExperienceChange -= HandleExperienceChange;

    }

    public Image barraDeVida;

    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);

        barraDeVida.fillAmount = vida / 100;

        if (vida <= 0)
        {
            RestartLvl();
        }
    }

    public void RestartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    private void HandleExperienceChange(int newExperience)
    {
        currentExperience += newExperience;
        if (currentExperience >= MaxExperience)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;

        if (gun != null)
        {
            gun._damage += 15f; // Incrementa el daño por cada nivel, ajusta según lo necesario
        }

        currentExperience = 0;
        MaxExperience += 100;

    }

}
