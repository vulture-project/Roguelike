namespace Components
{
    public struct ActiveAffect
    {
        public float DurationLeft;
        public bool Applied;

        public ActiveAffect(float durationLeft)
        {
            DurationLeft = durationLeft;
            Applied = false;
        }
    }
}