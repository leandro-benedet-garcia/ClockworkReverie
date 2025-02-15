/**
Taken from MoonWorks
https://github.com/MoonsideGames/MoonWorks/blob/main/src/Graphics/Bindings.cs
*/

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SDLBool = SDL3.SDL.SDLBool;

namespace ClockworkReverie.Render;

internal static partial class SDL_ShaderCross
{
    const string NATIVE_LIB_NAME = "SDL3_shadercross";

    [Flags]
    public enum ShaderFormat : uint
    {
        Private = 0x1,
        SPIRV = 0x2,
        DXBC = 0x4,
        DXIL = 0x08,
        MSL = 0x10,
        MetalLib = 0x20,
    }

    public enum ShaderStage
    {
        Vertex,
        Fragment,
        Compute
    }

    public struct GraphicsShaderMetadata
    {
        public uint NumSamplers;
        public uint NumStorageTextures;
        public uint NumStorageBuffers;
        public uint NumUniformBuffers;
    };

    public struct ComputePipelineMetadata
    {
        public uint NumSamplers;
        public uint NumReadOnlyStorageTextures;
        public uint NumReadOnlyStorageBuffers;
        public uint NumReadWriteStorageTextures;
        public uint NumReadWriteStorageBuffers;
        public uint NumUniformBuffers;
        public uint ThreadCountX;
        public uint ThreadCountY;
        public uint ThreadCountZ;
    };

    public unsafe struct INTERNAL_SPIRVInfo
    {
        public byte* Bytecode;
        public UIntPtr BytecodeSize;
        public byte* EntryPoint;
        public ShaderStage ShaderStage;
        public SDLBool EnableDebug;
        public byte* Name;
        public uint Props;
    };

    public unsafe struct INTERNAL_HLSLDefine
    {
        public byte* Name;
        public byte* Value;
    };

    public unsafe struct INTERNAL_HLSLInfo
    {
        public byte* Source;
        public byte* EntryPoint;
        public byte* IncludeDir;
        public INTERNAL_HLSLDefine* Defines;
        public ShaderStage ShaderStage;
        public SDLBool EnableDebug;
        public byte* Name;
        public uint Props;
    }

    [LibraryImport(NATIVE_LIB_NAME)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDLBool SDL_ShaderCross_Init();

    [LibraryImport(NATIVE_LIB_NAME)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SDL_ShaderCross_Quit();

    [LibraryImport(NATIVE_LIB_NAME)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ShaderFormat SDL_ShaderCross_GetSPIRVShaderFormats();

    [LibraryImport(NATIVE_LIB_NAME)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr SDL_ShaderCross_TranspileMSLFromSPIRV(
        in INTERNAL_SPIRVInfo info
    );

    [LibraryImport(NATIVE_LIB_NAME)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr SDL_ShaderCross_TranspileHLSLFromSPIRV(
        in INTERNAL_SPIRVInfo info
    );

    [LibraryImport(NATIVE_LIB_NAME)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr SDL_ShaderCross_CompileDXBCFromSPIRV(
        in INTERNAL_SPIRVInfo info,
        out UIntPtr size
    );

    [LibraryImport(NATIVE_LIB_NAME, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr SDL_ShaderCross_CompileDXILFromSPIRV(
        in INTERNAL_SPIRVInfo info,
        out UIntPtr size
    );

    [LibraryImport(NATIVE_LIB_NAME)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr SDL_ShaderCross_CompileGraphicsShaderFromSPIRV(
        IntPtr device,
        in INTERNAL_SPIRVInfo info,
        out GraphicsShaderMetadata metadata
    );

    [LibraryImport(NATIVE_LIB_NAME)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr SDL_ShaderCross_CompileComputePipelineFromSPIRV(
        IntPtr device,
        in INTERNAL_SPIRVInfo info,
        out ComputePipelineMetadata metadata
    );

    [LibraryImport(NATIVE_LIB_NAME)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ShaderFormat SDL_ShaderCross_GetHLSLShaderFormats();

    [LibraryImport(NATIVE_LIB_NAME, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr SDL_ShaderCross_CompileDXBCFromHLSL(
        in INTERNAL_HLSLInfo info,
        out UIntPtr size
    );

    [LibraryImport(NATIVE_LIB_NAME, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr SDL_ShaderCross_CompileDXILFromHLSL(
        in INTERNAL_HLSLInfo info,
        out UIntPtr size
    );

    [LibraryImport(NATIVE_LIB_NAME, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr SDL_ShaderCross_CompileSPIRVFromHLSL(
        in INTERNAL_HLSLInfo info,
        out UIntPtr size
    );

    [LibraryImport(NATIVE_LIB_NAME, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr SDL_ShaderCross_CompileGraphicsShaderFromHLSL(
        IntPtr device,
        in INTERNAL_HLSLInfo info,
        out GraphicsShaderMetadata metadata
    );

    [LibraryImport(NATIVE_LIB_NAME, StringMarshalling = StringMarshalling.Utf8)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr SDL_ShaderCross_CompileComputePipelineFromHLSL(
        IntPtr device,
        in INTERNAL_HLSLInfo info,
        out ComputePipelineMetadata metadata
    );

    [LibraryImport(NATIVE_LIB_NAME)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDLBool SDL_ShaderCross_ReflectGraphicsSPIRV(
        Span<byte> bytecode,
        UIntPtr bytecodeSize,
        out GraphicsShaderMetadata info
    );

    [LibraryImport(NATIVE_LIB_NAME)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SDLBool SDL_ShaderCross_ReflectComputeSPIRV(
        Span<byte> bytecode,
        UIntPtr bytecodeSize,
        out ComputePipelineMetadata info
    );
}