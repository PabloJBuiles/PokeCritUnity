using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FabricaDeSkills : MonoBehaviour
{
    
    [SerializeField] private CrittersFac _crittersFac;
    List<Skill> setSkill1 = new List<Skill>();
    List<Skill> setSkill2 = new List<Skill>();
    // Start is called before the first frame update
    private void Awake()
    {
        var ataqueRapido = new AtackSkill(2, afinity.Fire, "Ataque Rapido Rapido");
        var latigoZeta = new AtackSkill(3, afinity.Wind, "Latigo Zeta");
        var aguaToxica = new AtackSkill(5, afinity.Water, "Agua Toxica");
        var venenoAcido = new AtackSkill(7, afinity.Earth, "Ataque Rapido Rapidisimo"); //pues se crea con poder 1 porque tiene poder 0 :D // ahora si :)
        //AtkUp, DefUp, SpdDwn
        var atkUp = new SuppSkill("Incremento de ataque MAXIMO!!!", Skill.esSkill.AtkUp);
        var defUp = new SuppSkill("Super Endurecimiento", Skill.esSkill.DefUp);
        var spdUp = new SuppSkill("Suvida de velocidad", Skill.esSkill.SpdDwn);// directamente imposibles de crear con poder > 0
    


        setSkill1.Add(ataqueRapido);
        setSkill1.Add(defUp);
        setSkill1.Add(aguaToxica);
        setSkill2.Add(aguaToxica);//0
        setSkill2.Add(atkUp);//1
        setSkill2.Add(spdUp);//2
        
                
        for (var i = 0; i < _crittersFac.CrittersEnemy.Count; i++)
        {

            var random = Random.Range(1, 3);
            Debug.Log(random);
            _crittersFac.AgregarSkillSetEnemigo(random == 1 ? setSkill1 : setSkill2, i);
        }
        for (var i = 0; i < _crittersFac.CrittersPlayer.Count; i++)
        {
            var random = Random.Range(1, 3);
            Debug.Log(random);
            _crittersFac.AgregarSkillSetJugador(random == 1 ? setSkill1 : setSkill2, i);
        }
        _crittersFac.AgregarCritters();
    }



}   
