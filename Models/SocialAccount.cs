public class SocialAccount
{
    public string Type { get; set; }
    public string Address { get; set; }

    public SocialAccount(string type, string address)
    {
        Type = type;
        Address = address;
    }
}