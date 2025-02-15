using static SDL3.SDL;

namespace ClockworkReverie;

static class Program
{
    static Window mainWindow;

    static bool quit = false;
    static SDL_Event sdlEvent;

    static bool Init()
    {
        if (!SDL_Init(SDL_InitFlags.SDL_INIT_VIDEO))
        {
            SDL_Log($"SDL could not initialize! SDL error: {SDL_GetError()}\n");
            return false;
        }

        using (mainWindow = new())
        {
            while (!quit)
            {
                while (SDL_PollEvent(out sdlEvent))
                {
                    if (sdlEvent.type == (uint)SDL_EventType.SDL_EVENT_QUIT)
                        quit = true;
                }
            }
        }
        SDL_Quit();
        return true;
    }

    static int Main()
    {
        Init();
        return 0;
    }
}