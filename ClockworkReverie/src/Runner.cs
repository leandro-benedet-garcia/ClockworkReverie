using ClockworkReverie.Render;

using static SDL3.SDL;

namespace ClockworkReverie;

public class Runner: IDisposable
{
  public static Dictionary<string, Runner> active = new();
  readonly string _id;
  readonly Window _mainWindow;

  public const string MAIN_RUNNER_NAME = "main";

  ~Runner() => Dispose();

  public Runner(string id)
  {
    this._id = id;
    active[id] = this;

    if (!SDL_Init(SDL_InitFlags.SDL_INIT_VIDEO))
    {
      SDL_Log($"SDL could not initialize! SDL error: {SDL_GetError()}\n");
      return;
    }

    using (_mainWindow = new())
    {
      var quit = false;
      while (!quit)
      {
        while (SDL_PollEvent(out var sdlEvent))
        {
          if (sdlEvent.type == (uint)SDL_EventType.SDL_EVENT_QUIT)
            quit = true;
        }
      }
    }
  }

  public static Window GetMainWindow() => active[MAIN_RUNNER_NAME]._mainWindow;

  /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
  public void Dispose()
  {
    SDL_Quit();
    active.Remove(_id);
    GC.SuppressFinalize(this);
  }
}
