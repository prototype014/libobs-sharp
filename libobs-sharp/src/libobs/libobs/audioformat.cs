namespace libobs.src.libobs.libobs
{
    public enum audioformat
    {
        Any,
        Unknown,

        /* raw formats */
        Wave16bit = 100,
        WaveFloat,

        /* encoded formats */
        AAC = 200,
        AC3,
        MPGA /* MPEG 1 */
    }
}
