using RimWorld;
using System.Collections.Generic;
using Verse;

namespace VT_Personae
{
    public class PersonaGeneExtensions : DefModExtension
    {
        public bool genderNone = false;

        public bool corpseIsNotDisturbing = false;
        public bool corpseIsImperishable = false;
        public bool corpseIsInedible = false;

        public bool canBeStunnedByEMP = false;
        public bool canFallIll = true;
        public bool canRunWild = true;
        public bool canFeelPain = true;
        public bool canFeelInspired = true;
        public bool seeInDarkness = false;
        public bool incapableOfLove = false;
        public bool disableBreathVapors = false;
        public bool disregardsPawnBeauty = false;

        public bool hasIdeology = true;

        public bool revenantTargetable = true;
        public bool metalhorrorTargetable = true;

        public bool requiredOnGeneration = false;

        public List<ThoughtDef> blackListedThoughts = new List<ThoughtDef>();
        public List<ThoughtDefReplacer> replacedThoughts;

        public List<HediffDef> blackListedHediffs = new List<HediffDef>();
        public List<JobDef> blackListedJobs = new List<JobDef>();
        public List<ThingDef> whiteListedIngestible = new List<ThingDef>();

        public class ThoughtDefReplacer
        {
            public ThoughtDef original;
            public ThoughtDef replacer;
        }
    }
    public class PersonaItemExtensions : DefModExtension
    {
        public bool isPersonaIngestible = false;
        public bool isIngestibleByAll = false;
    }

    internal class Extensions
    {
        public class PersonaeGeneDef : GeneDef
        {
            public bool requiredOnGeneration = true;
        }

        [DefOf]
        public static class RR_DefOf
        {
            static RR_DefOf()
            {
                DefOfHelper.EnsureInitializedInCtor(typeof(RR_DefOf));
            }
            public static TraitDef Automatonophobia;
            public static TraitDef Anthropophobia;
            public static ThoughtDef AutomatonophobiaVsSynth;
            public static ThoughtDef AnthropophobiaVsHuman;
            public static ThoughtDef RR_BiologicalPawns_Veneration_Died;
            public static ThoughtDef RR_MechanicalPawns_Veneration_Died;

            public static GeneDef RRB_Quasi_Sentience;
            public static GeneDef RRB_Full_Sentience;
            public static GeneDef RRB_EMPResistant_Total;
            public static GeneDef RRB_NoLove;
            public static GeneDef RRB_NoPain;
            public static GeneDef RRB_NoEmotions;
            public static GeneDef RRB_NoOil;
            public static GeneDef RRB_NoOutdoors;
            public static GeneDef RRB_ColdComputation;
            [MayRequireAnomaly]
            public static GeneDef RRB_AnomalyImmune;

            public static FleshTypeDef VexedMechanical;

            public static JobDef RR_RepairPersonae;

            public static HediffDef RRB_PersonaHeatstroke;
            public static HediffDef RRB_PersonaHypothermia;

            public static StatDef TendSpeed_Synth;
            public static StatDef PersonaEnergyLossPerHP;

            public static EffecterDef RepairingSynthetic;

            public static FleckDef RR_PersonaFleckCharging;
            public static FleckDef RR_PersonaFleckRepair;

            public static SoundDef ReactorCharge_Sustained;

            [MayRequireIdeology]
            public static HistoryEventDef RR_MechanicalPawnDied;
            [MayRequireIdeology]
            public static HistoryEventDef RR_BiologicalPawnDied;
        }
    }
    public static class FetchExtensions
    {
        public static PersonaGeneExtensions GetModExt(this Gene gene)
        {
            return gene.def.GetModExtension<PersonaGeneExtensions>();
        }
    }
}
