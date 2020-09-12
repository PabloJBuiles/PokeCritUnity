using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] private static Arbitro _arbitro;

    private static Text tSkill1;
    private static Text tSkill2, tSkill3;

    private static Text vidaCritEne,vidaCritAliado;

    private static Text NombreCritAli, NombreCritEne;
    private static Text cantidadCrittersEne, cantidadCrittersAli;
    private static Image elementoAli, elementoEne;
    private static Image imgCritAli, imgCritEne;

    private static Image[] botonesImages = new Image[4];
    private static Button[] botonesSkills = new Button[4];

    private static Sprite[] sElementos = new Sprite[6];
    [SerializeField] private  Sprite[] elementos;

    [SerializeField] private Color colorBase, colorDesactivado;

    private static GameObject suppSkillGameObject;
    private static Text SuppSkillText;
    
    private static Color sColorDesactivado, sColorBase;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    void Start()
    {
        _arbitro = GetComponent<Arbitro>();
        tSkill1 = GameObject.Find("Text_Skill1").GetComponent<Text>();
        tSkill2 = GameObject.Find("Text_Skill2").GetComponent<Text>();
        tSkill3 = GameObject.Find("Text_Skill3").GetComponent<Text>();
     
        vidaCritEne = GameObject.Find("VidaCritEne").GetComponent<Text>();
        vidaCritAliado = GameObject.Find("VidaCritAli").GetComponent<Text>();
        NombreCritAli = GameObject.Find("VidaCritJugadorName").GetComponent<Text>();
        NombreCritEne = GameObject.Find("VidaCritEneName").GetComponent<Text>();
        cantidadCrittersAli = GameObject.Find("CritersAli").GetComponent<Text>();
        cantidadCrittersEne = GameObject.Find("CritersEne").GetComponent<Text>();
        elementoAli = GameObject.Find("ElementoAli").GetComponent<Image>();
        elementoEne = GameObject.Find("ElementoEne").GetComponent<Image>();
        imgCritEne = GameObject.Find("EneCritterImage").GetComponent<Image>();
        imgCritAli = GameObject.Find("AliCritterImage").GetComponent<Image>();
        for (var i = 0; i < botonesImages.Length; i++)
        {
            botonesImages[i] = GameObject.Find("B_Skill" + i).GetComponent<Image>();
            botonesSkills[i] = GameObject.Find("B_Skill" + i).GetComponent<Button>();
        }
        
        SuppSkillText = GameObject.Find("SuppSkill").GetComponent<Text>();
        suppSkillGameObject = GameObject.Find("ImageSuppSkill");
        
        
        sElementos = elementos;
        sColorBase = colorBase;
        sColorDesactivado = colorDesactivado;

        suppSkillGameObject.SetActive(false);
        
        
   
        ActivarDesactivarBotones();
        ActualizarTextosSkils();
        ActualizarVida();
        ActualizarNombres();
    }

    public static void MostrarSuppSkill()
    {
        suppSkillGameObject.SetActive(true);
        SuppSkillText.text = _arbitro.ultimaSuppSkillUtilizada;
    }
    
    public static void ActivarDesactivarBotones()
    {
        if (_arbitro.TurnoActual != Arbitro.turno.jugador)
        {
            for (var i = 0; i < botonesImages.Length; i++)
            {
                botonesImages[i].color = sColorDesactivado;
                botonesSkills[i].enabled = false;
            }
        }
        else
        {
            for (var i = 0; i < botonesImages.Length; i++)
            {
                botonesImages[i].color = sColorBase;
                botonesSkills[i].enabled = true;
            }
        }
    }

    public static void ActualizarVida()
    {
        vidaCritEne.text = _arbitro.enemigo.CrittersOwned[0].actualHP.ToString();
        vidaCritAliado.text = _arbitro.jugador.CrittersOwned[0].actualHP.ToString();
        ActivarDesactivarBotones();

    }

    public static void ActualizarNombres()
    {
        NombreCritEne.text = _arbitro.enemigo.CrittersOwned[0].CritName;
        NombreCritAli.text = _arbitro.jugador.CrittersOwned[0].CritName;
        elementoEne.sprite = sElementos[(int)_arbitro.enemigo.CrittersOwned[0].AfinityType];
        elementoAli.sprite = sElementos[(int)_arbitro.jugador.CrittersOwned[0].AfinityType];
        cantidadCrittersEne.text = _arbitro.enemigo.CrittersOwned.Count.ToString();
        cantidadCrittersAli.text = _arbitro.jugador.CrittersOwned.Count.ToString();
        imgCritEne.sprite = _arbitro.enemigo.CrittersOwned[0].MSprite;
        imgCritAli.sprite = _arbitro.jugador.CrittersOwned[0].MSprite;
        ActualizarTextosSkils();

    }

    private static void ActualizarTextosSkils()
    {
        tSkill1.text = _arbitro.jugador.CrittersOwned[0].Moveset1[0].name;
        tSkill2.text = _arbitro.jugador.CrittersOwned[0].Moveset1[1].name;
        tSkill3.text = _arbitro.jugador.CrittersOwned[0].Moveset1[2].name;
    }
    
}
