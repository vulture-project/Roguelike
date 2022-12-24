namespace Components
{
    public struct DiedTag
    {
        public bool StartedDying;

        public DiedTag(bool startedDying = false)
        {
            StartedDying = startedDying;
        }
    }
}