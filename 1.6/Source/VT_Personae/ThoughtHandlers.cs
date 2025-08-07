using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace VT_Personae
{
    internal class ThoughtHandlers
    {

        public static ThoughtDef ThoughtDefReplacer(Pawn ___pawn, ThoughtDef thought)
        {
            if ((___pawn?.genes) == null)
            {
                return thought;
            }
            foreach (Gene gene in ___pawn.genes.GenesListForReading)
            {
                GeneDef def = gene.def;
                IEnumerable<PersonaGeneExtensions> list;
                if (def == null)
                {
                    list = null;
                }
                else
                {
                    List<DefModExtension> modExtensions = def.modExtensions;
                    list = (modExtensions?.OfType<PersonaGeneExtensions>());
                }
                foreach (PersonaGeneExtensions patch in (list ?? Enumerable.Empty<PersonaGeneExtensions>()))
                {
                    if (patch.replacedThoughts != null)
                    {
                        foreach (PersonaGeneExtensions.ThoughtDefReplacer thoughtReplacementEntry in patch.replacedThoughts)
                        {
                            if (thoughtReplacementEntry.original == thought)
                            {
                                return thoughtReplacementEntry.replacer;
                            }
                        }
                    }
                }
            }
            return thought;
        }
        public static bool ThoughtBlacklister(Pawn ___pawn, ThoughtDef thought)
        {
            if ((___pawn?.genes) == null)
            {
                return true;
            }
            foreach (Gene gene in ___pawn.genes.GenesListForReading)
            {
                GeneDef def = gene.def;
                IEnumerable<PersonaGeneExtensions> list;
                if (def == null)
                {
                    list = null;
                }
                else
                {
                    List<DefModExtension> modExtensions = def.modExtensions;
                    list = (modExtensions?.OfType<PersonaGeneExtensions>());
                }
                foreach (PersonaGeneExtensions ext in list ?? Enumerable.Empty<PersonaGeneExtensions>())
                {
                    List<ThoughtDef> blockedThoughtDefs = ext.blackListedThoughts;
                    if (blockedThoughtDefs != null && blockedThoughtDefs.Contains(thought))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
