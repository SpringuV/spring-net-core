namespace HttpContextExcercise.MySession;

public static class MySessionExtension
{
    // Cookie key used to store the session id on the client
    public const string SessionIdCookieKey = "My_Session_Id";
    public static ISession GetSession(this HttpContext context)
    {
        // Try to read the session id from cookies
        string? sessionId = context.Request.Cookies[SessionIdCookieKey];
        if (SessionIdFormatValid(sessionId))
        {
            // If the cookie contains a valid GUID, retrieve an existing session from storage
            var session=context.RequestServices.GetRequiredService<IMySessionStorage>().Get(sessionId!);
            // Re-append cookie to refresh it on the client
            context.Response.Cookies.Append(SessionIdCookieKey, session.Id);
            return session;
        }
        else
        {
            // Otherwise create a new session and set the cookie
            var session =  context.RequestServices.GetRequiredService<IMySessionStorage>().Create();
            context.Response.Cookies.Append(SessionIdCookieKey, session.Id);
            return session;
        }
    }

    // Validate that the session id is non-null and a valid GUID
    private static bool SessionIdFormatValid(string? sessionId)
    {
        return !string.IsNullOrEmpty(sessionId) && Guid.TryParse(sessionId, out _);
    }
}