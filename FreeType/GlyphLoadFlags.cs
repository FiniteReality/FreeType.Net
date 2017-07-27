using System;

namespace FreeType2
{
    [Flags]
    public enum GlyphLoadFlags : ulong
    {
        Default = 0,
        NoScale = 1 << 0,
        NoHinting = 1 << 1,
        Render = 1 << 2,
        NoBitmap = 1 << 3,
        VerticalLayout = 1 << 4,
        ForceAutohint = 1 << 5,
        CropBitmap = 1 << 6,
        Pedantic = 1 << 7,
        IgnoreGlobalAdvanceWidth = 1 << 9,
        NoRecurse = 1 << 10,
        IgnoreTransform = 1 << 11,
        Monochrome = 1 << 12,
        LinearDesign = 1 << 13,
        NoAutohint = 1 << 15,
        LoadColor = 1 << 20,
        ComputeMetrics = 1 << 21,
        LoadBitmapMetricsOnly = 1 << 22
    }
}