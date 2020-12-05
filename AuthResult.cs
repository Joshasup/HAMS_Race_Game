namespace nettest2
{
    public class AuthResult
    {
        private bool success = false;

        public AuthResult(bool success)
        {
            this.success = success;
        }

        public bool Success => success;
    }
}