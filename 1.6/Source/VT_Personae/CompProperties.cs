using RimWorld;

namespace VT_Personae
{
	public class CompProperties_AbilityToxpop : CompProperties_AbilityEffect
	{
		public CompProperties_AbilityToxpop()
		{
			compClass = typeof(ToxpopPersona.CompAbilityEffect_Toxpop);
		}

		public float toxRadius;
	}

	public class CompProperties_AbilityDeadlifepop : CompProperties_AbilityEffect
	{
		public CompProperties_AbilityDeadlifepop()
		{
			compClass = typeof(DeadlifePersona.CompAbilityEffect_Deadlifepop);
		}

		public float deadlifeRadius;
	}
}
