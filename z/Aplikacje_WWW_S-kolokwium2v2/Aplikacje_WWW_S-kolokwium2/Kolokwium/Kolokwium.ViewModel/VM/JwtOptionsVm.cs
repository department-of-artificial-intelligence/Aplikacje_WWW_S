namespace Kolokwium.ViewModel.VM;
public class JwtOptionsVm
{
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public string SecretKey { get; set; } = null!;
    public int TokenExpirationMinutes { get; set; }
}
