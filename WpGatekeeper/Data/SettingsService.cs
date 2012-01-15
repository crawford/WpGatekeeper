using System.IO.IsolatedStorage;

namespace WpGatekeeper.Data
{
    public class SettingsService
    {
        private const string USERNAME_KEY = "Username";
        private const string PASSWORD_KEY = "Password";
        private const string ENCRYPTION_KEY = "";

        private string _username = null;
        private string _password = null;

        public string Username
        {
            get
            {
                if (_username == null)
                {
                    if (IsolatedStorageSettings.ApplicationSettings.Contains(USERNAME_KEY))
                        _username = IsolatedStorageSettings.ApplicationSettings[USERNAME_KEY] as string;
                    else
                        _username = "";
                }
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    IsolatedStorageSettings.ApplicationSettings[USERNAME_KEY] = _username;
                }
            }
        }

        public string Password
        {
            get
            {
                if (_password == null)
                {
                    if (IsolatedStorageSettings.ApplicationSettings.Contains(PASSWORD_KEY))
                    {
                        string outenc = IsolatedStorageSettings.ApplicationSettings[PASSWORD_KEY] as string;
                        _password = Crypto.DecryptStringAES(outenc, ENCRYPTION_KEY);
                    }
                    else
                        _password = "";
                }
                return _password;
            }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    IsolatedStorageSettings.ApplicationSettings[PASSWORD_KEY] = Crypto.EncryptStringAES(_password, ENCRYPTION_KEY);
                }
            }
        }
    }
}
