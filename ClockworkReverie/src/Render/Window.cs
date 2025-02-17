namespace ClockworkReverie.Render;

using static SDL3.SDL;


public unsafe class Window : IDisposable
{
    nint _sdlWindow;
    SDL_Surface* _sdlWindowSurface;

    public nint SdlWindow { get => _sdlWindow; }
    public SDL_Surface* SdlWindowSurface { get => _sdlWindowSurface; }

    public Window()
    {
        _sdlWindow = SDL_CreateWindow(
            "Default",
            640,
            480,
            SDL_WindowFlags.SDL_WINDOW_VULKAN
        );

        if (_sdlWindow == IntPtr.Zero)
        {
            SDL_Log($"Window creation error: {SDL_GetError()} \n");
            return;
        }

        _sdlWindowSurface = SDL_GetWindowSurface(_sdlWindow);
    }

    public void Dispose()
    {
        SDL_DestroySurface((nint)_sdlWindowSurface);
        SDL_DestroyWindow(_sdlWindow);

        _sdlWindow = IntPtr.Zero;
        _sdlWindowSurface = null;

        GC.SuppressFinalize(this);
    }
}