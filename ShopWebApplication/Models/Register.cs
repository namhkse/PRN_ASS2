using Microsoft.Build.Framework;

namespace ShopWebApplication.Models;

public class Register
{
	[Required]
	public string UserName { get; set; }
	[Required]
	public string Password { get; set; }
	[Required]
	public string PasswordConfirm { get; set; }
	[Required]
	public string FullName { get; set; }

}
