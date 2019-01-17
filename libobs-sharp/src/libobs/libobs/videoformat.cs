namespace libobs.src.libobs.libobs
{
    public enum videoformat
    {
        Any,
        Unknown,

        /* raw formats */
        ARGB = 100,
        XRGB,

        /* planar YUV formats */
        I420 = 200,
        NV12,
        YV12,
        Y800,

        /* packed YUV formats */
        YVYU = 300,
        YUY2,
        UYVY,
        HDYC,

        /* encoded formats */
        MJPEG = 400,
        H264
    }
}
