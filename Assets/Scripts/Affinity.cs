using System.Collections;
using System.Collections.Generic;

 public enum afinity { Dark, Ligth, Fire, Water, Wind, Earth };
    static class Affinity
    {

        public static double CalculateAffinity(afinity afinityAttack, afinity afinityTerget)
        {
            double dmg = 0;
            //Tabla de valores de la afinidad
            switch (afinityAttack)
            {
                case afinity.Dark:
                    switch (afinityTerget)
                    {
                        case afinity.Dark:
                            dmg = 0.5;
                            break;
                        case afinity.Ligth:
                            dmg = 2;
                            break;
                        case afinity.Fire:
                            dmg = 1;
                            break;
                        case afinity.Water:
                            dmg = 1;
                            break;
                        case afinity.Wind:
                            dmg = 1;
                            break;
                        case afinity.Earth:
                            dmg = 1;
                            break;
                        default:
                            dmg = 1;
                            break;
                    }
                    break;
                case afinity.Ligth:
                    switch (afinityTerget)
                    {
                        case afinity.Dark:
                            dmg = 2;
                            break;
                        case afinity.Ligth:
                            dmg = 0.5;
                            break;
                        case afinity.Fire:
                            dmg = 1;
                            break;
                        case afinity.Water:
                            dmg = 1;
                            break;
                        case afinity.Wind:
                            dmg = 1;
                            break;
                        case afinity.Earth:
                            dmg = 1;
                            break;
                        default:
                            dmg = 1;
                            break;
                    }
                    break;
                case afinity.Fire:
                    switch (afinityTerget)
                    {
                        case afinity.Dark:
                            dmg = 1;
                            break;
                        case afinity.Ligth:
                            dmg = 1;
                            break;
                        case afinity.Fire:
                            dmg = 0.5;
                            break;
                        case afinity.Water:
                            dmg = 2;
                            break;
                        case afinity.Wind:
                            dmg = 1;
                            break;
                        case afinity.Earth:
                            dmg = 0;
                            break;
                        default:
                            dmg = 1;
                            break;
                    }
                    break;
                case afinity.Water:
                    switch (afinityTerget)
                    {
                        case afinity.Dark:
                            dmg = 1;
                            break;
                        case afinity.Ligth:
                            dmg = 1;
                            break;
                        case afinity.Fire:
                            dmg = 0.5;
                            break;
                        case afinity.Water:
                            dmg = 0.5;
                            break;
                        case afinity.Wind:
                            dmg = 2;
                            break;
                        case afinity.Earth:
                            dmg = 1;
                            break;
                        default:
                            dmg = 1;
                            break;
                    }
                    break;
                case afinity.Wind:
                    switch (afinityTerget)
                    {
                        case afinity.Dark:
                            dmg = 1;
                            break;
                        case afinity.Ligth:
                            dmg = 1;
                            break;
                        case afinity.Fire:
                            dmg = 1;
                            break;
                        case afinity.Water:
                            dmg = 0.5;
                            break;
                        case afinity.Wind:
                            dmg = 0.5;
                            break;
                        case afinity.Earth:
                            dmg = 0.5;
                            break;
                        default:
                            dmg = 1;
                            break;
                    }
                    break;
                case afinity.Earth:
                    switch (afinityTerget)
                    {
                        case afinity.Dark:
                            dmg = 1;
                            break;
                        case afinity.Ligth:
                            dmg = 1;
                            break;
                        case afinity.Fire:
                            dmg = 1;
                            break;
                        case afinity.Water:
                            dmg = 1;
                            break;
                        case afinity.Wind:
                            dmg = 2;
                            break;
                        case afinity.Earth:
                            dmg = 0.5;
                            break;
                        default:
                            dmg = 1;
                            break;
                    }
                    break;
                default:
                    dmg = 1;
                    break;
            }

            return dmg;
        }



    }