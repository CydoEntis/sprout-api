namespace TaskGarden.Application.Services.Contracts;


public interface ICookieManager
{
    void Append(string name, string value, bool httpOnly, DateTime expiry);
    string Get(string name);
    void Delete(string name);
}