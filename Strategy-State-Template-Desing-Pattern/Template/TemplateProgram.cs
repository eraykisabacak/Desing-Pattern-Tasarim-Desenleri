using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class TemplateProgram
    {
        static void Main(string[] args)
        {
            ScoringAlgoritm algoritm;
            Console.Write("Mans : ");
            algoritm = new MensScoringAlgorithm();
            Console.WriteLine(algoritm.GenerateScore(8,new TimeSpan(0,2,20)));

            Console.Write("Woman : ");
            algoritm = new WomanScoringAlgorithm();
            Console.WriteLine(algoritm.GenerateScore(8, new TimeSpan(0, 2, 20)));

            Console.Write("Children : ");
            algoritm = new ChildrenScoringAlgorithm();
            Console.WriteLine(algoritm.GenerateScore(8, new TimeSpan(0, 2, 20)));

            Console.ReadLine();
        }
    }

    abstract class ScoringAlgoritm
    {
        public int GenerateScore(int hits,TimeSpan time)
        {
            int score = BazPuan(hits);
            int reduction = PuanAzaltma(time);
            return GenelPuan(score, reduction);
        }

        // Primitif
        public abstract int GenelPuan(int score, int reduction);

        public abstract int PuanAzaltma(TimeSpan time);

        public abstract int BazPuan(int hits);
    }

    class MensScoringAlgorithm : ScoringAlgoritm
    {
        public override int BazPuan(int hits)
        {
            return hits * 100;
        }

        public override int GenelPuan(int score, int reduction)
        {
            return score - reduction;   
        }

        public override int PuanAzaltma(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }

    class WomanScoringAlgorithm : ScoringAlgoritm
    {
        public override int BazPuan(int hits)
        {
            return hits * 105;
        }

        public override int GenelPuan(int score, int reduction)
        {
            return score - reduction;
        }

        public override int PuanAzaltma(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;

        }
    }

    class ChildrenScoringAlgorithm : ScoringAlgoritm
    {
        public override int BazPuan(int hits)
        {
            return hits * 110;
        }

        public override int GenelPuan(int score, int reduction)
        {
            return score - reduction;
        }

        public override int PuanAzaltma(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }
}
