// ErrorViewModel.cs
// Summary: Simple view model used by the Error view to show the request id for diagnostics.

namespace HttpContextExcercise.Models;

public class ErrorViewModel
{
    // The request id associated with the current request (nullable)
    public string? RequestId { get; set; }

    // Helper property used by the view to decide whether to display the RequestId
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}