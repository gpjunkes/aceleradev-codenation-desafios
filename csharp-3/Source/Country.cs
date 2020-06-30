using Source;
using System;
using System.Linq;

namespace Codenation.Challenge
{
    public class Country
    {        
        public State[] Top10StatesByArea()
        {
            var allStates = GetAllStates();
            var top10StatesByArea = allStates.OrderByDescending(p => p.TotalArea)
                                             .Take(10)
                                             .Select(p => new State(p.Name, p.Acronym))
                                             .ToArray();

            return top10StatesByArea;
        }

        public StateWithTotalArea[] GetAllStates()
        {
            StateWithTotalArea[] allStates = new StateWithTotalArea[27];

            allStates[0] = new StateWithTotalArea("Acre", "AC", 164123.040);
            allStates[1] = new StateWithTotalArea("Alagoas", "AL", 27778.506);
            allStates[2] = new StateWithTotalArea("Amapá", "AP", 142828.521);
            allStates[3] = new StateWithTotalArea("Amazonas", "AM", 1559159.148);
            allStates[4] = new StateWithTotalArea("Bahia", "BA", 564733.177);
            allStates[5] = new StateWithTotalArea("Ceará", "CE", 148920.472);
            allStates[6] = new StateWithTotalArea("Distrito Federal", "DF", 5779.999);
            allStates[7] = new StateWithTotalArea("Espírito Santo", "ES", 46095.583);
            allStates[8] = new StateWithTotalArea("Goiás", "GO", 340111.783);
            allStates[9] = new StateWithTotalArea("Maranhão", "MA", 331937.450);
            allStates[10] = new StateWithTotalArea("Mato Grosso", "MT", 903366.192);
            allStates[11] = new StateWithTotalArea("Mato Grosso do Sul", "MS", 357145.532);
            allStates[12] = new StateWithTotalArea("Minas Gerais", "MG", 586522.122);
            allStates[13] = new StateWithTotalArea("Pará", "PA", 1247954.666);
            allStates[14] = new StateWithTotalArea("Paraíba", "PB", 56585.000);
            allStates[15] = new StateWithTotalArea("Paraná", "PR", 199307.922);
            allStates[16] = new StateWithTotalArea("Pernambuco", "PE", 98311.616);
            allStates[17] = new StateWithTotalArea("Piauí", "PI", 251577.738);
            allStates[18] = new StateWithTotalArea("Rio de Janeiro", "RJ", 43780.172);
            allStates[19] = new StateWithTotalArea("Rio Grande do Norte", "RN", 52811.047);
            allStates[20] = new StateWithTotalArea("Rio Grande do Sul", "RS", 281730.223);
            allStates[21] = new StateWithTotalArea("Rondônia", "RO", 237590.547);
            allStates[22] = new StateWithTotalArea("Roraima", "RR", 224300.506);
            allStates[23] = new StateWithTotalArea("Santa Catarina", "SC", 95736.165);
            allStates[24] = new StateWithTotalArea("São Paulo", "SP", 248222.362);
            allStates[25] = new StateWithTotalArea("Sergipe", "SE", 21915.116);
            allStates[26] = new StateWithTotalArea("Tocantins", "TO", 277720.520);

            return allStates;
        }
    }
}
