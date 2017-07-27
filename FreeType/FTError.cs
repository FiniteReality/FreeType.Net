namespace FreeType2
{
    public enum FTError : int
    {
        Success = 0,

        CannotOpenResource,
        UnknownFileFormat,
        InvalidFileFormat,
        InvalidVersion,
        LowerModuleVersion,
        InvalidArgument,
        UnimplementedFeature,
        InvalidTable,
        InvalidOffset,
        ArrayTooLarge,
        MissingModule,
        MissingProperty

        /* TODO: add the others here */
    }
}