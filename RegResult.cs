namespace nettest2
{
    public class RegResult
    {
        private bool success = false;

        public RegResult(bool success)
        {
            this.success = success;
        }

        public bool Success => success;
    }
}