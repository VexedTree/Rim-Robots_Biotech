using RimWorld;
using Verse;

namespace VT_Personae
{
	public class PersonaColdComputation : StatPart
	{
		public override string ExplanationPart(StatRequest req)
		{
            if (req.Thing is Pawn pawn && pawn.genes.HasActiveGene(Extensions.RR_DefOf.RRB_ColdComputation))
            {
                float ambientTemperature = pawn.AmbientTemperature;
				if (ambientTemperature <= -45f)
				{
					return "RR_ColdComputationConciousnessBoost".Translate(ambientTemperature.ToStringTemperature("F1")) + ": x" + 1.55f.ToStringPercent();
				}
				if (ambientTemperature <= -30f)
                {
                    return "RR_ColdComputationConciousnessBoost".Translate(ambientTemperature.ToStringTemperature("F1")) + ": x" + 1.4f.ToStringPercent();
                }
                if (ambientTemperature <= -15f)
                {
                    return "RR_ColdComputationConciousnessBoost".Translate(ambientTemperature.ToStringTemperature("F1")) + ": x" + 1.25f.ToStringPercent();
                }
                if (ambientTemperature <= 0f)
                {
                    return "RR_ColdComputationConciousnessBoost".Translate(ambientTemperature.ToStringTemperature("F1")) + ": x" + 1.1f.ToStringPercent();
                }
            }
            return null;
		}

		public override void TransformValue(StatRequest req, ref float val)
		{
			if (req.Thing is Pawn pawn && pawn.genes.HasActiveGene(Extensions.RR_DefOf.RRB_ColdComputation))
			{
				float ambientTemperature = pawn.AmbientTemperature;
				if (ambientTemperature <= -45f)
				{
					val *= 1.55f;
					return;
				}
				if (ambientTemperature <= -30f)
				{
					val *= 1.4f;
					return;
				}
				if (ambientTemperature <= -15f)
				{
					val *= 1.25f;
					return;
				}
				if (ambientTemperature <= 0f)
				{
					val *= 1.1f;
				}
			}
		}
	}
}
