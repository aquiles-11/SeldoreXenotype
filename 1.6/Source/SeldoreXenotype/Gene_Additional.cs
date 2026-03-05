using RimWorld;
using System.Linq;
using Verse;

namespace SeldoreXeno
{
    public class Gene_Additional : Gene
    {
        //public override void PostAdd()
        //{
        //    base.PostAdd();

        //    Gene_Additional_Extension modExtension = this.def.GetModExtension<Gene_Additional_Extension>();

        //    if (modExtension != null)
        //    {
        //        if (modExtension.endogenes.Count > 0)
        //        {
        //            foreach (GeneDef geneDef in modExtension.endogenes)
        //            {
        //                this.pawn.genes.AddGene(geneDef, false);

        //                if (this.def.exclusionTags.Any(item => geneDef.exclusionTags.Contains(item)))
        //                {
        //                    this.pawn.genes.GetGene(geneDef).OverrideBy(this.pawn.genes.GetGene(this.def));
        //                }
        //            }
        //        }
        //    }
        //}

        //public override void PostRemove()
        //{
        //    base.PostRemove();

        //    Gene_Additional_Extension modExtension = this.def.GetModExtension<Gene_Additional_Extension>();

        //    if (modExtension != null)
        //    {
        //        if (modExtension.endogenes.Count > 0)
        //        {
        //            foreach (GeneDef geneDef in modExtension.endogenes)
        //            {
        //                this.pawn.genes.RemoveGene(this.pawn.genes.GetGene(geneDef));
        //            }
        //        }
        //    }
        //}

        public override void PostAdd()
        {
            base.PostAdd();

            Gene_Additional_Extension modExtension = def.GetModExtension<Gene_Additional_Extension>();

            if (modExtension != null)
            {
                if (modExtension.endogenes.Count > 0)
                {
                    foreach (GeneDef geneDef in modExtension.endogenes)
                    {
                        pawn.genes.AddGene(geneDef, false);
                    }
                }
            }
        }

        public override void PostRemove()
        {
            base.PostRemove();

            Gene_Additional_Extension modExtension = def.GetModExtension<Gene_Additional_Extension>();

            if (modExtension != null)
            {
                if (modExtension.endogenes.Count > 0)
                {
                    foreach (GeneDef geneDef in modExtension.endogenes)
                    {
                        pawn.genes.RemoveGene(pawn.genes.GetGene(geneDef));
                    }
                }
            }
        }
    }
}