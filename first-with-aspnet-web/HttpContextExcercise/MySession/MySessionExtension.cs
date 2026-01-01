namespace HttpContextExcercise.MySession;

public static class MySessionExtension
{
    public const string SessionIdCookieKey = "My_Session_Id";
    public static ISession GetSession(this HttpContext context)
    {
        string? sessionId = context.Request.Cookies[SessionIdCookieKey];
        if (SessionIdFormatValid(sessionId))
        {
            var session=context.RequestServices.GetRequiredService<IMySessionStorage>().Get(sessionId!);
            context.Response.Cookies.Append(SessionIdCookieKey, session.Id);
            return session;
        }
        else
        {
            var session =  context.RequestServices.GetRequiredService<IMySessionStorage>().Create();
            context.Response.Cookies.Append(SessionIdCookieKey, session.Id);
            return session;
        }
    }

    private static bool SessionIdFormatValid(string? sessionId)
    {
        return !string.IsNullOrEmpty(sessionId) && Guid.TryParse(sessionId, out _);
    }
}