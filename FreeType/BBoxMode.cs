namespace FreeType2
{
    public enum BBoxMode : uint
    {
        /// <summary>
        /// Unscaled font units
        /// </summary>
        Unscaled = 0,
        /// <summary>
        /// Unfitted 26.6 coordinates
        /// </summary>
        Subpixels = 0,
        /// <summary>
        /// Grid-fitted 26.6 coordiantes
        /// </summary>
        GridFit = 1,
        /// <summary>
        /// Integer pixel coordinates
        /// </summary>
        Truncate = 2,
        /// <summary>
        /// Grid-fitted pixel coordinates
        /// </summary>
        Pixels = 3
    }
}
