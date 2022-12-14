namespace AI.Base
{
    public class OppositeDecision : ADecision
    {
        public OppositeDecision(ADecision baseDecision)
        {
            _baseDecision = baseDecision;
        }

        public override bool Decide()
        {
            return !_baseDecision.Decide();
        }

        private ADecision _baseDecision;
    }
}
