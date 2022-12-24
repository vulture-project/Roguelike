namespace AI.Base
{
    public class OppositeDecision : ADecision
    {
        private readonly ADecision _baseDecision;

        public OppositeDecision(ADecision baseDecision)
        {
            _baseDecision = baseDecision;
        }

        public override bool Decide()
        {
            return !_baseDecision.Decide();
        }
    }
}