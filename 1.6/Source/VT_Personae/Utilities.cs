using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Verse;

namespace VT_Personae
{
	public static class Utilities
	{
        public static bool HumanVsPersonaConflict(Pawn one, Pawn two)
        {
            var bothHuman = one == two;
			var bothPersona = (one?.IsPersonaPawn() ?? false) && (two?.IsPersonaPawn() ?? false);
			return bothHuman && !bothPersona;
        }

        public static bool IsPersonaPawn(this Pawn pawn)
        {
            if (pawn == null)
            {
                Log.Error("IsPersonaPawn null check");
                return false;
            }
            if (pawn.genes == null)
            {
                return false;
            }
            if (pawn.genes.HasActiveGene(Extensions.RR_DefOf.RRB_Quasi_Sentience))
            {
                return true;
            }
            else pawn.genes.HasActiveGene(Extensions.RR_DefOf.RRB_Full_Sentience);
            {
                return true;
            }
        }

    public static void ForceGender(Gene gene)
		{
			try
			{
				if (gene?.pawn == null)
				{
					return;
				}
				PersonaGeneExtensions ext = gene.def.GetModExtension<PersonaGeneExtensions>();
				if (ext == null)
				{
					return;
				}
				if (ext.genderNone == true)
				{
					gene.pawn.gender = Gender.None;
					Pawn_StoryTracker story = gene.pawn.story;
					if (story?.bodyType == BodyTypeDefOf.Female)
					{
						gene.pawn.story.bodyType = BodyTypeDefOf.Male;
					}
				}
			}
			catch (Exception arg)
			{
				Log.Error($"Error: VT_Personae.ForceGender - {gene?.def?.defName.ToStringSafe()}: {arg}");
			}
		}

		public static class Hediffs
        {
			public static void TradeHediff(Pawn pawn)
			{
				if (pawn.IsPersonaPawn())
				{
					TradeHediff2(pawn, HediffDefOf.Hypothermia, Extensions.RR_DefOf.RRB_PersonaHypothermia);
					TradeHediff2(pawn, HediffDefOf.Heatstroke, Extensions.RR_DefOf.RRB_PersonaHeatstroke);
					return;
				}
				TradeHediff2(pawn, Extensions.RR_DefOf.RRB_PersonaHypothermia, HediffDefOf.Hypothermia);
				TradeHediff2(pawn, Extensions.RR_DefOf.RRB_PersonaHeatstroke, HediffDefOf.Heatstroke);
			}
			public static void TradeHediff2(Pawn pawn, HediffDef from, HediffDef to)
			{
				Hediff firstHediffOfDef = pawn.health.hediffSet.GetFirstHediffOfDef(from, false);
				if (firstHediffOfDef != null)
				{
					Hediff hediff = HediffMaker.MakeHediff(to, pawn, firstHediffOfDef.Part);
					hediff.Severity = firstHediffOfDef.Severity;
					pawn.health.RemoveHediff(firstHediffOfDef);
					pawn.health.AddHediff(hediff, null, null, null);
				}
			}
		}

		public static bool IsRemoveableGene(this GeneDef geneDef)
		{
			return !(geneDef is Extensions.PersonaeGeneDef g) || !g.requiredOnGeneration;
		}

		public static bool IsPersonaGene(this GeneDef geneDef)
		{
			return geneDef.HasModExtension<PersonaGeneExtensions>();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsHumanOfColony(this Pawn pawn)
        {
            if (pawn == null)
            {
                Log.Error("Null check failed -> IsHumanOfColony");
                return false;
            }
            if (pawn.IsPersonaPawn())
            {
                return false;
            }
            if (!cachedPawn.TryGetValue(pawn, out bool result))
            {
                if (!pawn.IsColonist || pawn.IsSlave || pawn.IsPrisoner)
                {
                    return false;
                }
                result = cachedPawn[pawn] = !pawn.IsPersonaPawn();
            }
            return result;
        }

        public static int GetHumansInFactionCount(Faction faction)
        {
            if (faction == null)
            {
                return 0;
            }
            int num = 0;
            using (List<Pawn>.Enumerator enumerator = PawnsFinder.AllMaps_SpawnedPawnsInFaction(faction).GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.IsHumanOfColony())
                    {
                        num++;
                    }
                }
            }
            return num;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPersonaOfColony(this Pawn pawn)
        {
            if (pawn == null)
            {
                Log.Error("Null check failed -> IsPersonaOfColony");
                return false;
            }
            if (!pawn.IsPersonaPawn())
            {
                return false;
            }
            if (!cachedPawn.TryGetValue(pawn, out bool result))
            {
                if (!pawn.IsColonist || pawn.IsSlave || pawn.IsPrisoner)
                {
                    return false;
                }
                result = cachedPawn[pawn] = pawn.IsPersonaPawn();
            }
            return result;
        }

        public static int GetPersonaeInFactionCount(Faction faction)
        {
            if (faction == null)
            {
                return 0;
            }
            int num = 0;
            using (List<Pawn>.Enumerator enumerator = PawnsFinder.AllMaps_SpawnedPawnsInFaction(faction).GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.IsPersonaOfColony())
                    {
                        num++;
                    }
                }
            }
            return num;
        }

        public static Dictionary<Pawn_GeneTracker, bool> pawnXenotype = new Dictionary<Pawn_GeneTracker, bool>();
		public static HashSet<GeneDef> personaGene = new HashSet<GeneDef>();
        public static Dictionary<Pawn, bool> cachedPawn = new Dictionary<Pawn, bool>();
    }
}
