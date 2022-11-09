using System.ComponentModel.DataAnnotations;

namespace ExampleConfigurationValidation;

public class Settings
{
	[Required]
	public string AccessKey { get; init; } = null!;

	[Required]
	public string SecretKey { get; init; } = null!;

	[Required]
	[RegularExpression(@"[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)")]
	public string ServiceUrl { get; init; } = null!;

	[Required]
	[RegularExpression(@"(us(-gov)?|ap|ca|cn|eu|sa)-(central|(north|south)?(east|west)?)-\d+")]
	public string Region { get; init; } = null!;
}