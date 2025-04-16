namespace Sprout.Application.Services.Contracts;


public interface ICookieService
{
    void Append(string name, string value, bool httpOnly, DateTime expiry);
    string Get(string name);
    void Delete(string name);
}