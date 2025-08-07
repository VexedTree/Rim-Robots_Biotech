using Verse;
using Verse.AI;
using RimWorld;

namespace VT_Personae
{
	public class JobGiver_RepairPersona : ThinkNode_JobGiver
	{
		protected override Job TryGiveJob(Pawn pawn)
		{
			if (!pawn.IsPersonaPawn() || !pawn.health.HasHediffsNeedingTend(false) || !pawn.health.capacities.CapableOf(PawnCapacityDefOf.Manipulation) || pawn.InAggroMentalState || pawn.needs.food.CurLevel <= 0f)
			{
				return null;
			}
			if (pawn.IsColonist && pawn.WorkTypeIsDisabled(WorkTypeDefOf.Crafting))
			{
				return null;
			}
			Job job = JobMaker.MakeJob(Extensions.RR_DefOf.RR_RepairPersonae, pawn);
			job.endAfterTendedOnce = true;
			return job;
		}
	}
}