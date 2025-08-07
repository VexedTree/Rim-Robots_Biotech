using RimWorld;
using Verse;

namespace VT_Personae
{
    internal class ToxpopPersona
	{
		public class CompAbilityEffect_Toxpop : CompAbilityEffect
		{
			public new CompProperties_AbilityToxpop Props
			{
				get
				{
					return (CompProperties_AbilityToxpop)props;
				}
			}
			public bool ShouldHaveInspectString
			{
				get
				{
					return ModsConfig.BiotechActive && parent.pawn.IsPersonaPawn();
				}
			}
			public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
			{
				base.Apply(target, dest);
				GenExplosion.DoExplosion(target.Cell, parent.pawn.MapHeld, Props.toxRadius, DamageDefOf.Smoke, null, -1, -1f, null, null, null, null, null, 0f, 1, new GasType?(GasType.BlindSmoke), null, 255, false, null, 0f, 1, 0f, false, null, null, null, true, 1f, 0f, true, null, 1f, null, null, null, null);
			}
			public override void DrawEffectPreview(LocalTargetInfo target)
			{
				GenDraw.DrawRadiusRing(target.Cell, Props.toxRadius);
			}
			public override string CompInspectStringExtra()
			{
                if (!ShouldHaveInspectString)
				{
					return null;
				}
                if (parent.CanCast)
                {
					return "RR_AbilityToxpopCharged".Translate();
				}
				return "RR_AbilityToxpopRecharging".Translate(parent.CooldownTicksRemaining.ToStringTicksToPeriod(true, false, true, true, false));
			}
		}
	}

	internal class DeadlifePersona
	{
		public class CompAbilityEffect_Deadlifepop : CompAbilityEffect
		{
			public new CompProperties_AbilityDeadlifepop Props
			{
				get
				{
					return (CompProperties_AbilityDeadlifepop)props;
				}
			}
			public bool ShouldHaveInspectString
			{
				get
				{
					return ModsConfig.AnomalyActive && parent.pawn.IsPersonaPawn();
				}
			}
			public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
			{
				base.Apply(target, dest);
				GenExplosion.DoExplosion(target.Cell, parent.pawn.MapHeld, Props.deadlifeRadius, DamageDefOf.Smoke, null, -1, -1f, null, null, null, null, null, 0f, 1, new GasType?(GasType.DeadlifeDust), null, 255, false, null, 0f, 1, 0f, false, null, null, null, true, 1f, 0f, true, null, 1f, null, null, null, null);
			}
			public override void DrawEffectPreview(LocalTargetInfo target)
			{
				GenDraw.DrawRadiusRing(target.Cell, Props.deadlifeRadius);
			}
			public override string CompInspectStringExtra()
			{
				if (!ShouldHaveInspectString)
				{
					return null;
				}
				if (parent.CanCast)
				{
					return "RR_AbilityDeadlifepopCharged".Translate();
				}
				return "RR_AbilityDeadlifepopRecharging".Translate(parent.CooldownTicksRemaining.ToStringTicksToPeriod(true, false, true, true, false));
			}
		}
	}
}
